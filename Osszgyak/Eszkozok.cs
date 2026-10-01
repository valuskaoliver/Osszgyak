using System;
using System.Collections.Generic;
using System.Text;

namespace Osszgyak
{
    internal class Eszkozok
    {
        private int beszerzesiAr;
        private int raktarKeszlet;
        private static int osszesLetezoEszkoz = 0;

        public string Cikkszam { get; set; }
        public string Nev { get; set; }
        public int BeszerzesiAr
        {
            get
            {
                return beszerzesiAr;
            }
            set
            {
                if (value < 0)
                {
                    beszerzesiAr = 0;
                }
                else
                {
                    beszerzesiAr = value;
                }
            }

        }
        public int RaktarKeszlet
        {
            get
            {
                return raktarKeszlet;
            }
            set
            {
                if (value < 0)
                {
                    raktarKeszlet = 0;
                }
                else
                {
                    raktarKeszlet = value;
                }
            }
        }
        public static int OsszesLetezoEszkoz
        {
            get { return osszesLetezoEszkoz; }
        }
        public Eszkozok(string cikkszam, string nev, int beszerzesiAr)
            : this(cikkszam, nev, beszerzesiAr, 0)
        {
        }
        public Eszkozok(string cikkszam, string nev, int beszerzesiAr, int raktarKeszlet)
        {
            Cikkszam = cikkszam;
            Nev = nev;
            BeszerzesiAr = beszerzesiAr;
            RaktarKeszlet = raktarKeszlet;

            osszesLetezoEszkoz++;
        }

        public override string ToString()
        {
            return $"{Cikkszam}, {Nev} Beszerzési ár: {BeszerzesiAr} Ft, Készlet: {RaktarKeszlet} db";
        }

        public bool Eladas(int db)
        {
            if (RaktarKeszlet >= db)
            {
                RaktarKeszlet -= db;
                return true;
            }
            else
            {
                Console.WriteLine($"Nincs elegendő készlet! (Elérhető: {RaktarKeszlet} db, Kért: {db} db)");
                return false;
            }
        }
    }
}
