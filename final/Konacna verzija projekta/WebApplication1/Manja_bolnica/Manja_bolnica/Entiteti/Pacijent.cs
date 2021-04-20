using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manja_bolnica.Entiteti
{
    public class Pacijent
    {
        public virtual string JMBGPacijenta { get; set; }

        public virtual string ImePacijenta { get; set; }

        public virtual string PrezimePacijenta { get; set; }

        public virtual string TipPacijenta { get; set; }

        //public virtual string Lekar { get; set; }

        public virtual Lekar IzabraniLekar { get; set; }
    }

    public class Stacionarno : Pacijent
    {
        public virtual IList<LeziNa> LeziNaOdeljenja { get; set; }
        //public virtual IList<Odeljenje> Odeljenja { get; set; }
        public Stacionarno()
        {
            LeziNaOdeljenja = new List<LeziNa>();
            //Odeljenja = new List<Odeljenje>();
        }
    }

    public class Ambulantno : Pacijent
    {
        public virtual string Ulica { get; set; }
        public virtual int Broj { get; set; }
        public virtual IList<Intervencija> IntervecijePacijenta {get; set;}
        public Ambulantno()
        {
            IntervecijePacijenta = new List<Intervencija>();
        }
    }
}

