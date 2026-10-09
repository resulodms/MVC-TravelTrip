using System.ComponentModel.DataAnnotations;

namespace MVC_TravelTrip.Models.Sinifler
{
    public class Iletisim
    {
        [Key]
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Mail { get; set; }
        
        public string Konu { get; set; }
        public string Mesaj { get; set; }

    }
}
