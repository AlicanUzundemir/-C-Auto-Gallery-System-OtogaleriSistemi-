using System;
using System.Collections.Generic;
using System.Text;

namespace OtoGaleriG012
{
    class Galeri
    {
        public List<Araba> Arabalar = new List<Araba>();



        public int ToplamAracSayisi
        {
            get
            {
                return this.Arabalar.Count;
            }
        }
        public int KiradakiAracSayisi
        {
            get
            {
                int sayac = 0;
                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum == DURUM.Kirada)
                    {
                        sayac++;
                    }
                }
                return sayac;
            }
        }
        public int GaleridekiAracSayisi
        {
            get
            {
                int sayac = 0;
                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum == DURUM.Galeride)
                    {
                        sayac++;
                    }
                }
                return sayac;
            }
        } //KiradakiAracSayisi'ndaki gibi düzenlenecek



        public int ToplamAracKiralanmaSuresi
        {
            get
            {
                int toplam = 0;
                foreach (Araba item in this.Arabalar)
                {
                    toplam += item.ToplamKiralanmaSuresi;

                }
                return toplam;
            }
        }
        public int ToplamAracKiralanmaAdedi
        {
            get
            {
                int toplam = 0;
                foreach (Araba item in this.Arabalar)
                {
                    toplam += item.ToplamKiralanmaAdedi;

                }
                return toplam;
            }
        }

        public float Ciro
        {
            get
            {
                float toplam = 0;
                foreach (Araba item in this.Arabalar)
                {
                    toplam += (float)item.ToplamKiralanmaSuresi*item.KiralamaBedeli;

                }
                return toplam;
            }
        }



        public void ArabaKirala(string plaka, int sure)
        {
            foreach (Araba item in this.Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    item.Durum = DURUM.Kirada;
                    item.KiralanmaSureleri.Add(sure);


                }
            }

        }

        public void ArabaTeslimAl(string plaka)
        {
            foreach (Araba item in this.Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    item.Durum = DURUM.Galeride;



                }
            }
        }

    }
}
