using BookStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class Book : Entity
    {

        public Book()
        {

        }

        public Book(string title, string edition , string author, int stockQuantity)
        {
            Title = title;
            Edition = edition;
            Author = author;
            StockQuantity = stockQuantity;
        }
        
        
        public string Title { get;  private set; }
        public string Edition { get; private set; }
        public string Author { get;  private set; }
        public int StockQuantity { get; private set; }
        


    }
}
