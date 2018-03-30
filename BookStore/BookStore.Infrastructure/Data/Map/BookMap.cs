using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookStore.Infrastructure.Data.Map

{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            ToTable("Book");

            //Property(x => x.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Title)
                .HasMaxLength(300)
                .IsRequired();

            Property(x => x.Author)
                .HasMaxLength(50);

            Property(x => x.Edition)
                .HasMaxLength(100);

            Property(x => x.StockQuantity)
                .IsRequired();
        }
    }
}
