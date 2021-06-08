using BookStoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<BooksModel>> GetAllBooksAsync();
        Task<BooksModel> GetBookByIdAsync(int bookId);
        Task<int> AddBookAsync(BooksModel booksModel);
        Task UpdateBookAsync(int bookId, BooksModel booksModel);
        Task UpdateBookPatchAsync(int bookId, JsonPatchDocument booksModel);
        Task DeleteBookAsync(int bookId);
    }
}
