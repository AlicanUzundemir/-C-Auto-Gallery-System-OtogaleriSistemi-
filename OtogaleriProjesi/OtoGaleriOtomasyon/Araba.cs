using System;
using System.Collections.Generic;
using System.Text;

namespace OtoGaleriG012
{
    class Araba
    {
        public string Plaka;
        public string Marka;
        public float KiralamaBedeli;
        public int ToplamKiralanmaSayisi;
        public ARAC_TIPI AracTipi;
        public DURUM Durum;

        public List<int> KiralanmaSureleri = new List<int>();
        public int ToplamKiralanmaSuresi
        {
            get
            {
                int toplamSure = 0;
                foreach (int item in this.KiralanmaSureleri)
                {
                    toplamSure += item;
                }
                return toplamSure;
            }
        }
        public int ToplamKiralanmaAdedi
        {
            get
            {
                return this.KiralanmaSureleri.Count;
            }
        }

        public Araba()
        {

        }


        public Araba(string plaka, string marka, float kiralamaBedeli, ARAC_TIPI aracTipi)
        {
            this.Plaka = plaka.ToUpper();
            this.Marka = marka.ToUpper();
            this.KiralamaBedeli = kiralamaBedeli;
            this.AracTipi = aracTipi;
            this.Durum = DURUM.Galeride;
        }

    }


    public enum DURUM
    {
        Empty,
        Galeride,
        Kirada
    }

    public enum ARAC_TIPI
    {
        Empty,
        Sedan,
        Hatchback,
        SUV
    }

    



}
