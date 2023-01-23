namespace PWA.Api.Data.Models
{
    public class Imagine
    {
        public int Id { get; set; }
        public int CladireId { get; set; }
        public byte[] ImagineData { get; set; }
        public string ImagineName { get; set; }
    }
}
