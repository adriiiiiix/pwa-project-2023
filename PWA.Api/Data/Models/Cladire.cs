using System.ComponentModel.DataAnnotations;

namespace PWA.Api.Data.Models
{
    public class Cladire
    {       
        public int Id { get; set; }
        public string Tip_Strada { get; set; }
        
        public string Denumire_Strada { get; set; }
        
        public string Numar { get; set; }

        public string? Bloc { get; set; }

        public string? Scara { get; set; }
        
        public string Stadiul_Blocului { get; set; }
        
        public string Anul_Construirii { get; set; }
        public string? Regim_Inaltime { get; set; }
        public string? Sistemul_constructiv { get; set; }
        
        public int Numar_apartamente { get; set; }

        public float? Longitudine { get; set; }
        public float? Latitudine { get; set; }
    }
}
