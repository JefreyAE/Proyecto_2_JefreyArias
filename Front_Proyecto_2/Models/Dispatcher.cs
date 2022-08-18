namespace Front_Proyecto_2.Models
{
    public class Dispatcher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public List<Article>? Articles { get; set; }

        public Dispatcher() { }
        public Dispatcher(int id, string name, int code)
        {
            Id = id;
            Name = name;
            Code = code;
        }
    }
}
