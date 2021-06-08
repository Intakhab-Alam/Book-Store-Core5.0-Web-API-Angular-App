using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BooksModel>> GetAllBooksAsync()
        {
            /*var records = await _context.Books.Select(x => new BooksModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).ToListAsync();

            return records;*/

            //Code using AutoMapper for mapping of fields of model class and data class when both class have exactly same fields.
            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BooksModel>>(records);
        }

        public async Task<BooksModel> GetBookByIdAsync(int bookId)
        {
            /* var record = await _context.Books.Where(x => x.Id == bookId).Select(x => new BooksModel()
             {
                 Id = x.Id,
                 Title = x.Title,
                 Description = x.Description
             }).FirstOrDefaultAsync();

             return record;*/

            //Code using AutoMapper for mapping of fields of model class and data class when both class have exactly same fields.
            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BooksModel>(book);
        }
        public async Task<int> AddBookAsync(BooksModel booksModel)
        {
            var book = new Books()
            {
                Title = booksModel.Title,
                Description = booksModel.Description
            };

            _context.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }
        public async Task UpdateBookAsync(int bookId, BooksModel booksModel)
        {
            //This logic hitting the database two times
            /*var book = await _context.Books.FindAsync(bookId);
            if(book != null)
            {
                book.Title = booksModel.Title;
                book.Description = booksModel.Description;

                await _context.SaveChangesAsync();
            }*/

            //In this logic database is hit one time but we did not know book is exist or not by bookId.
            var book = new Books()
            {
                Id = bookId,
                Title = booksModel.Title,
                Description = booksModel.Description
            };

            _context.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument booksModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if(book != null)
            {
                booksModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = new Books()
            {
                Id = bookId
            };

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
