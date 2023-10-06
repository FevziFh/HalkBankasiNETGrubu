using _35_EF_LibraryProject.Context;
using _35_EF_LibraryProject.Model;
using _35_EF_LibraryProject.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_EF_LibraryProject.DAL
{
    public class AuthorDAL : IAuthorDAL
    {
        private readonly AppDbContext context;
        public AuthorDAL(AppDbContext context)
        {
            this.context = context;
        }

        public void AddAuthor(Author author)
        {
            context.Author.Add(author);
            context.SaveChanges();
        }

        public void DeleteAuthor(Author author)
        {
            author.DeleteDate = DateTime.Now;
            author.Status = Status.Passive;
            context.Author.Remove(author);
            context.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            author.UpdateDate = DateTime.Now;
            author.Status = Status.Modified;
            context.Author.Update(author);
            context.SaveChanges();
        }
    }
}
