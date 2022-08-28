namespace API_Proyecto_2.Models
{
    public class RecallsDates
    {
        public DateTime RecallDate1;
        public DateTime RecallDate2;

        public RecallsDates() { }
        public RecallsDates(DateTime recallDate1, DateTime recallDate2)
        {
            RecallDate1 = recallDate1;
            RecallDate2 = recallDate2;
        }
    }
}
