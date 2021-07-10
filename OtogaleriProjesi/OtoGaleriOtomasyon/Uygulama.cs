//   --------------Otogaleri Otomasyonu---------------
//   --------------  Alican Uzundemir  ---------------
using System;
using System.Collections.Generic;
using System.Text;

namespace OtoGaleriG012
{
    class Uygulama
    {
        Galeri OtoGaleri = new Galeri();
        Araba  yeniAraba = new Araba();
        string plka;


        public void Calistir()
        {
            SahteVeriGir();
            //OtoGaleri.ToplamAracSayisi

            Menu();
            while (true)
            {
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine().ToUpper();
                Console.WriteLine();
                switch (secim)
                {
                    case "1":
                    case "K":
                        AracKirala();
                        break;
                    case "2":
                    case "T":
                        AracTeslim();
                        break;
                    case "3":
                    case "R":
                        KiradakiAraclariListele();
                        break;
                    case "4":
                    case "M":
                        MusaitAraclarListele();
                        break;
                    case "5":
                    case "A":
                        ArabalariListele();
                        break;
                    case "6":
                    case "Y":
                        ArabaEkle();
                        break;
                    case "7":
                    case "S":
                        ArabaSil();
                        break;
                    case "8":
                    case "G":
                        BilgileriGoster();
                        break;
                }
                Console.WriteLine();
            }







        }

        public void Menu()
        {

            Console.WriteLine("Galeri Otomasyon");
            Console.WriteLine("1- Araba Kirala (K)");
            Console.WriteLine("2 - Araba Teslim Al(T)");
            Console.WriteLine("3 - Kiradaki arabaları listele(R)");
            Console.WriteLine("4 - Müsait arabaları listele(M)");
            Console.WriteLine("5 - Tüm arabaları listele(A)"); 
            Console.WriteLine("6 - Yeni araba Ekle(Y)");
            Console.WriteLine("7 - Araba sil(S)"); 
            Console.WriteLine("8 - Bilgileri göster(G)");
        }
        

        public void AracKirala()
        {

            
            //Console.WriteLine("Seçim 1 ya da K için: ");
            Console.WriteLine("-Araç Kirala-");
            int sayac = 0;
            while (true)
            {

                string plka = AracIste("Kiralanacak", sayac);
                if (PlakaTuruDogrumu(plka) == true)
                {
                    sayac++;
                    foreach (Araba a in OtoGaleri.Arabalar)
                    {
                        if (a.Plaka == plka)
                        {
                            if (a.Durum == DURUM.Kirada)
                            {
                                Console.WriteLine("Araç müsait değil. Başka bir araç seçin.");
                                sayac = 0;


                            }
                            else if (a.Durum == DURUM.Galeride)
                            {
                                Console.Write("Kiralama süresi: ");

                                int sr = int.Parse(Console.ReadLine());
                                OtoGaleri.ArabaKirala(plka, sr);
                                Console.WriteLine();
                                Console.WriteLine(plka + " plakalı araç " + sr + " saatliğine kiralandı.");
                                sayac = 0;
                                return;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                }

            }

        }

        public void AracTeslim()
        {

            //Console.WriteLine("Seçim 2 ya da T için:");
            Console.WriteLine("-Araç Teslim-");
            int sayac = 0;
            while (true)
            {

                string plka = AracIste("Teslim edilecek", sayac);
                sayac++;
                foreach (Araba a in OtoGaleri.Arabalar)
                {
                    if (a.Plaka == plka)
                    {
                        if (a.Durum == DURUM.Kirada)
                        {

                            OtoGaleri.ArabaTeslimAl(plka);
                            Console.WriteLine();
                            Console.WriteLine("Araç galeride beklemeye alındı.");
                            sayac = 0;
                            return;

                        }
                        else if (a.Durum == DURUM.Galeride)
                        {
                            Console.WriteLine("Hatalı giriş yapıldı. Araç zaten galeride.");

                            sayac = 0;

                        }
                    }


                }
            }

        }

        public void KiradakiAraclariListele()
        {
            Console.WriteLine("Plaka                Marka        Kiralama Bedeli        Araç Tipi           Kiralanma Sayısı         Durum");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

            foreach (Araba item in OtoGaleri.Arabalar)
            {
                if (item.Durum == DURUM.Kirada)
                {
                    Console.WriteLine(item.Plaka.ToUpper().PadRight(21, ' ') + item.Marka.ToUpper().PadRight(13, ' ') + item.KiralamaBedeli.ToString().PadRight(23, ' ') + item.AracTipi.ToString().PadRight(20, ' ') + item.ToplamKiralanmaAdedi.ToString().PadRight(25, ' ') + item.Durum.ToString());
                }

            }
        }

        public void MusaitAraclarListele()
        {
            Console.WriteLine("Plaka                Marka        Kiralama Bedeli        Araç Tipi           Kiralanma Sayısı         Durum");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

            foreach (Araba item in OtoGaleri.Arabalar)
            {
                if (item.Durum == DURUM.Galeride)
                {
                    Console.WriteLine(item.Plaka.ToUpper().PadRight(21, ' ') + item.Marka.ToUpper().PadRight(13, ' ') + item.KiralamaBedeli.ToString().PadRight(23, ' ') + item.AracTipi.ToString().PadRight(20, ' ') + item.ToplamKiralanmaAdedi.ToString().PadRight(25, ' ') + item.Durum.ToString());
                }

            }
        }

        public void ArabalariListele()
        {
            //Console.WriteLine("Seçim 5 ya da A için:");
            //Console.WriteLine("-Tüm araçlar-");

            if (OtoGaleri.Arabalar.Count == 0)
            {
                Console.WriteLine("Galeride araba yok.");
                return;
            }

            Console.WriteLine("Plaka                Marka        Kiralama Bedeli        Araç Tipi           Kiralanma Sayısı         Durum");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

            foreach (Araba item in OtoGaleri.Arabalar)
            {
                Console.WriteLine(item.Plaka.ToUpper().PadRight(21, ' ') + item.Marka.ToUpper().PadRight(13, ' ') + item.KiralamaBedeli.ToString().PadRight(23, ' ') + item.AracTipi.ToString().PadRight(20, ' ') + item.ToplamKiralanmaAdedi.ToString().PadRight(25, ' ') + item.Durum.ToString());
            }


        }

        public void ArabaEkle()

        {
            Araba yeniAraba = new Araba();
            //Console.WriteLine("Seçim 6 ya da Y için: ");
            Console.WriteLine("-Yeni Araç Ekle-");
            bool arabaVar;
            do
            {
                Console.Write("Plaka: ");
                yeniAraba.Plaka = Console.ReadLine().ToUpper();
                arabaVar = ArabaVarMi(yeniAraba.Plaka);
                if (PlakaTuruDogrumu(yeniAraba.Plaka) == true)
                {
                    if (arabaVar == true)
                    {
                        Console.WriteLine("Aynı plakada araç mevcut. Girdiğiniz plakayı kontrol edin.");
                    }
                }
                else
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                }


            } while (arabaVar == true || PlakaTuruDogrumu(yeniAraba.Plaka) == false);


            Console.Write("Marka: ");
            string marka = Console.ReadLine();
            Console.Write("Kiralama Bedeli: ");
            float kiralamaBedeli = int.Parse(Console.ReadLine());
            Console.WriteLine("Araç Tipleri: ");
            Console.WriteLine("- SUV için 1");
            Console.WriteLine("- Hatchback için 2");
            Console.WriteLine("- Sedan için 3");
            Console.Write("Araç Tipi: ");
            string aracTipi = Console.ReadLine();

            switch (aracTipi)
            {
                case "1":
                    yeniAraba.AracTipi = ARAC_TIPI.SUV;
                    break;
                case "2":
                    yeniAraba.AracTipi = ARAC_TIPI.Hatchback;
                    break;
                case "3":
                    yeniAraba.AracTipi = ARAC_TIPI.Sedan;
                    break;
            }

            yeniAraba.Marka = marka;
            yeniAraba.KiralamaBedeli = kiralamaBedeli;
            yeniAraba.Durum = DURUM.Galeride;
            OtoGaleri.Arabalar.Add(yeniAraba);

            Console.WriteLine("Araç başarılı bir şekilde eklendi.");
        }

        public void ArabaSil()
        {
            Console.WriteLine("- Araba Sil -");
            while (true)
            {
                Console.Write("Silinmek istenen araç plakasını girin: ");
                string plaka = Console.ReadLine().ToUpper();
                if (PlakaTuruDogrumu(plaka) == true)
                {
                    if (ArabaVarMi(plaka) == false)
                    {
                        Console.WriteLine("Bu plakaya ait araç bulunmamaktadır.");

                    }
                    else
                    {

                        for (int i = 0; i < OtoGaleri.Arabalar.Count; i++)

                        {

                            Araba arb = OtoGaleri.Arabalar[i];
                            if (arb.Durum == DURUM.Kirada)
                            {
                                Console.WriteLine("Araç kirada olduğu için silinme işlemi yapılamaz.");
                                break;
                            }
                            else
                            {
                                if (arb.Plaka == plaka)
                                {
                                    OtoGaleri.Arabalar.Remove(arb);
                                    Console.WriteLine();
                                    Console.WriteLine("Araç silindi.");
                                    return;

                                }
                            }


                        }

                    }
                }
                else
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                }

            }


        }

        public void BilgileriGoster()
        {

            Console.WriteLine("-Galeri Bilgileri -");
            Console.WriteLine("Toplam Araç Sayısı: " + OtoGaleri.ToplamAracSayisi);
            Console.WriteLine("Kiradaki Araç Sayısı: " + OtoGaleri.KiradakiAracSayisi);
            Console.WriteLine("Galerideki Araç Sayısı: " + OtoGaleri.GaleridekiAracSayisi);
            Console.WriteLine("Toplam araç kiralanma süresi: " + OtoGaleri.ToplamAracKiralanmaSuresi);
            Console.WriteLine("Toplam araç kiralanma adedi: " + OtoGaleri.ToplamAracKiralanmaAdedi);
            Console.WriteLine("Ciro: " + OtoGaleri.Ciro);
        }


        public string AracIste(string ad, int say)
        {


            do
            {
                if (say == 0)
                {
                    Console.Write(ad + " aracın plakası: ");
                    plka = Console.ReadLine().ToUpper();
                    say++;

                }
                else
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                    Console.Write(ad + " aracın plakası: ");
                    plka = Console.ReadLine().ToUpper();
                }
                return plka;


            } while (ArabaVarMi(plka) == false);
        }
        public bool ArabaVarMi(string plk)
        {
            foreach (Araba a in OtoGaleri.Arabalar)
            {
                if (a.Plaka == plk)
                {
                    return true;
                }
            }
            return false;
        }
        public bool PlakaTuruDogrumu(string plk)
        {
            //Baslangicta 2 sayi ortada 2 harf ve sonda 3 sayi olacak sekilde (aralarda bosluk olursada program otomatik kaldircak, yani toplam 7 haneden olusacak)
            int a;

            plk.Replace(" ", "");
            if (plk.Length == 7)
            {
                if (int.TryParse(plk.Substring(0, 2), out a))
                {
                    if (int.TryParse(plk.Substring(2, 2), out a) == false)
                    {
                        if (int.TryParse(plk.Substring(4, 3), out a))
                        {
                            return true;
                        }
                    }

                }
            }

            return false;
        }
        

        public void SahteVeriGir()
        {
            Araba arb1 = new Araba();
            arb1.Plaka = "34US232";
            arb1.AracTipi = ARAC_TIPI.Hatchback;
            arb1.Durum = DURUM.Galeride;
            arb1.Marka = "OPEL";
            arb1.KiralamaBedeli = 50;

            Araba arb2 = new Araba();
            arb2.Plaka = "34AR342";
            arb2.AracTipi = ARAC_TIPI.Sedan;
            arb2.Durum = DURUM.Galeride;
            arb2.Marka = "FIAT";
            arb2.KiralamaBedeli = 70;

            Araba arb3 = new Araba();
            arb3.Plaka = "35AR352";
            arb3.AracTipi = ARAC_TIPI.SUV;
            arb3.Durum = DURUM.Galeride;
            arb3.Marka = "KIA   ";
            arb3.KiralamaBedeli = 60;



            OtoGaleri.Arabalar.Add(arb1);
            OtoGaleri.Arabalar.Add(arb2);
            OtoGaleri.Arabalar.Add(arb3);

       

        }
    }
}
