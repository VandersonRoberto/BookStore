using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BookStore.Domain.Queries
{
    public static class BookQueries
    {
        public static Expression<Func<Book,bool>> CheckTitleExists(string Title)
        {
            return b => b.Title == Title;
        }
    }
}
