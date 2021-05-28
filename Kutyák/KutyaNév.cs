using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyák
{
    class KutyaNév
    {
        public int Id { get; set; }
        public string Név { get; set; }
        
        public KutyaNév(string sor)
        {
            string[] s = sor.Split(';');
            Id = int.Parse(s[0]);
            Név = s[1];
        }
    }
}
