﻿using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

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

        public SignInResult PasswordSignIn(string userName, string password, bool isPersistent, bool lockoutOnFailure = false) =>
            SignInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure).Result;

        public IdentityResult SignUp(User user, string password) => 
            UserManager.CreateAsync(user, password).Result;
    }
}