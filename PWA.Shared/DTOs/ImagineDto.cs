using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWA.Shared.DTOs
{
    public sealed class ImagineDto
    {
        public int Id { get; set; }
        public int CladireId { get; set; }
        public byte[] ImagineData { get; set; }
        public string ImagineName { get; set; }
    }
}
