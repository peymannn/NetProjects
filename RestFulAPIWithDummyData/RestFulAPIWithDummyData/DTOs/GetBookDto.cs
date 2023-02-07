using RestFulAPIWithDummyData.Models;

namespace RestFulAPIWithDummyData.DTOs
{
    public class GetBookDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
    }
}
