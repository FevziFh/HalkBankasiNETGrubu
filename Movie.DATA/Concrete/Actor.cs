using Movie.DATA.Abstract;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.DATA.Concrete
{
    public class Actor: BaseFilm
    {
        public string ActorName { get; set; }
        public DateTime BirthDate { get; set; }

        [Column(TypeName = "text")]
        public string? Biograhpy { get; set; }
        public virtual IList<FilmActor> FilmActors { get; set; }
    }
}
