using System;
using System.Collections.Generic;
using System.Text;

namespace CA231003
{
    class Monitor
    {
        public string Gyarto { get; set; }
        public string Tipus { get; set; }
        public double Meret { get; set; }
        public int Ara { get; set; }
        public bool Gamer { get; set; }
        public double BruttoAra { get; set; }
        public int RaktaronDB { get; set; }

        const double AfaSzazalekba = 1.27; // (27% az Áfa)

        public Monitor(string sor)
        {
            var atmeneti = sor.Split(';');
            this.Gyarto = atmeneti[0];
            this.Tipus = atmeneti[1];
            this.Meret = double.Parse(atmeneti[2]);
            this.Ara = int.Parse(atmeneti[3]);

            if (atmeneti.Length > 4)
                this.Gamer = true;
            else
                this.Gamer = false;

            this.BruttoAra = Ara * AfaSzazalekba;
            this.RaktaronDB = 15;
        }

        //Gyártó: Samsung; Típus: S24D330H; Méret: 24 col; Nettó ár: 33000 Ft 

        public override string ToString()
        {
            return $"Gyártó: {this.Gyarto}; Típus: {this.Tipus}; Méret {this.Meret} col; Nettó ár: {this.Ara} Ft";
        }
    }
}
