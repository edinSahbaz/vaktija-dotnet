using Vaktija.Models;

namespace Vaktija;
class Program
{
    static async Task Main(string[] args)
    {
        IntervalDatuma intervalDatuma = unosKorisnika();
        await prikazVaktije(intervalDatuma);
    }

    static IntervalDatuma unosKorisnika()
    {
        Console.WriteLine("Unesite datume u formatu dd/MM/yyyy.");
        Console.Write("Unesi početni datum: ");
        DateTime pocetakRamazana = unosDatuma();
        Console.Write("Unesi krajnji datum: ");
        DateTime krajRamazana = unosDatuma();

        return new IntervalDatuma(pocetakRamazana, krajRamazana);
    }

    static async Task prikazVaktije(IntervalDatuma intervalDatuma)
    {
        KalendarVaktija vaktija = new KalendarVaktija(intervalDatuma);

        Console.WriteLine("Učitavanje podataka...");

        await vaktija.popuniVaktiju();

        Console.Clear();
        Console.WriteLine(vaktija);
        Console.ReadKey();
    }

    static DateTime unosDatuma()
    {
        DateTime dt;
        string input = Console.ReadLine();

        while (!DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
        {
            Console.WriteLine("Pogrešan format datuma, pokušajte ponovo!");
            input = Console.ReadLine();
        }

        return dt;
    }
}

