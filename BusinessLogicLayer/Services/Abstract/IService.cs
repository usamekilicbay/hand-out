using DataAccessLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface IService<T> where T : class
    {
        IRepository<T> Repository { get; set; }
        IUnitOfWork UnitOfWork { get; set; }

        void Insert<ViewModel>(ViewModel viewModel);

        void Update<ViewModel>(ViewModel viewModel);

        void Delete<ViewModel>(ViewModel viewModel);

        ViewModel GetById<ViewModel>(int id);

        ViewModel GetById<ViewModel>(string id);

        List<ViewModel> GetAll<ViewModel>();

        List<ViewModel> GetAll<ViewModel>(Expression<Func<T, bool>> filter);
    }
}