using _36_EF_BookProject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_EF_BookProject.Model
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        [Column(TypeName="date")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;
    }
}
