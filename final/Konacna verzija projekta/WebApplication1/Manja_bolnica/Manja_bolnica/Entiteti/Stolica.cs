using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manja_bolnica.Entiteti
{
    public class Stolica
    {
        public virtual int IdStolice { get; protected set; }

        public virtual string Proizvodjac { get; set; }

        public virtual DateTime DatumProizvodnje { get; set; }

        public virtual Tehnicar DodeljeniTehnicar { get; set; }

        public virtual IList<RadiNa> Stomatolozi { get; set; }
        public Stolica()
        {
            Stomatolozi = new List<RadiNa>();
        }
    }
}
