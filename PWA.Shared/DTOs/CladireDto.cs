using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWA.Shared.DTOs
{
	public sealed class CladireDto
	{
        public int Id { get; set; }
        [Required]
		public string Tip_Strada { get; set; }
        [Required]
		public string Denumire_Strada { get; set; }
		[Required]
		public string Numar { get; set; }

        
        public string? Bloc { get; set; }
        
        public string? Scara { get; set; }
        [Required]
        public string Stadiul_Blocului { get; set; }
        [Required]
        public string Anul_Construirii { get; set; }
        public string? Regim_Inaltime { get; set; }
        public string? Sistemul_constructiv { get; set; }
        [Required]
        public int Numar_apartamente { get; set; }

        public float? Longitudine { get; set; }
        public float? Latitudine { get; set; }
    }
}
