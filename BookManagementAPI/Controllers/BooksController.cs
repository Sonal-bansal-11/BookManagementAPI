using BookManagementAPI.Models;
using BookManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        // Constructor Injection: The framework "injects" the service here
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bookService.GetAllBooks());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound($"Book with ID {id} not found.");
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if (id != book.Id) return BadRequest("ID mismatch");

            var existing = _bookService.GetBookById(id);
            if (existing == null) return NotFound();

            _bookService.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _bookService.DeleteBook(id);
            if (!deleted) return NotFound();
            return Ok("Book deleted successfully.");
        }
    }
}