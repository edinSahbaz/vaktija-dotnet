namespace Vaktija.Models
{
    public struct IntervalDatuma
    {
        public DateTime pocetakRamazana { get; }
        public DateTime krajRamazana { get; }

        public IntervalDatuma(DateTime pocetakRamazana, DateTime krajRamazana)
        {
            this.pocetakRamazana = pocetakRamazana;
            this.krajRamazana = krajRamazana;
        }
    }
}
