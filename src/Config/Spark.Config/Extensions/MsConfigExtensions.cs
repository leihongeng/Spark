using Spark.Config.SDK.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Spark.Config.Extensions
{
    internal static class MsConfigExtensions
    {
        internal static IEnumerable<KeyValuePair<string, string>> ConvertToConfig(
             this MsConfig kvPair,
             string rootKey)
        {
            return JsonConfigurationFileParser.Parse(kvPair.Value).Select(pair =>
            {
                string key = $"{kvPair.Key}:{pair.Key}";

                return new KeyValuePair<string, string>(key, pair.Value);
            });
        }
    }
}