namespace Vaktija.Models
{
    public class DanVaktije
    {
        private DateTime datum;
        private Termini termini;

        public DanVaktije(DateTime datum, Termini termini)
        {
            this.datum = datum;
            this.termini = termini;
        }

        public override string ToString()
        {
            return $"| {datum.ToString("dd.MM.yyyy ddd")} |" +
                $"     {termini.zora.ToString("hh:mm")}     |" +
                $"     {termini.izlazakSunca.ToString("hh:mm")}     |" +
                $"     {termini.podne.ToString("hh:mm")}     |" +
                $"     {termini.ikindija.ToString("hh:mm")}     |" +
                $"     {termini.aksam.ToString("hh:mm")}     |" +
                $"     {termini.jacija.ToString("hh:mm")}     |\n";
        }
    }

}

