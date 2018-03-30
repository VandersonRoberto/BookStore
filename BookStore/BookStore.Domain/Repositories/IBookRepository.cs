using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Repositories
{
    public interface IBookRepository : IDisposable
    {
        List<Book> GetAll();
        Book Get(Guid id);
        void Create(Book book);
        void Update(Book book);
        void Delete(Guid id);
        bool CheckTitleExists(string title);
    }
}
