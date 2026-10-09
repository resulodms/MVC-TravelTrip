using System.ComponentModel.DataAnnotations;

namespace MVC_TravelTrip.Models.Sinifler
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Kullanici { get; set; }
        public string Sifre { get; set; }

    }
}
