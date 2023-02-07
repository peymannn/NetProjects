using Microsoft.AspNetCore.Mvc;
using RestFulAPIWithDummyData.DTOs;
using RestFulAPIWithDummyData.Models;
using RestFulAPIWithDummyData.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestFulAPIWithDummyData.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService service)
        {
            this.bookService = service;
        }
        // GET: api/<BooksController>/BookList
        [HttpGet("BookList")]
        public ActionResult<ServiceResponse<List<GetBookDto>>> Get()
        {
            var response = bookService.GetAllBooks();
            if (response.Data == null)
                return BadRequest(response);
            return Ok(response);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public ActionResult<ServiceResponse<GetBookDto>> Get(int id)
        {
            var response = bookService.GetBookById(id);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }
        // GET: api/<BooksController>/GetByName
        [HttpGet]
        [Route("GetByName")]
        public ActionResult<ServiceResponse<GetBookDto>> GetByName([FromQuery] string name)
        {
            var response = bookService.GetBookByName(name);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetByGenre")]
        public ActionResult<ServiceResponse<GetBookDto>> GetByGenre([FromQuery] Genre genre)
        {
            var response = bookService.GetBooksByGenre(genre);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }
        // POST api/<BooksController>
        [HttpPost]
        public ActionResult<ServiceResponse<List<GetBookDto>>> Post([FromBody] AddUpdateBookDto value)
        {
            var response = bookService.AddBook(value);
            if (response.Data == null)
                return BadRequest(response);
            return Created(Url.Action("Get", new { id = response.Data[response.Data.Count - 1].ID })!, response); ;
        }

        // PUT api/<BooksController>/
        [HttpPut]
        public ActionResult<ServiceResponse<List<GetBookDto>>> Put([FromBody] AddUpdateBookDto value)
        {
            var response = bookService.UpdateBook(value);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public ActionResult<ServiceResponse<GetBookDto>> Delete(int id)
        {
            var response = bookService.DeleteBook(id);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }
    }
}
