using Osszgyak;

List<Eszkozok> adatok = new List<Eszkozok>();

foreach(string sor in File.ReadAllLines("eszkozok.txt"))
{
    string[] mezok = sor.Split(';');
    if (!int.TryParse(mezok[3], out int raktardb))
    {
        Console.WriteLine($"[HIBA] A(z) {mezok[0]} cikkszámú sor adata hibás, átugorva!");
        continue;
    }
    if (!int.TryParse(mezok[2], out int ar))
    {
        Console.WriteLine($"[HIBA] A(z) {mezok[0]} cikkszámú sor adata hibás, átugorva!");
        continue;
    }
    Eszkozok ujEszkoz = new Eszkozok(mezok[0], mezok[1], ar, raktardb);
    adatok.Add(ujEszkoz);
}

Console.WriteLine("\n=== SIKERESEN BEOLVASOTT ESZKÖZÖK ===");
foreach (Eszkozok eszkoz in adatok)
{
    Console.WriteLine(eszkoz);
}
Console.WriteLine($"\nRendszerben regisztrált eszközök száma:{Eszkozok.OsszesLetezoEszkoz} db");

double osszesBruttoAr = 0;
foreach(Eszkozok eszkoz in adatok)
{
    osszesBruttoAr += Penzugy.BruttoArSzamitas((double)eszkoz.BeszerzesiAr * eszkoz.RaktarKeszlet);
}
Console.WriteLine($"Raktárkészlet teljes bruttó értéke: {osszesBruttoAr} Ft");

Eszkozok legdragabb = adatok.MaxBy(e => e.BeszerzesiAr);
Console.WriteLine($"Legdrágább eszköz: {legdragabb.Nev} ({legdragabb.BeszerzesiAr} FT)");