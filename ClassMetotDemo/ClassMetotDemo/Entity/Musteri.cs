using ClassMetotDemo.Abstract;
using System;

namespace ClassMetotDemo.Model
{
    public class Musteri : IEntity
    {
        public Guid Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
    }
}