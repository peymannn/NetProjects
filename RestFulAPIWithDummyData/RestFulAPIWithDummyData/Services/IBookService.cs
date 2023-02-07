using RestFulAPIWithDummyData.DTOs;
using RestFulAPIWithDummyData.Models;

namespace RestFulAPIWithDummyData.Services
{
    public interface IBookService
    {
        public ServiceResponse<List<GetBookDto>> GetAllBooks();
        public ServiceResponse<GetBookDto> GetBookById(int id);
        public ServiceResponse<List<GetBookDto>> GetBookByName(string name);
        public ServiceResponse<List<GetBookDto>> GetBooksByGenre(Genre genre);
        public ServiceResponse<List<GetBookDto>> AddBook(AddUpdateBookDto newBook);
        public ServiceResponse<GetBookDto> UpdateBook(AddUpdateBookDto updatedBook);
        public ServiceResponse<GetBookDto> DeleteBook(int id);
    }
}
