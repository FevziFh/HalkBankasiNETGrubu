namespace _41_Mvc_ViewModel.Models.Data
{
    public static class Data
    {
        public static List<Futbolcu> futbolcuList = new List<Futbolcu>()
        {
            new Futbolcu()
            {
                Id = 1,
                Adi="Sabri SarıOğlu",
                MevkiId=1,
                TakimId=1,
                Yas=41
            }
        };
        public static List<Takim> takimList = new List<Takim>()
        {
            new Takim()
            {
                Id = 1,
                Adi="Galatasaray",
                TeknikDirector="fatih Terim"
            },
             new Takim()
            {
                Id = 2,
                Adi="Barselona",
                TeknikDirector="Guardiola"
            },
             new Takim()
            {
                Id = 3,
                Adi="Real Mardin",
                TeknikDirector="Ankaralı Namık"
            },
        };
        public static List<Mevki> mevkiList = new List<Mevki>()
        {
            new Mevki()
            {
                Id = 1,
                Adi="Astronot"
            },
            new Mevki()
            {
                Id = 2,
                Adi="kaleci"
            },
            new Mevki()
            {
                Id = 3,
                Adi="Sol Back"
            },
            new Mevki()
            {
                Id = 4,
                Adi="Forvet"
            },
        };
    }
}
