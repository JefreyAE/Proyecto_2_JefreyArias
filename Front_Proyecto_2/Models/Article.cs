namespace Front_Proyecto_2.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string TrackingId { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? RecallDate { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public int DispatcherId { get; set; }
        public string State { get; set; }
        public Client? Client { get; set; }

        public Article() { }

        public Article(int id, string trackingId, DateTime admissionDate, double price, double weight, string description, int clientId, int dispatcherId, string state)
        {
            Id = id;
            TrackingId = trackingId;
            AdmissionDate = admissionDate;
            Price = price;
            Weight = weight;
            Description = description;
            ClientId = clientId;
            DispatcherId = dispatcherId;
            State = state;
        }
    }
}
