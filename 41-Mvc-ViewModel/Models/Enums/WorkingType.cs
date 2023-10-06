using System.ComponentModel.DataAnnotations;

namespace _41_Mvc_ViewModel.Models.Enums
{
    public enum WorkingType
    {
        [Display(Name = "Tam Zamanlı")]
        FullTime,
        [Display(Name = "Yarı Zamanlı")]
        PartTime,
        [Display(Name = "Proje Bazlı")]
        ProjectBased,
        [Display(Name = "Serbest Zamanlı")]
        Freelance
    }
}
