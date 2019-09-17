namespace DesignApp.Models
{
    class LoginCredentials
    {

        public string Password { get; set; }
        public string Username { get; set; }

        public LoginCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

    }

}
