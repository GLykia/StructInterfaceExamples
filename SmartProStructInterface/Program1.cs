using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractOrnek
{

    // struct -- interface
    interface ISmartpro
    {
        string Ad { get; set; }
        string Soyad { get; set; }
        int telNo { get; set; }
        double boy { get; set; }
        double kilo { get; set; }

        // Method tanımlamaları bildiğimizin dışında eski tip değişken gibi tanımlanır ancak () eklenir.
        void DegerleriAlVeYaz();
    }

    abstract class Yonetim
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int telNo { get; set; }
        public double boy { get; set; }
        public double kilo { get; set; }

        public abstract void BilgileriAlVeYaz();
        public abstract double Endeks(double b, double k);
    }

    struct Ogrenciler : ISmartpro // struct ---- interface class
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int portalNo { get; set; }
        public int telNo { get; set; }
        public double not1 { get; set; }
        public double not2 { get; set; }
        public double boy { get; set; }
        public double kilo { get; set; }
        public int OgrenciUzunlugu { get; set; }


        public Ogrenciler[] ogrenciler;
        public void DegerleriAlVeYaz()
        {
            Console.Write("Kaç öğrenci var: ");
            OgrenciUzunlugu = int.Parse(Console.ReadLine());
            ogrenciler = new Ogrenciler[OgrenciUzunlugu];
            for (int x = 0; x < ogrenciler.Length; x++)
            {
                try
                {
                    Console.WriteLine((x + 1) + ". Öğrencinin bilgilerini girin\n");
                    Console.Write("Ad: ");
                    ogrenciler[x].Ad = Console.ReadLine();
                    Console.Write("Soyad: ");
                    ogrenciler[x].Soyad = Console.ReadLine();
                    Console.Write("Portal No: ");
                    ogrenciler[x].portalNo = int.Parse(Console.ReadLine());
                    Console.Write("Telefon No: ");
                    ogrenciler[x].telNo = int.Parse(Console.ReadLine());
                    Console.Write("1. Not: ");
                    ogrenciler[x].not1 = double.Parse(Console.ReadLine());
                    Console.Write("2. Not: ");
                    ogrenciler[x].not2 = double.Parse(Console.ReadLine());
                    Console.Write("Boy: ");
                    ogrenciler[x].boy = double.Parse(Console.ReadLine());
                    Console.Write("Kilo: ");
                    ogrenciler[x].kilo = double.Parse(Console.ReadLine());
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Değişken türünden uzun değer girdin.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Hatalı değer türü girdin.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Bir şey oldu.");
                }
            }

            int sayac = 1;
            foreach (var item in ogrenciler)
            {
                Console.WriteLine(sayac + ". öğrencinin bilgileri\n");
                Console.Write("Ad: " + item.Ad + " Soyad: " + item.Soyad + " Portal No: " + item.portalNo + " Telefon No: " + item.telNo + " 1. Not: " + item.not1 + " 2. Not: " + item.not2 + " Boy: " + item.boy + " Kilo: " + item.kilo + " ");
                Console.WriteLine("Ortalama: " + Ortalama(item.not2, item.not2));
                Console.WriteLine("Vücut Endeks: " + Endeks(item.boy, item.kilo));
                sayac++;
            }
        }

        public double Ortalama(double n1, double n2)
        {
            return (n1 + n2) / 2;
        }

        public double Endeks(double b, double k)
        {
            return k / (b / 100 * 2);
        }
    }

    struct Egitmenler : ISmartpro
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int portalNo { get; set; }
        public int telNo { get; set; }
        public double boy { get; set; }
        public double kilo { get; set; }
        Egitmenler[] egitmenler;
        public void DegerleriAlVeYaz()
        {
            try
            {
                Console.WriteLine();
                egitmenler = new Egitmenler[2];

                for (int i = 0; i < egitmenler.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". egitmen bilgilerini girin");
                    Console.Write("Eğitmen adı: ");
                    egitmenler[i].Ad = Console.ReadLine();
                    Console.Write("Eğitmen soyadı: ");
                    egitmenler[i].Soyad = Console.ReadLine();
                    Console.Write("Portal No: ");
                    egitmenler[i].portalNo = int.Parse(Console.ReadLine());
                    Console.Write("Telefon No: ");
                    egitmenler[i].telNo = int.Parse(Console.ReadLine());
                    Console.Write("Boy: ");
                    egitmenler[i].boy = double.Parse(Console.ReadLine());
                    Console.Write("Kilo: ");
                    egitmenler[i].kilo = double.Parse(Console.ReadLine());
                }
                int sayac = 1;
                foreach (var item in egitmenler)
                {
                    Console.WriteLine((sayac) + ". Eğitmenin Bilgileri");
                    Console.Write("Adı: " + item.Ad + " Soyadı: " + item.Soyad + " Portal No: " + item.portalNo + " Telefon No: " + item.telNo + " Boy: " + item.boy + " Kilo: " + item.kilo + " Vücut Endeksi: " + Endeks(item.boy, item.kilo) + "\n");
                    sayac++;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Değişken türünden uzun değer girdin.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Hatalı değer türü girdin.");
            }
            catch (Exception)
            {
                Console.WriteLine("Bir şey oldu.");
            }
        }
        public double Endeks(double b, double k)
        {
            return k / (b / 100 * 2);
        }
    }

    class YonetimiAl : Yonetim
    {
        public override void BilgileriAlVeYaz()
        {
            do
            {
                try
                {
                    Console.Write("Adı: ");
                    Ad = Console.ReadLine();
                    Console.Write("Soyadı: ");
                    Soyad = Console.ReadLine();
                    Console.Write("Telefon No: ");
                    telNo = int.Parse(Console.ReadLine());
                    Console.Write("Boy: ");
                    boy = double.Parse(Console.ReadLine());
                    Console.Write("Kilo: ");
                    kilo = double.Parse(Console.ReadLine());
                    break;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Değişken türünden uzun değer girdin.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Hatalı değer türü girdin.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Bir şey oldu.");
                }
            } while (true);


            Console.WriteLine("Adı: " + Ad + " Soyadı: " + Soyad + " Telefon No: " + telNo + " Boy: " + boy + " Kilo: " + kilo + " Vücut Endekse: " + Endeks(boy,kilo));
        }

        public override double Endeks(double b, double k)
        {
            return k / (b / 100 * 2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Ogrenciler ogrenciler = new Ogrenciler();
            ogrenciler.DegerleriAlVeYaz();

            Egitmenler egitmenler = new Egitmenler();
            egitmenler.DegerleriAlVeYaz();

            YonetimiAl yonetim = new YonetimiAl();
            yonetim.BilgileriAlVeYaz();
        }
    }
}
