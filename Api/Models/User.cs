namespace Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string Token { get; set; }

        public User(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public User(string username, string Token)
        {
            this.username = username;
            this.Token = Token;
        }


        public User()
        {
        }
    }
}
