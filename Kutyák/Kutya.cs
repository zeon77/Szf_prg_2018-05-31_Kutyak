using System;

namespace Kutyák
{
    class Kutya
    {
        public int Id { get; set; }
        public int FajtaId { get; set; }
        public int NévId { get; set; }
        public int Életkor { get; set; }
        public DateTime UtolsóKezelés { get; set; }

        public Kutya(string sor)
        {
            string[] s = sor.Split(';');
            Id = int.Parse(s[0]);
            FajtaId = int.Parse(s[1]);
            NévId = int.Parse(s[2]);
            Életkor = int.Parse(s[3]);
            UtolsóKezelés = DateTime.Parse(s[4]);
        }
    }
}
