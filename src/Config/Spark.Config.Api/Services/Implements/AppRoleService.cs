using Fruit.Entity;
using Fruit.IService;
using Fruit.Repository;
using Spark.Core.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spark.Config.Api.Services.Implements
{
    public class AppRoleService : IAppRoleService
    {
        private readonly IAppRoleRepository _repository;

        public AppRoleService(IAppRoleRepository repository)
        {
            _repository = repository;
        }

        public long Insert(AppRole appRole)
        {
            return _repository.Insert(appRole);
        }

        public int Delete(object reqParams)
        {
            return _repository.Delete(reqParams);
        }

        public int DeleteById(long id)
        {
            return _repository.DeleteById(id);
        }

        public int Update(AppRole appRole)
        {
            return _repository.Update(appRole);
        }

        public int DyUpdate(object dyObj)
        {
            return _repository.DyUpdate(dyObj);
        }

        public AppRole GetEntity(object reqParams)
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

        public IEnumerable<AppRole> Query(object reqParams)
        {
            return _repository.Query(reqParams);
        }

        public IEnumerable<AppRole> QueryByPage(object reqParams)
        {
            return _repository.QueryByPage(reqParams);
        }

        public QueryByPageResponse<AppRole> QueryPaged(object reqParams)
        {
            return _repository.QueryPaged(reqParams);
        }
    }
}