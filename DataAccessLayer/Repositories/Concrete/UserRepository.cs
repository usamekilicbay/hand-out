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
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Concrete
{
    public class UserRepository : Repository<User, string>, IUserRepository
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

        public User GetUser(string userId) =>
          UserManager.FindByIdAsync(userId).Result;

        public string GetCurrentUserId() =>
            UserManager.GetUserId(HttpContextAccessor.HttpContext.User);

        public User GetCurrentUser() =>
             UserManager.FindByIdAsync(GetCurrentUserId()).Result;

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await UserManager.UpdateAsync(user);
        }

        public override List<User> GetAllWithRelations()
        {
            throw new System.NotImplementedException();
        }
        public override List<User> GetAllWithRelations(Expression<Func<User, bool>> filter)
        {
            return dbSet.Where(filter)
                .Include(u => u.Products)
                .ToList();
        }

        #region Authentication
        public async Task<SignInResult> PasswordSignIn(PasswordSignInUserDTO passwordSignInUserDTO)
        {
            var user = await UserManager.FindByNameAsync(passwordSignInUserDTO.UserName);
            if (user == null)
                Console.WriteLine("User not found");

            var isPasswordValid = await UserManager.CheckPasswordAsync(user, passwordSignInUserDTO.Password);
            if (!isPasswordValid)
                Console.WriteLine("Password mismatch");


            var result = await SignInManager.PasswordSignInAsync(
              passwordSignInUserDTO.UserName,
              passwordSignInUserDTO.Password,
              passwordSignInUserDTO.RememberMe,
              false);
            
            return result; 
        }
        public IdentityResult SignUp(User user, string password) =>
            UserManager.CreateAsync(user, password).Result;

        public void SignOut()
        {
            SignInManager.SignOutAsync();
        }
        #endregion
    }
}