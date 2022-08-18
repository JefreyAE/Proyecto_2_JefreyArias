namespace API_Proyecto_2.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int ClientPersonalId { get; set; }
        public DateTime Birthday { get; set; }

        public List<Article>? Articles { get; set; }

        public Client() { }
        public Client(int id, string name, int clientPersonalId, DateTime birthday)
        {
            Id = id;
            Name = name;
            ClientPersonalId = clientPersonalId;
            Birthday = birthday;
        }
    }
}
