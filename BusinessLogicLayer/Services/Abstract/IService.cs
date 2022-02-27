using DataAccessLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface IService<TEntity> where TEntity : class
    {
        IRepository<TEntity> Repository { get; set; }
        IUnitOfWork UnitOfWork { get; set; }

        void Insert<T>(T DTO);

        void Update<T>(T DTO);

        void Delete<T>(T DTO);

        T GetById<T>(int id);

        T GetById<T>(string id);

        List<T> GetAll<T>();

        List<T> GetAll<T>(Expression<Func<TEntity, bool>> filter);

        List<T> GetAllWithRelations<T>();

        List<T> GetAllWithRelations<T>(Expression<Func<TEntity, bool>> filter);
    }
}