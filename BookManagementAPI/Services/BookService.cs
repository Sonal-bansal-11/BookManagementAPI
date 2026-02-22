using BookManagementAPI.Models;

namespace BookManagementAPI.Services
{
    public class BookService : IBookService
    {
        // This list acts as our "In-Memory" database
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "C# for Beginners", Author = "John Doe", ISBN = "123-ABC" },
            new Book { Id = 2, Title = "ASP.NET Core Basics", Author = "Jane Smith", ISBN = "456-DEF" }
        };

        public List<Book> GetAllBooks() => _books;

        public Book? GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void AddBook(Book book)
        {
            // Simple logic to handle ID incrementing
            book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
        }

        public void UpdateBook(Book updatedBook)
        {
            var existingBook = GetBookById(updatedBook.Id);
            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title;
                existingBook.Author = updatedBook.Author;
                existingBook.ISBN = updatedBook.ISBN;
            }
        }

        public bool DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _books.Remove(book);
                return true;
            }
            return false;
        }
    }
}