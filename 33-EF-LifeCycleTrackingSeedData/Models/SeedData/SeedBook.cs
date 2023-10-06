using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33_EF_LifeCycleTrackingSeedData.Models.SeedData
{
    internal class SeedBook : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { BookId=1, Title="Suç ve Ceza", AuthorId=2 },
                new Book { BookId=2, Title="Karamazoz Karderşler", AuthorId=2 },
                new Book { BookId=3, Title="Yeraltından Notlar", AuthorId=2},
                new Book { BookId=4, Title="Beyaz Geceler", AuthorId=2},
                new Book { BookId=5, Title="Kumarbaz", AuthorId=2}
                );
        }
    }
}
