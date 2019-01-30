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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public long Insert(User user)
        {
            return _repository.Insert(user);
        }

        public int Delete(object reqParams)
        {
            return _repository.Delete(reqParams);
        }

        public int DeleteById(long id)
        {
            var user = _repository.GetById(id);
            if (user != null)
            {
                user.IsDelete = 1;
                user.UpdateTime = DateTime.Now;
                return _repository.Update(user);
            }

            return 0;
        }

        public int Update(User user)
        {
            return _repository.Update(user);
        }

        public int DyUpdate(object dyObj)
        {
            return _repository.DyUpdate(dyObj);
        }

        public User GetEntity(object reqParams)
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

        public IEnumerable<User> Query(object reqParams)
        {
            return _repository.Query(reqParams);
        }

        public IEnumerable<User> QueryByPage(object reqParams)
        {
            return _repository.QueryByPage(reqParams);
        }

        public QueryByPageResponse<User> QueryPaged(object reqParams)
        {
            return _repository.QueryPaged(reqParams);
        }
    }
}