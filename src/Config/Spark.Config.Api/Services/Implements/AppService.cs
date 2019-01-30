using Fruit.Entity;
using Fruit.IService;
using Fruit.Repository;
using Spark.Core.Values;
using System.Collections.Generic;

namespace Spark.Config.Api.Services.Implements
{
    public class AppService : IAppService
    {
        private readonly IAppRepository _repository;

        public AppService(IAppRepository repository)
        {
            _repository = repository;
        }

        public long Insert(App app)
        {
            return _repository.Insert(app);
        }

        public int Delete(object reqParams)
        {
            return _repository.Delete(reqParams);
        }

        public int DeleteById(long id)
        {
            return _repository.DeleteById(id);
        }

        public int Update(App app)
        {
            return _repository.Update(app);
        }

        public int DyUpdate(object dyObj)
        {
            return _repository.DyUpdate(dyObj);
        }

        public App GetEntity(object reqParams)
        {
            return _repository.GetEntity(reqParams);
        }

        public int GetRecord(object reqParams)
        {
            return _repository.GetRecord(reqParams);
        }

        public bool IsExist(object reqParams)
        {
            return _repository.IsExist(reqParams);
        }

        public IEnumerable<App> Query(object reqParams)
        {
            return _repository.Query(reqParams);
        }

        public IEnumerable<App> QueryByPage(object reqParams)
        {
            return _repository.QueryByPage(reqParams);
        }

        public QueryByPageResponse<App> QueryPaged(object reqParams)
        {
            return _repository.QueryPaged(reqParams);
        }
    }
}