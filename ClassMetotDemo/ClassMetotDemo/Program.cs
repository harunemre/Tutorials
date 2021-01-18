using ClassMetotDemo.Manager;
using ClassMetotDemo.Model;
using System;
using System.Linq;

namespace ClassMetotDemo
{
    internal class Program
    {
        private static readonly MusteriManager _musteriManager = new MusteriManager();

        private static void Main(string[] args)
        {            
            GenerateRandomMusteriler();
            Random rnd = new Random();
            var rastgele = rnd.Next(1, 11);
            LogToConsole($"Rastgele bir sayı üretildi ({rastgele})");
            var rastgeleMusteri = _musteriManager.GetById(rastgele);
            LogToConsole($"Rastgele bir müşteri bulundu.\tAdı = {rastgeleMusteri.Ad}");
            // normalde referans türlerde yapılan herhangi bir değişiklik doğrudan o değişkeni update edeceğinden
            // update metodunu simüle etmek için aynı özelliklere sahip sadece adının güncellendiğini gösteren yeni bir nesne türetildi
            var updateEdilecekMusteri = new Musteri
            {
                Id = rastgeleMusteri.Id,
                Ad = "unknown",
                Soyad = rastgeleMusteri.Soyad,
                Eposta = rastgeleMusteri.Eposta,
                Il = rastgeleMusteri.Il,
                Ilce = rastgeleMusteri.Ilce,
                Telefon = rastgeleMusteri.Telefon
            };

            _musteriManager.Update(updateEdilecekMusteri);
            LogToConsole($"Adı = {rastgeleMusteri.Ad} olan müşterinin yeni adı = unknown olarak değiştirildi");

            rastgeleMusteri = _musteriManager.GetById(rastgele);
            LogToConsole($"Güncellendikten sonraki listeden tekrar çekilen aynı müşterinin adı = {rastgeleMusteri.Ad}");

            LogToConsole($"Silme işleminden önce listedeki kayıt sayısı = {_musteriManager.GetCount()}");
            _musteriManager.Delete(rastgeleMusteri);
            LogToConsole($"Silme işleminden sonra listedeki kayıt sayısı = {_musteriManager.GetCount()}");
            _musteriManager.Add(updateEdilecekMusteri);
            LogToConsole($"Silinen müşteri tekrar eklendi. Şuanki kayıt sayısı = {_musteriManager.GetCount()}");
            var musteriListe = _musteriManager.GetAll();

            Console.WriteLine("**********************************************");
            Console.WriteLine("Tüm müşterilerin listelenmesi için herhangi bir tuşa basın..");
            Console.ReadKey();

            for (int i = 0; i < musteriListe.Count(); i++)
            {
                var musteri = musteriListe.ElementAt(i);
                Console.WriteLine($"{i+1}. müşterinin");
                Console.WriteLine($"Id si = {musteri.Id}");
                Console.WriteLine($"Adı = {musteri.Ad}");
                Console.WriteLine($"Soyadı = {musteri.Soyad}");
                Console.WriteLine($"İli = {musteri.Il}");
                Console.WriteLine($"İlçesi = {musteri.Ilce}");
                Console.WriteLine($"Epostası = {musteri.Eposta}");
                Console.WriteLine($"Telefonu = {musteri.Telefon}");
                Console.WriteLine("----------------------------------");
            }

            Console.ReadKey();
        }

        private static void GenerateRandomMusteriler()
        {
            var musteri1 = new Musteri
            {
                Id = Guid.Parse("01B3BA1D-75C2-4E9A-9C14-D18A16B0CF5C"),
                Ad = "Tezkan",
                Soyad = "Samsa",
                Il = "Bursa",
                Ilce = "Nilüfer",
                Eposta = "Donec@tortor.su",
                Telefon = "0755 937 58 74"
            };

            var musteri2 = new Musteri
            {
                Id = Guid.Parse("E0946300-2906-43A9-AC0E-44505D962B52"),
                Ad = "İlkehan",
                Soyad = "Daldal",
                Il = "Bingöl",
                Ilce = "Gönen",
                Eposta = "ut@odio.se",
                Telefon = "0530 435 62 85"
            };

            var musteri3 = new Musteri
            {
                Id = Guid.Parse("BEE5CF65-38F2-4111-AE6D-298AC06648AA"),
                Ad = "Uram",
                Soyad = "Yakar",
                Il = "Eskişehir",
                Ilce = "Foça",
                Eposta = "Donec@metus.aw",
                Telefon = "0569 607 61 63"
            };

            var musteri4 = new Musteri
            {
                Id = Guid.Parse("8B2C955E-C1AA-4032-B121-957BA45009A1"),
                Ad = "İz",
                Soyad = "Yetişen",
                Il = "Uşak",
                Ilce = "Şarkikaraağaç",
                Eposta = "nunc@convallis.bt",
                Telefon = "0237 673 94 07"
            };

            var musteri5 = new Musteri
            {
                Id = Guid.Parse("BF913815-B09F-4B82-8893-370ED9792C0C"),
                Ad = "Şenay",
                Soyad = "Gövercin",
                Il = "Muğla",
                Ilce = "Yayladağı",
                Eposta = "non@amet.om",
                Telefon = "0967 408 85 05"
            };

            var musteri6 = new Musteri
            {
                Id = Guid.Parse("8EF02BA5-B41F-4F1F-80C0-8DE8D13B0085"),
                Ad = "Remziye",
                Soyad = "Bilhan",
                Il = "Şırnak",
                Ilce = "Ağın",
                Eposta = "et@dictum.at",
                Telefon = "0231 353 99 35"
            };

            var musteri7 = new Musteri
            {
                Id = Guid.Parse("09487CCC-F1EE-4C81-8116-1468C16EC325"),
                Ad = "Handegül",
                Soyad = "Celiloğlu",
                Il = "Malatya",
                Ilce = "Taraklı",
                Eposta = "consectetur@neque.am",
                Telefon = "0778 799 46 81"
            };

            var musteri8 = new Musteri
            {
                Id = Guid.Parse("A422D003-B227-4378-B990-1F31CE8D6952"),
                Ad = "Arıer",
                Soyad = "Sayıner aydoğan",
                Il = "Yozgat",
                Ilce = "Avcılar",
                Eposta = "arcu@hendrerit.hm",
                Telefon = "0201 950 73 04"
            };

            var musteri9 = new Musteri
            {
                Id = Guid.Parse("1C49285A-8FA4-4BD2-8639-A3B640103FFE"),
                Ad = "Azameddin",
                Soyad = "Keçeli",
                Il = "Ağrı",
                Ilce = "Yenipazar",
                Eposta = "Integer@magna.mr",
                Telefon = "0231 708 37 57"
            };

            var musteri10 = new Musteri
            {
                Id = Guid.Parse("44493964-25C8-4A27-B73C-21ED4463803F"),
                Ad = "Merdüm",
                Soyad = "Ermiş",
                Il = "Kastamonu",
                Ilce = "Çaycuma",
                Eposta = "nunc@dignissim.si",
                Telefon = "0461 632 75 06"
            };
            
            _musteriManager.Add(musteri1);
            _musteriManager.Add(musteri2);
            _musteriManager.Add(musteri3);
            _musteriManager.Add(musteri4);
            _musteriManager.Add(musteri5);
            _musteriManager.Add(musteri6);
            _musteriManager.Add(musteri7);
            _musteriManager.Add(musteri8);
            _musteriManager.Add(musteri9);
            _musteriManager.Add(musteri10);
            LogToConsole("10 tane müşteri add operasyonuyla eklendi.."); 
        }

        private static void LogToConsole(string message)
        {
            var datetime = DateTime.Now;
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"{datetime:G}\tBİLGİ\t{message}");
        }
    }
}