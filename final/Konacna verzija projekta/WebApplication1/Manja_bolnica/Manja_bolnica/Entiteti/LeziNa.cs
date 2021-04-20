using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manja_bolnica.Entiteti
{
    public class LeziNa
    {
        public virtual int LeziId { get; protected set; }
        public virtual Stacionarno PacijentLezi { get; set; }
        public virtual Odeljenje OdeljenjeLezi { get; set; }
        public virtual DateTime DatumOtpusta { get; set; }
        public virtual DateTime DatumPrijema { get; set; } 
        public LeziNa()
        {

        }
    }
}
