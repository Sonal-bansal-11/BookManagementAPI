using BookManagementAPI.Models;

namespace BookManagementAPI.Services
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book? GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        bool DeleteBook(int id);
    }
}