namespace Backend_Task03.Models
{
    public class Review
    {
        public int ID { get; set; }
        //1-5 rating
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Account Account { get; set; }
        public Beer Beer { get; set; }
    }
}
