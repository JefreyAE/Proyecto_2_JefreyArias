namespace Front_Proyecto_2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {

        }
        public User(int id, string? name, int userId, string email, string password)
        {
            Id = id;
            Name = name;
            UserId = userId;
            Email = email;
            Password = password;
        }
    }
}
