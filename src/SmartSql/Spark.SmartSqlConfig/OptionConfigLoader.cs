using Microsoft.Extensions.Logging;
using SmartSql;
using SmartSql.Abstractions.Config;
using SmartSql.Configuration;
using SmartSql.Configuration.Maps;
using SmartSql.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Spark.SmartSqlConfig
{
    public class OptionConfigLoader : ConfigLoader
    {
        private const string _sqlMapConfigFilePath = "SmartSqlMapConfig.xml";
        private SmartSqlDbConfigOptions _options;
        private readonly ILogger _logger;
        private const int DELAYED_LOAD_FILE = 500;
        private FileWatcherLoader _fileWatcherLoader;

        public OptionConfigLoader(SmartSqlDbConfigOptions smartSqlOptions, ILoggerFactory loggerFactory)
        {
            _options = smartSqlOptions;
            _logger = loggerFactory.CreateLogger<OptionConfigLoader>();
            _fileWatcherLoader = new FileWatcherLoader();
        }

        public override event OnChangedHandler OnChanged;

        public override void Dispose()
        {
            _fileWatcherLoader.Dispose();
        }

        /// <summary>
        /// 配置文件修改触发事件
        /// </summary>
        /// <param name="options"></param>
        public void TriggerChanged(SmartSqlDbConfigOptions options)
        {
            _options = options;
            //修改数据库连接
            this.SqlMapConfig.Database = new SmartSql.Configuration.Database()
            {
                DbProvider = _options.Database.DbProvider,
                ReadDataSources = _options.Database.Read,
                WriteDataSource = _options.Database.Write
            };
            //触发
            OnChanged?.Invoke(this, new OnChangedEventArgs
            {
                EventType = EventType.ConfigChanged,
                SqlMapConfig = this.SqlMapConfig
            });
        }

        public override SmartSqlMapConfig Load()
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"LocalFileConfigLoader Load: {_sqlMapConfigFilePath} Starting");
            }
            //读取xml文件

            var smartSqlConfig = LoadSmartSqlConfig();

            SqlMapConfig = new SmartSqlMapConfig()
            {
                Database = new SmartSql.Configuration.Database()
                {
                    DbProvider = _options.Database.DbProvider,
                    ReadDataSources = _options.Database.Read,
                    WriteDataSource = _options.Database.Write
                },
                SmartSqlMaps = new Dictionary<String, SmartSqlMap>(),
                SmartSqlMapSources = smartSqlConfig.SmartSqlMaps,
                Settings = smartSqlConfig.Settings,
                TypeHandlers = smartSqlConfig.TypeHandlers,
            };

            foreach (var sqlMapSource in SqlMapConfig.SmartSqlMapSources)
            {
                switch (sqlMapSource.Type)
                {
                    case SmartSqlMapSource.ResourceType.File:
                        {
                            LoadSmartSqlMapAndInConfig(sqlMapSource.Path);
                            break;
                        }
                    case SmartSqlMapSource.ResourceType.Directory:
                    case SmartSqlMapSource.ResourceType.DirectoryWithAllSub:
                        {
                            SearchOption searchOption = SearchOption.TopDirectoryOnly;
                            if (sqlMapSource.Type == SmartSqlMapSource.ResourceType.DirectoryWithAllSub)
                            {
                                searchOption = SearchOption.AllDirectories;
                            }
                            var dicPath = Path.Combine(AppContext.BaseDirectory, sqlMapSource.Path);
                            var childSqlmapSources = Directory.EnumerateFiles(dicPath, "*.xml", searchOption);
                            foreach (var childSqlmapSource in childSqlmapSources)
                            {
                                LoadSmartSqlMapAndInConfig(childSqlmapSource);
                            }
                            break;
                        }
                    default:
                        {
                            if (_logger.IsEnabled(LogLevel.Debug))
                            {
                                _logger.LogDebug($"LocalFileConfigLoader unknow SmartSqlMapSource.ResourceType:{sqlMapSource.Type}.");
                            }
                            break;
                        }
                }
            }
            InitDependency();
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"LocalFileConfigLoader Load: {_sqlMapConfigFilePath} End");
            }

            if (SqlMapConfig.Settings.IsWatchConfigFile)
            {
                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogDebug($"LocalFileConfigLoader Load Add WatchConfig: {_sqlMapConfigFilePath} Starting.");
                }
                WatchConfig();
                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogDebug($"LocalFileConfigLoader Load Add WatchConfig: {_sqlMapConfigFilePath} End.");
                }
            }
            return SqlMapConfig;
        }

        private SmartSqlConfigOptions LoadSmartSqlConfig()
        {
            var configFilePath = Path.Combine(AppContext.BaseDirectory, _sqlMapConfigFilePath);
            var configStream = new ConfigStream
            {
                Path = configFilePath,
                Stream = FileLoader.Load(configFilePath)
            };
            using (configStream.Stream)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SmartSqlMapConfig));
                var smartSqlConfig = xmlSerializer.Deserialize(configStream.Stream) as SmartSqlMapConfig;
                if (smartSqlConfig.TypeHandlers != null)
                {
                    foreach (var typeHandler in smartSqlConfig.TypeHandlers)
                    {
                        typeHandler.Handler = TypeHandlerFactory.Create(typeHandler.Type);
                    }
                }

                return new SmartSqlConfigOptions()
                {
                    Settings = smartSqlConfig.Settings,
                    SmartSqlMaps = smartSqlConfig.SmartSqlMapSources,
                    TypeHandlers = smartSqlConfig.TypeHandlers
                };
            }
        }

        private void LoadSmartSqlMapAndInConfig(string sqlMapPath)
        {
            var sqlMap = LoadSmartSqlMap(sqlMapPath);
            SqlMapConfig.SmartSqlMaps.Add(sqlMap.Scope, sqlMap);
        }

        private SmartSqlMap LoadSmartSqlMap(String sqlMapPath)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"LoadSmartSqlMap Load: {sqlMapPath}");
            }
            var sqlmapStream = LoadConfigStream(sqlMapPath);
            return LoadSmartSqlMap(sqlmapStream);
        }

        public ConfigStream LoadConfigStream(string path)
        {
            var configStream = new ConfigStream
            {
                Path = path,
                Stream = FileLoader.Load(path)
            };
            return configStream;
        }

        /// <summary>
        /// 监控配置文件-热更新
        /// </summary>
        private void WatchConfig()
        {
            #region SmartSqlMapConfig File Watch

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug($"LocalFileConfigLoader Watch SmartSqlMapConfig: {_sqlMapConfigFilePath} .");
            }
            var cofigFileInfo = FileLoader.GetInfo(_sqlMapConfigFilePath);
            _fileWatcherLoader.Watch(cofigFileInfo, () =>
            {
                Thread.Sleep(DELAYED_LOAD_FILE);
                lock (this)
                {
                    try
                    {
                        if (_logger.IsEnabled(LogLevel.Debug))
                        {
                            _logger.LogDebug($"LocalFileConfigLoader Changed ReloadConfig: {_sqlMapConfigFilePath} Starting");
                        }
                        SqlMapConfig = Load();
                        OnChanged?.Invoke(this, new OnChangedEventArgs
                        {
                            SqlMapConfig = SqlMapConfig,
                            EventType = EventType.ConfigChanged
                        });
                        if (_logger.IsEnabled(LogLevel.Debug))
                        {
                            _logger.LogDebug($"LocalFileConfigLoader Changed ReloadConfig: {_sqlMapConfigFilePath} End");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(new EventId(ex.HResult), ex, ex.Message);
                    }
                }
            });

            #endregion SmartSqlMapConfig File Watch

            #region SmartSqlMaps File Watch

            foreach (var sqlmapKV in SqlMapConfig.SmartSqlMaps)
            {
                var sqlmap = sqlmapKV.Value;

                #region SqlMap File Watch

                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogDebug($"LocalFileConfigLoader Watch SmartSqlMap: {sqlmap.Path} .");
                }
                var sqlMapFileInfo = FileLoader.GetInfo(sqlmap.Path);
                _fileWatcherLoader.Watch(sqlMapFileInfo, () =>
                {
                    Thread.Sleep(DELAYED_LOAD_FILE);
                    lock (this)
                    {
                        try
                        {
                            if (_logger.IsEnabled(LogLevel.Debug))
                            {
                                _logger.LogDebug($"LocalFileConfigLoader Changed Reload SmartSqlMap: {sqlmap.Path} Starting");
                            }
                            var newSqlMap = LoadSmartSqlMap(sqlmap.Path);
                            var oldSqlMap = SqlMapConfig.SmartSqlMaps.Values.First(s => s.Path == sqlmap.Path);
                            oldSqlMap.Caches = newSqlMap.Caches;
                            oldSqlMap.Scope = newSqlMap.Scope;
                            oldSqlMap.Statements = newSqlMap.Statements;
                            InitDependency();
                            OnChanged?.Invoke(this, new OnChangedEventArgs
                            {
                                SqlMapConfig = SqlMapConfig,
                                SqlMap = oldSqlMap,
                                EventType = EventType.SqlMapChangeed
                            });
                            if (_logger.IsEnabled(LogLevel.Debug))
                            {
                                _logger.LogDebug($"LocalFileConfigLoader Changed Reload SmartSqlMap: {sqlmap.Path} End");
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(new EventId(ex.HResult), ex, ex.Message);
                        }
                    }
                });

                #endregion SqlMap File Watch
            }

            #endregion SmartSqlMaps File Watch
        }
    }
}