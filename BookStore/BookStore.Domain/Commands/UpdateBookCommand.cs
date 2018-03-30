using BookStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;


namespace BookStore.Domain.Commands
{
    public class UpdateBookCommand : ICommand
    {
        public string Title { get; set; }
        public string Edition { get; set; }
        public string Author { get; set; }
        public int StockQuantity { get; set; }
        public Guid Id { get; set; }


        public bool Valid()
        {
            if (String.IsNullOrEmpty(Title))
                return false;
            if (StockQuantity <= 0)
                return false;

            return true;
        }
    }
}
