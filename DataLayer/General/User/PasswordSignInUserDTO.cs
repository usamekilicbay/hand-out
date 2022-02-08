namespace DataLayer.User
{
    public class PasswordSignInUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}