namespace Vaktija.Models
{
    public struct IntervalDatuma
    {
        public DateTime pocetakVaktije { get; }
        public DateTime krajVaktije { get; }

        public IntervalDatuma(DateTime pocetakVaktije, DateTime krajVaktije)
        {
            this.pocetakVaktije = pocetakVaktije;
            this.krajVaktije = krajVaktije;
        }
    }
}
