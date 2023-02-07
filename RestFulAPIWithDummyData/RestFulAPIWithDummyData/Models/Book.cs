namespace RestFulAPIWithDummyData.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public List<string> Characters { get; set; } 
    }
}
