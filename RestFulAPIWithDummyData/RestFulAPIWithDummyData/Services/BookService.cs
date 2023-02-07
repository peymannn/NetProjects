
using AutoMapper;
using RestFulAPIWithDummyData.DTOs;
using RestFulAPIWithDummyData.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RestFulAPIWithDummyData.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper mapper;
        public BookService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        private static List<Book> BookList = new List<Book>()
        {
            new Book(){
             ID= 1,
             Name="x",
             Genre=Genre.Romance,
             PageCount=100,
             PublishDate=new DateTime(2000,10,02),
             Characters=new List<string> {"Janya"}
            },
            new Book(){ ID=2 ,
             Name="y",
             Genre=Genre.Crime_Mystery,
             PageCount=200,
             PublishDate=new DateTime(2000,10,02),
             Characters=new List<string> {"Janya","Rosa"}},
            new Book(){ ID=3 ,
             Name="z",
             Genre=Genre.Comics,
             PageCount=200,
             PublishDate=new DateTime(2000,10,02),
             Characters=new List<string> {"Janya","Rosa","Mem"}}
        };

        public ServiceResponse<List<GetBookDto>> GetAllBooks()
        {
            ServiceResponse<List<GetBookDto>> response = new ServiceResponse<List<GetBookDto>>();
            try
            {
                response.Data = BookList.Select(x => mapper.Map<GetBookDto>(x)).ToList();
                response.Success = true;
                
            }catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                throw new NotImplementedException();
            }
            return response;
        }

        public ServiceResponse<GetBookDto> GetBookById(int id)
        {
            ServiceResponse<GetBookDto> response = new ServiceResponse<GetBookDto>();

            try
            {
                response.Data = mapper.Map<GetBookDto>(GetBookByID(id));           
                response.Success = true;
             
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                throw new NotImplementedException();
            }
            return response;
        }

        public ServiceResponse<List<GetBookDto>> GetBookByName(string name)
        {
            ServiceResponse<List<GetBookDto>> response = new ServiceResponse<List<GetBookDto>>();

            try
            {
                response.Data = mapper.Map<List<GetBookDto>>(BookList.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList());
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                throw new NotImplementedException();
            }
            return response;
        }

        public ServiceResponse<List<GetBookDto>> GetBooksByGenre(Genre genre)
        {
            ServiceResponse<List<GetBookDto>> response = new ServiceResponse<List<GetBookDto>>();

            try
            {
                response.Data = mapper.Map<List<GetBookDto>>(BookList.Where(x => x.Genre==genre).ToList());
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                throw new NotImplementedException();
            }
            return response;
        }

        public ServiceResponse<List<GetBookDto>> AddBook(AddUpdateBookDto newBook)
        {
            ServiceResponse<List<GetBookDto>> response = new ServiceResponse<List<GetBookDto>>();
           
            try
            {
                var book = mapper.Map<Book>(newBook);
                BookList.Add(book);
                response.Success = true;
                response.Data = mapper.Map<List<GetBookDto>>(BookList);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                throw new NotImplementedException();
            }
            return response;
        }

        public ServiceResponse<GetBookDto> UpdateBook(AddUpdateBookDto updatedBook)
        {
            ServiceResponse<GetBookDto> response = new ServiceResponse<GetBookDto>();
          
            try
            {
                var book= GetBookByID(updatedBook.ID);
                mapper.Map(updatedBook,book);
                response.Data = mapper.Map<GetBookDto>(book);
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                throw new NotImplementedException();
            }
            return response;
        }

        private static Book GetBookByID(int id)
        {
           return BookList.FirstOrDefault(x => x.ID == id);
        }

        public ServiceResponse<GetBookDto> DeleteBook(int id)
        {
            ServiceResponse<GetBookDto> response = new ServiceResponse<GetBookDto>();
            response.Success = false;
            try
            {
                var book = GetBookByID(id);
                BookList.Remove(book);
                response.Success = true;
                response.Data = mapper.Map<GetBookDto>(book);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                throw new NotImplementedException();
            }
            return response;
        }
    }
}
