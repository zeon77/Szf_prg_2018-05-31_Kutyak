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

            Console.ReadKey();
        }
    }
}
