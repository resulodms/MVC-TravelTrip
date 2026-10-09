using System.ComponentModel.DataAnnotations;

namespace MVC_TravelTrip.Models.Sinifler
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public string BlogImage { get; set; }
        public ICollection<Yorumlar> Yorumlars { get; set; }

    }
}
