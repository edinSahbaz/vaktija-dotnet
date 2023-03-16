namespace Vaktija.Models
{
    // Model za API
    public class VaktijaPodaci
    {
        public int id { get; set; }
        public string lokacija { get; set; }
        public int godina { get; set; }
        public int mjesec { get; set; }
        public int dan { get; set; }
        public List<string> datum { get; set; }
        public List<string> vakat { get; set; }
    }
}

