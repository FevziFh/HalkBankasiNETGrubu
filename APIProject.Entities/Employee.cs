using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string FirstName { get; set; }
        [Required,MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Deparment { get; set; }
    }
}
