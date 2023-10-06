using Movie.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.DATA.Concrete
{
    public class FilmCategory : BaseFilm
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olmalıdır.")]
        [MinLength(3, ErrorMessage = "Minimum 3 karakter olmalıdır.")]
        public string CategoryName { get; set; }

        [NotMapped]
        public string CategoryURL 
        {
            get { return TurkishToEnglish(CategoryName); }
        }

        public virtual IList<Film> Films { get; set; }

        public string TurkishToEnglish(string charcter)
        {
            
            string turkceKarakter = "ığüşöç ";
            string ingilizceKarakter = "igusoc-";

            for (int i = 0; i < turkceKarakter.Length; i++)
            {
               charcter = charcter.ToLower().Replace(turkceKarakter[i], ingilizceKarakter[i]);
            }

            return charcter;

        }
    }
}
