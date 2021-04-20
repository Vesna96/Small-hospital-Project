using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manja_bolnica.Entiteti
{
    public class Intervencija
    {
        public virtual int IntervencijaId { get; protected set; }
        public virtual Ambulantno PacijentIntervencija { get; set; }
        public virtual Stomatolog StomatologIntervencija { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual string Vrsta { get; set; }

        public Intervencija()
        {

        }
    }
}
