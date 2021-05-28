using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyák
{
    class KutyaFajta
    {
        public int Id { get; set; }
        public string Név { get; set; }
        public string EredetiNév { get; set; }

        public KutyaFajta(string sor)
        {
            string[] s = sor.Split(';');
            Id = int.Parse(s[0]);
            Név = s[1];
            EredetiNév = s[2];
        }
    }
}
