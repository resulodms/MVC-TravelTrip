using System.ComponentModel.DataAnnotations;

namespace MVC_TravelTrip.Models.Sinifler
{
    public class Hakkimizda
    {
        [Key]
        public int Id { get; set; }
        public string Aciklama { get; set; }
        public string FotoUrl { get; set; }
    }
}
