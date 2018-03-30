using BookStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entities;
using BookStore.Infrastructure.Data;
using BookStore.Domain.Queries;

namespace BookStore.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private AppDataContext _context;


        public BookRepository(AppDataContext context)
        {
            this._context = context;
        }

        public List<Book> GetAll()
        {
            return _context.Books.OrderBy(b => b.Title).ToList();
        }

        public void Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Entry<Book>(book).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Book deleteBook = _context.Books.Where(x => x.Id == id).FirstOrDefault();

            _context.Books.Remove(deleteBook);
            _context.SaveChanges();
        }

        public bool CheckTitleExists(string title)
        {
            var exp = BookQueries.CheckTitleExists(title);
            return _context.Books.AsQueryable().Where(exp).Count() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Book Get(Guid id)
        {
            return _context.Books.Where(b => b.Id == id).FirstOrDefault();
        }
    }
}
