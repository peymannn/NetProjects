using RestFulAPIWithDummyData.Models;
using System.ComponentModel.DataAnnotations;

namespace RestFulAPIWithDummyData.DTOs
{
    public class AddUpdateBookDto
    {
        public int ID { get; set; }
        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 1)]
        public string Name { get; set; } 
        [Required]
        [EnumDataType(typeof(Genre), ErrorMessage = "Please check genre data")]
        public Genre Genre { get; set; }
        [DataType(DataType.Text)]
        public int PageCount { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } 
        [MinLength(1)]
        public List<string> Characters { get; set; } 
    }
}
