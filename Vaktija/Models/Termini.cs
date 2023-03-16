namespace Vaktija.Models
{
	public struct Termini
	{
		public TimeOnly zora { get; }
		public TimeOnly izlazakSunca { get; }
		public TimeOnly podne { get; }
		public TimeOnly ikindija { get; }
		public TimeOnly aksam { get; }
		public TimeOnly jacija { get; }

        public Termini(TimeOnly zora, TimeOnly izlazakSunca, TimeOnly podne, TimeOnly ikindija, TimeOnly aksam, TimeOnly jacija)
		{
			this.zora = zora;
			this.izlazakSunca = izlazakSunca;
			this.podne = podne;
			this.ikindija = ikindija;
			this.aksam = aksam;
			this.jacija = jacija;
        }

	}
}

