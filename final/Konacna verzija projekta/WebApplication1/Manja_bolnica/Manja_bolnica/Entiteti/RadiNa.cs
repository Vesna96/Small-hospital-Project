using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manja_bolnica.Entiteti
{
     public class RadiNa
    {
        public virtual int RadiId { get; protected set; }
        public virtual string Smena { get; set; }
        public virtual DateTime DatumOd { get; set; }
        public virtual DateTime DatumDo { get; set; }

        public virtual Stolica RadiNaStolica { get; set; }

        public virtual Stomatolog RadiNaStomatolog{ get; set; }
        
        public RadiNa()
        {

        }
    }
}
