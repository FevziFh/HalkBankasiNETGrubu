using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32_EF_StudentCourseTeacher.Models
{
    public class Teacher : BaseEntity
    {
        [Column("Name", TypeName ="nvarchar(50)")]
        [Required(ErrorMessage = "İsim Alanı Zorunlu Olmalıdır.")]
        public string Name { get; set; }
    }
}
