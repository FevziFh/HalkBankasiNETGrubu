using _36_EF_BookProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_EF_BookProject.Enums
{
    public class Author : BaseEntity
    {
        private string _authorLastName;
        private string _authorFirstName;
        public Author()
        {
            //AuthorFullName = ;
        }

        [Column(TypeName ="nvarchar(50)")]
        public string AuthorFirstName {
            get { return _authorFirstName; }
            set { _authorFirstName = value; }
        }
        [Column(TypeName = "nvarchar(50)")]
        public string AuthorLastName {
            get { return _authorLastName; }
            set { _authorLastName = value; }
        }
        [NotMapped]
        public string AuthorFullName { 
            get { return _authorFirstName + " " + _authorLastName; } 
        }
        //Navigation Property
        public virtual IList<Book> Books { get; set; }
    }
}
