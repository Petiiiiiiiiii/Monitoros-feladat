using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using System.ComponentModel;

namespace CA231003
{
    class Program
    {
        static double BruttoOssz(List<Monitor> monitorok) 
        {
            var bruttoOssz = monitorok
                .Sum(m => m.BruttoAra * m.RaktaronDB);

            return bruttoOssz;
        }

        static void Atszamolo(List<Monitor> monitorok) 
        {
            var atszamolva = new List<Monitor>();

            for (int i = 0; i < monitorok.Count; i++)
                if (monitorok[i].Ara > 50000)
                    atszamolva.Add(monitorok[i]);

            for (int i = 0; i < atszamolva.Count; i++)
                Console.WriteLine($"\tGyártó: {atszamolva[i].Gyarto}; Típus: {atszamolva[i].Tipus}; Méret {atszamolva[i].Meret} col; Nettó ár: {atszamolva[i].Ara / 1000} ezer Ft");
        }
        static void Kiiras(List<Monitor> monitorok) //Fájlba kiiras
        {
            var sw = new StreamWriter(
            path: @"..\..\..\src\otvenFeletti.txt",
            append: false);
            foreach (var monitor in monitorok)
                sw.WriteLine($"Gyártó: {monitor.Gyarto}; Típus: {monitor.Tipus}; Méret {monitor.Meret} col; Nettó ár: {monitor.Ara / 1000} ezer Ft");

            sw.Close();

        }
        static void Kereses(List<Monitor> monitorok) 
        {

            string keresettGyarto = "HP";
            string keresettTipus = "EliteDisplay E242";

            var vane = monitorok
                .Where(m => m.Gyarto == keresettGyarto && m.Tipus == keresettTipus)
                .Count();

            if (vane >= 1)
            {
                var hanyDB = monitorok
                    .Where(m => m.Gyarto == keresettGyarto && m.Tipus == keresettTipus)
                    .First();

                Console.WriteLine($"\tA keresett, {keresettGyarto} {keresettTipus} monitorból: {hanyDB.RaktaronDB} db van még!");
            }
            else 
            {
                double atlag = monitorok
                       .Average(m => m.Ara);

                var ajanlas = monitorok
                    .Where(m => m.Ara > atlag)
                    .First();

                Console.WriteLine($"\tSajnos a keresett, {keresettGyarto} {keresettTipus} monitorból nincs készleten!");
                Console.WriteLine("\tAjánlhatok egy másik monitort: ");
                Console.WriteLine("\t" + ajanlas);
            }

           
        }

        static void AtlagArFolottVagyAlatt(List<Monitor> monitorok) 
        {
            double nettoAtlag = monitorok
                .Average(m => m.Ara);

            foreach (var monitor in monitorok)
                Console.WriteLine($"\t{monitor.Gyarto} {monitor.Tipus} ára {(monitor.Ara > nettoAtlag ? "nagyobb" : "kisebb")}, mint a nettó átlag ár!");
        }

        static void Vasarlok(List<Monitor> monitorok) 
        {
            var rnd = new Random();
            int vasarloDB = rnd.Next(5, 16);
            int hanyasMonitor;
            int mennyiMonitor;

            for (int i = 0; i < vasarloDB; i++)
            {
                hanyasMonitor = rnd.Next(1,7);
                mennyiMonitor = rnd.Next(1,3);

                switch (hanyasMonitor)
                {
                    case 1:
                        if (monitorok[0].RaktaronDB - mennyiMonitor >= 0)
                        {
                            monitorok[0].RaktaronDB -= mennyiMonitor;
                        }
                        else
                            Console.WriteLine("szopo");
                        break;
                    case 2:
                        if (monitorok[1].RaktaronDB - mennyiMonitor >= 0)
                        {
                            monitorok[1].RaktaronDB -= mennyiMonitor;
                        }
                        else
                            Console.WriteLine("szopo");
                        break;
                    case 3:
                        if (monitorok[2].RaktaronDB - mennyiMonitor >= 0)
                        {
                            monitorok[2].RaktaronDB -= mennyiMonitor;
                        }
                        else
                            Console.WriteLine("szopo");
                        break;
                    case 4:
                        if (monitorok[3].RaktaronDB - mennyiMonitor >= 0)
                        {
                            monitorok[3].RaktaronDB -= mennyiMonitor;
                        }
                        else
                            Console.WriteLine("szopo");
                        break;
                    case 5:
                        if (monitorok[4].RaktaronDB - mennyiMonitor >= 0)
                        {
                            monitorok[4].RaktaronDB -= mennyiMonitor;
                        }
                        else
                            Console.WriteLine("szopo");
                        break;
                    case 6:
                        if (monitorok[5].RaktaronDB - mennyiMonitor >= 0)
                        {
                            monitorok[5].RaktaronDB -= mennyiMonitor;
                        }
                        else
                            Console.WriteLine("szopo");
                        break;
                    default:
                        Console.WriteLine("Valami hiba van öcskös.");
                        break;

                }

            }

        }

        static void abc(List<Monitor> monitorok)
        {
            var abc = monitorok
                .OrderBy(m => m.Gyarto);

            foreach (var monitor in abc)
            {
                Console.WriteLine("\t" + monitor);
            }
        }

        static List<Monitor> abcProg(List<Monitor> monitorok) 
        {
            var abcben = monitorok.OrderBy(m => m.Gyarto);
            var abcbenL = new List<Monitor>();

            foreach (var monitor in abcben)
            {
                abcbenL.Add(monitor);
            }


            return abcbenL;
        }

        static void Main()
        {
            //1. Hozz létre egy osztályt a monitorok adatai számára. Olvasd be a fájl tartalmát.

            var monitorok = new List<Monitor>();
            var sr = new StreamReader(
                path: @"..\..\..\src\monitorok.txt",
                encoding: Encoding.UTF8
                );

            _ = sr.ReadLine();

            while (!sr.EndOfStream)
                monitorok.Add(new Monitor(sr.ReadLine()));


            //2. Írd ki a monitorok összes adatát virtuális metódussal, soronként egy monitort a képernyőre. A kiírás így nézzen ki: 

            //Gyártó: Samsung; Típus: S24D330H; Méret: 24 col; Nettó ár: 33000 Ft 

            Console.WriteLine("2. feladat: ");
            foreach (var monitor in monitorok )
                Console.WriteLine("\t" + monitor);
            Console.WriteLine();

            //2. Tárold az osztálypéldányokban a bruttó árat is (ÁFA: 27%, konkrétan a 27-tel számolj, ne 0,27-tel vagy más megoldással.) 


            //3. Tételezzük fel, hogy mindegyik monitorból 15 db van készleten, ez a nyitókészlet.
            //Mekkora a nyitó raktárkészlet bruttó (tehát áfával növelt) értéke?
            //Írj egy metódust, ami meghívásakor kiszámolja a raktárkészlet aktuális bruttó értékét. A főprogram írja ki az értéket. 

            Console.WriteLine("3. feladat: ");
            Console.WriteLine($"\tRaktár készlet aktuális bruttó értéke: {BruttoOssz(monitorok):0.00} Ft");
            Console.WriteLine();

            //4. Írd ki egy új fájlba, és a képernyőre az 50.000 Ft feletti nettó értékű monitorok összes adatát (a darabszámmal együtt) úgy,
            //hogy a szöveges adatok nagybetűsek legyenek, illetve az árak ezer forintba legyenek átszámítva.
            //Az ezer forintba átszámítást egy külön függvényben valósítsd meg. 

            Console.WriteLine("4. feladat: ");
            Kiiras(monitorok);
            Atszamolo(monitorok);
            Console.WriteLine();

            //5. Egy vevő keresi a HP EliteDisplay E242 monitort. Írd ki neki a képernyőre, hogy hány darab ilyen van a készleten.
            //Ha nincs a készleten, ajánlj neki egy olyan monitort, aminek az ára az átlaghoz fölülről közelít.
            //Ehhez használd az átlagszámító függvényt (később lesz feladat). 

            Console.WriteLine("5. feladat: ");
            Kereses(monitorok);
            Console.WriteLine();

            //6. Egy újabb vevőt csak az ár érdekli. Írd ki neki a legolcsóbb monitor méretét, és árát. 

            Monitor legolcsobb = monitorok
                .Where(m => m.Ara == monitorok.Min(m => m.Ara))
                .First();

            Console.WriteLine("6. feladat: ");
            Console.WriteLine($"\tA legolcsóbb monitor mérete: {legolcsobb.Meret} col, és az ára: {legolcsobb.Ara} Ft!");
            Console.WriteLine();

            //7. A cég akciót hirdet. A 70.000 Ft fölötti árú Samsung monitorok bruttó árából 5%-ot elenged.
            //Írd ki, hogy mennyit veszítene a cég az akcióval, ha az összes akciós monitort akciósan eladná. 

            double bukas = monitorok
                .Where(m => m.Ara > 70000)
                .Sum(m => (m.BruttoAra * m.RaktaronDB) * 0.95);

            Console.WriteLine("7. feladat: ");
            Console.WriteLine($"\tA cég veszítene : {bukas:0.00} Ft-ot!");
            Console.WriteLine();

            //8. Írd ki a képernyőre minden monitor esetén, hogy az adott monitor nettó ára a nettó átlag ár alatt van-e, vagy fölötte, 
            //esetleg pontosan egyenlő az átlag árral. Ezt is a főprogram írja ki. 

            Console.WriteLine("8. feladat: ");
            AtlagArFolottVagyAlatt(monitorok);
            Console.WriteLine();

            //9. Modellezzük, hogy megrohamozták a vevők a boltot.
            //5 és 15 közötti random számú vásárló 1 vagy 2 random módon kiválasztott monitort vásárol,
            //ezzel csökkentve az eredeti készletet. Írd ki, hogy melyik monitorból mennyi maradt a boltban. 
            //Vigyázz, hogy nulla darab alá ne mehessen a készlet.
            //Ha az adott monitor éppen elfogyott, ajánlj neki egy másikat (lásd fent). 

            Vasarlok(monitorok);

            Console.WriteLine("9. feladat: ");
            foreach (var monitor in monitorok)
            {
                Console.WriteLine("\t " + monitor + $", Darab : {monitor.RaktaronDB}");
            }
            Console.WriteLine();

            //10. Írd ki a képernyőre, hogy a vásárlások után van-e olyan monitor, amelyikből mindegyik elfogyott (igen/nem).

            bool vane = false;

            foreach (var monitor in monitorok)
                if (monitor.RaktaronDB == 0)
                    vane = true;
                else
                    vane = false;

            Console.WriteLine("10. feladat: ");

            if (vane)
                Console.WriteLine("\tVolt olyan monitor amelyikből mind elfogyott!");
            else
                Console.WriteLine("\tNem volt olyan monitor amelyikből elfogyott volna mind!");

            Console.WriteLine();

            //11. Írd ki a gyártókat abc sorrendben a képernyőre. Oldd meg úgy is, hogy a metódus írja ki, és úgy is, hogy a főprogram. 

            Console.WriteLine("11. feladat: ");
            Console.WriteLine("Metódussal:");
            abc(monitorok);
            Console.WriteLine("Fő programban:");

            foreach (var monitor in abcProg(monitorok))
            {
                Console.WriteLine("\t" + monitor);
            }
            Console.WriteLine();

            //12. Csökkentsd a legdrágább monitor bruttó árát 10%-kal, írd ki ezt az értéket a képernyőre. 

            Console.WriteLine("12. feladat: ");
            var legdragabbm10 = monitorok
                .Where(m => m.Ara == monitorok.Max(m => m.Ara))
                .First();

            Console.WriteLine($"\tLegdrágább monitornak a bruttó ára, 10%-kal csökkentve : {legdragabbm10.BruttoAra * 0.9} Ft");

            Console.ReadLine();
        }
    }
}
