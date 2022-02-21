using DataAccessLayer.Repositories.Abstract;
using DataLayer.User;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserManager<User> UserManager { get; set; }
        public SignInManager<User> SignInManager { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public UserRepository(ApplicationDbContext dbContext, UserManager<User> userManager,
            SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
            : base(dbContext)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            HttpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserId() =>
            UserManager.GetUserId(HttpContextAccessor.HttpContext.User);

        public User GetCurrentUser() =>
             UserManager.FindByIdAsync(GetCurrentUserId()).Result;

        public override List<User> GetAllWithRelations()
        {
            throw new System.NotImplementedException();
        }

        public override List<User> GetAllWithRelations(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public override User GetByIdWithRelations(string id)
        {
            return (User)dbSet
                .Where(u => u.Id == id)
                .Include(u => u.Products)
                .Include(u => u.SentMessages)
                .Include(u => u.ReceivedMessages);
        }

        public User GetByIdWithMessages(string id)
        {
            return (User)dbSet
                .Where(u => u.Id == id)
                .Include(u => u.SentMessages)
                .Include(u => u.ReceivedMessages);
        }

        public User GetByIdWithMessages(string id, int productId)
        {
            return (User)dbSet
                .Where(u => u.Id == id)
                .Include(u => u.SentMessages.Where(m => m.ProductId == productId))
                .Include(u => u.ReceivedMessages.Where(m => m.ProductId == productId));
        }

        #region Authentication
        public SignInResult PasswordSignIn(PasswordSignInUserDTO passwordSignInUserDTO) =>
          SignInManager.PasswordSignInAsync(
              passwordSignInUserDTO.UserName,
              passwordSignInUserDTO.Password,
              passwordSignInUserDTO.RememberMe,
              false).Result;

        public IdentityResult SignUp(User user, string password) =>
            UserManager.CreateAsync(user, password).Result;

        public void SignOut()
        {
            SignInManager.SignOutAsync();
        }
        #endregion
    }
}