using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            {
                kutyaNevek.Add(new KutyaNév(sor));
            }

            //3.
            Console.WriteLine($"3. feladat: Kutyanevek száma: {kutyaNevek.Count}");

            //4.
            List<KutyaFajta> kutyaFajták = new List<KutyaFajta>();
            foreach (var sor in File.ReadAllLines("KutyaFajtak.csv").Skip(1))
            {
                kutyaFajták.Add(new KutyaFajta(sor));
            }

            //5.
            List<Kutya> kutyák = new List<Kutya>();
            foreach (var sor in File.ReadAllLines("Kutyak.csv").Skip(1))
            {
                kutyák.Add(new Kutya(sor));
            }

            //6.
            Console.WriteLine($"6. feladat: Kutyák átlag életkora: {kutyák.Average(x => x.Életkor):0.00}");

            //7.
            var k = kutyák.OrderByDescending(x => x.Életkor).First();
            Console.WriteLine(
                $"7. feladat: Legidősebb kutya neve és fajtája: " +
                $"{kutyaNevek.First(x => x.Id == k.NévId).Név}, " +
                $"{kutyaFajták.First(x => x.Id == k.FajtaId).Fajta}");

            //8.
            kutyák.Where(x => x.UtolsóKezelés == DateTime.Parse("2018-01-10"))
                .GroupBy(x => x.FajtaId)
                .Select(gr => new { Fajta = kutyaFajták.First(x => x.Id == gr.Key).Fajta, db = gr.Count() })
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Fajta}: {x.db} kutya"));

            //9.
            var s = kutyák.GroupBy(x => x.UtolsóKezelés)
                .Select(gr => new { Dátum = gr.Key, db = gr.Count() })
                .OrderBy(x => x.db).Last();
            Console.WriteLine($"9. feladat: Legjobban leterhelt nap: {s.Dátum.ToString("yyyy.MM.dd.")}: {s.db} kutya");

            Console.ReadKey();
        }
    }
}
