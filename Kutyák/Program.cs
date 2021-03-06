using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Kutyák
{
    class Program
    {
        static void Main(string[] args)
        {
            //2.
            List<KutyaNév> kutyaNevek = new List<KutyaNév>();
            foreach (var sor in File.ReadAllLines("KutyaNevek.csv").Skip(1)) 
                kutyaNevek.Add(new KutyaNév(sor));

            //3.
            Console.WriteLine($"3. feladat: Kutyanevek száma: {kutyaNevek.Count}");

            //4.
            List<KutyaFajta> kutyaFajták = new List<KutyaFajta>();
            foreach (var sor in File.ReadAllLines("KutyaFajtak.csv").Skip(1))
                kutyaFajták.Add(new KutyaFajta(sor));

            //5.
            List<Vizsálat> vizsgálatok = new List<Vizsálat>();
            foreach (var sor in File.ReadAllLines("Kutyak.csv").Skip(1))
                vizsgálatok.Add(new Vizsálat(sor));

            //6.
            Console.WriteLine($"6. feladat: Kutyák átlag életkora: {vizsgálatok.Average(x => x.Életkor):0.00}");

            //7.
            var k = vizsgálatok.OrderByDescending(x => x.Életkor).First();
            Console.WriteLine(
                $"7. feladat: Legidősebb kutya neve és fajtája: " +
                $"{kutyaNevek.First(x => x.Id == k.NévId).Név}, " +
                $"{kutyaFajták.First(x => x.Id == k.FajtaId).Fajta}");

            //8.
            vizsgálatok.Where(x => x.UtolsóKezelés == DateTime.Parse("2018-01-10"))
                .GroupBy(x => x.FajtaId)
                .Select(gr => new { Fajta = kutyaFajták.First(x => x.Id == gr.Key).Fajta, db = gr.Count() })
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Fajta}: {x.db} kutya"));

            //9.
            var s = vizsgálatok.GroupBy(x => x.UtolsóKezelés)
                .Select(gr => new { Dátum = gr.Key, db = gr.Count() })
                .OrderBy(x => x.db).Last();
            Console.WriteLine($"9. feladat: Legjobban leterhelt nap: {s.Dátum.ToString("yyyy.MM.dd.")}: {s.db} kutya");

            //10.
            Console.WriteLine($"10. feladat: névstatisztika.txt");
            string filename = "névstatisztika.txt";
            List<string> list = new List<string>();
            vizsgálatok.GroupBy(x => x.NévId)
                .Select(gr => new { Név = kutyaNevek.First(x => x.Id == gr.Key).Név, db = gr.Count() })
                .OrderByDescending(x => x.db)
                .ToList()
                .ForEach(x => list.Add($"{x.Név};{x.db}"));
            File.WriteAllLines(filename, list);

            Console.ReadKey();
        }
    }
}
