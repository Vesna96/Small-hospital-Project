using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manja_bolnica.Entiteti
{
    public class Odrzava
    {
        public virtual Higijenicar JMBGHigijenicara { get; set; }
        public virtual Odeljenje OdeljenjeOdrzava { get; set; }
        public virtual int OdrzavaId { get; protected set; }

        public Odrzava()
        {

        }
    }
}
