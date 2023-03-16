using Newtonsoft.Json;

namespace Vaktija.Models
{
	public class KalendarVaktija
    {
		private DateTime pocetakVaktije { get; set; }
		private DateTime krajVaktije { get; set; }
		public List<DanVaktije> daniVaktije { get; set; }

		public KalendarVaktija(IntervalDatuma intervalDatuma)
		{
			pocetakVaktije = intervalDatuma.pocetakVaktije;
			krajVaktije = intervalDatuma.krajVaktije;

			daniVaktije = new List<DanVaktije>();
		}

        private async Task<Termini> izracunajTermine(DateTime datum)
        {
            // 77 - Sarajevo

            var godina = datum.Year;
            var mjesec = datum.Month;
            var dan = datum.Day;
            string apiUrl = $"https://api.vaktija.ba/vaktija/v1/77/{godina}/{mjesec}/{dan}";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(apiUrl);

                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var podaci = JsonConvert.DeserializeObject<VaktijaPodaci>(responseBody);

                    TimeOnly zora = TimeOnly.Parse(podaci.vakat[0]);
                    TimeOnly izlazakSunca = TimeOnly.Parse(podaci.vakat[1]);
                    TimeOnly podne = TimeOnly.Parse(podaci.vakat[2]);
                    TimeOnly ikindija = TimeOnly.Parse(podaci.vakat[3]);
                    TimeOnly aksam = TimeOnly.Parse(podaci.vakat[4]);
                    TimeOnly jacija = TimeOnly.Parse(podaci.vakat[5]);

                    if (datum.Month >= 3 && datum.Month <= 10)
                    {
                        if ((datum.Month == 3 && datum.Day < 26) || (datum.Month == 10 && datum.Day > 29))
                            goto preskociPovecanje;

                        zora = zora.AddHours(1);
                        izlazakSunca = izlazakSunca.AddHours(1);
                        podne = podne.AddHours(1);
                        ikindija = ikindija.AddHours(1);
                        aksam = aksam.AddHours(1);
                        jacija = jacija.AddHours(1);
                    }

                    preskociPovecanje:
                    var output = new Termini(zora, izlazakSunca, podne, ikindija, aksam, jacija);

                    return output;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                var temp = new TimeOnly(0);
                return new Termini(temp, temp, temp, temp, temp, temp);
            }

        }

        public async Task popuniVaktiju()
		{
			DateTime datum = pocetakVaktije;

            while (datum <= krajVaktije)
            {
                var termini = await izracunajTermine(datum);

				DanVaktije dan = new DanVaktije(datum, termini);
				daniVaktije.Add(dan);
                
                datum = datum.AddDays(1);
            }
        }

        public override string ToString()
		{
			string output = "\nVaktija - GRUPA 2\n" +
				$"------------------\n\n" +
				$"Lokacija: Sarajevo, Bosna i Hercegovina\n" +
				$"Početak:  {pocetakVaktije.ToString("dddd, dd.MM.yyyy.")}\n" +
				$"Kraj:     {krajVaktije.ToString("dddd, dd.MM.yyyy.")}\n\n";
                                              
			string separator = "|----------------|---------------|---------------|---------------|---------------|---------------|---------------|\n";
			string headerTop = "|                | Početak posta |               |               |               |     Iftar     |               |\n";
            string headerBottom = "|  Datum i dan   |      Zora     | Izlazak sunca |     Podne     |    Ikindija   |     Akšam     |     Jacija    |\n";

            output += separator;
            output += headerTop;
            output += headerBottom;
            output += separator;

            foreach (DanVaktije dan in daniVaktije)
			{
				output += dan;
				output += separator;
            }

            return output;
		}
    }
}

