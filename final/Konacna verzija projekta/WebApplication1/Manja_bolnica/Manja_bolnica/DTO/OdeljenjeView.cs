using Manja_bolnica.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manja_bolnica.DTO
{
    public class OdeljenjeView
    {
        public int Sifra { get; set; }
        public string Tip { get; set; }
        public DateTime DatumIzgradnje { get; set; }


        public OdeljenjeView()
        {

        }

        public OdeljenjeView(Odeljenje od)
        {
            this.Sifra = od.Sifra;
            this.Tip = od.Tip;
            this.DatumIzgradnje = od.DatumIzgradnje;
        }
    }
}
