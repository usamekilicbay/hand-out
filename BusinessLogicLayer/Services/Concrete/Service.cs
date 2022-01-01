﻿using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Services.Concrete
{
    public abstract class Service<T> : IService<T> where T : class
    {
        public IRepository<T> Repository { get; set; }
        protected IMapper mapper;

        public Service(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public virtual void Delete<ViewModel>(ViewModel viewModel)
        {
            T entity = mapper.Map<T>(viewModel);
            Repository.Delete(entity);
        }

        public virtual List<ViewModel> GetAll<ViewModel>()
        {
            List<T> entities = Repository.GetAll();
            List<ViewModel> viewModels = mapper.Map<List<ViewModel>>(entities);

            return viewModels;
        }

        public virtual List<ViewModel> GetAll<ViewModel>(Expression<Func<T, bool>> filter)
        {
            List<T> entities = Repository.GetAll(filter);
            List<ViewModel> viewModels = mapper.Map<List<ViewModel>>(entities);

            return viewModels;
        }

        public virtual ViewModel GetByID<ViewModel>(int id)
        {
            T entity = Repository.GetByID(id);
            ViewModel viewModel = mapper.Map<ViewModel>(entity);

            return viewModel;
        }

        public virtual void Insert<ViewModel>(ViewModel viewModel)
        {
            T entity = mapper.Map<T>(viewModel);
            Repository.Insert(entity);
        }

        public virtual void Update<ViewModel>(ViewModel viewModel)
        {
            T entity = mapper.Map<T>(viewModel);
            Repository.Update(entity);
        }
    }
}