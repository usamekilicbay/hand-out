using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Services.Concrete
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public IRepository<TEntity> Repository { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        protected IMapper mapper;

        public Service(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public virtual void Delete<T>(T DTO)
        {
            TEntity entity = mapper.Map<TEntity>(DTO);
            Repository.Delete(entity);
        }

        public virtual List<T> GetAll<T>()
        {
            List<TEntity> entities = Repository.GetAll();
            List<T> DTOs = mapper.Map<List<T>>(entities);

            return DTOs;
        }

        public virtual List<T> GetAll<T>(Expression<Func<TEntity, bool>> filter)
        {
            List<TEntity> entities = Repository.GetAll(filter);
            List<T> DTOs = mapper.Map<List<T>>(entities);

            return DTOs;
        }

        public virtual T GetById<T>(int id)
        {
            TEntity entity = Repository.GetById(id);
            T DTO = mapper.Map<T>(entity);

            return DTO;
        }

        public virtual T GetById<T>(string id)
        {
            TEntity entity = Repository.GetById(id);
            T DTO = mapper.Map<T>(entity);

            return DTO;
        }

        public virtual void Insert<T>(T DTO)
        {
            TEntity entity = mapper.Map<TEntity>(DTO);
            Repository.Insert(entity);
        }

        public virtual void Update<T>(T DTO)
        {
            TEntity entity = mapper.Map<TEntity>(DTO);
            Repository.Update(entity);
        }

        public virtual List<T> GetAllWithRelations<T>() =>
            mapper.Map<List<T>>(Repository.GetAllWithRelations());

        public virtual List<T> GetAllWithRelations<T>(Expression<Func<TEntity, bool>> filter) =>
            mapper.Map<List<T>>(Repository.GetAllWithRelations(filter));
    }
}