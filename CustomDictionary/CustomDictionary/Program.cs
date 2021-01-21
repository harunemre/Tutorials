using System;

namespace CustomDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<string, double> kurDictionary = new MyDictionary<string, double>();
            kurDictionary.Add("Dolar", 7.37);
            kurDictionary.Add("Euro", 8.95);
            kurDictionary.Add("İngiliz Sterlini", 10.11);
            kurDictionary.Add("Kanada Doları", 5.83);
            kurDictionary.Add("Danimarka Kronu", 1.20);
            Console.WriteLine(kurDictionary.Count);
        }
    }
}
