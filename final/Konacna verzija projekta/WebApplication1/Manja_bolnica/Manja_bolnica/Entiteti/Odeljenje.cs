using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manja_bolnica.Entiteti
{
    public class Odeljenje
    {
        public virtual int Sifra { get; protected set; }

        public virtual string Tip { get; set; }

        public virtual DateTime DatumIzgradnje { get; set; }
        //public virtual string Specijalista { get; set; }

        public virtual Specijalista DodeljeniSpecijalista { get; set; }
        public virtual IList<LeziNa> LeziNaStacionarni { get; set; }
        public virtual IList<Odrzava> Higijenicari{ get; set; }

        //public virtual IList<Stacionarno> Stacionarni { get; set; }
        public Odeljenje()
        {
            LeziNaStacionarni = new List<LeziNa>();

            Higijenicari = new List<Odrzava>();
            //Stacionarni = new List<Stacionarno>();
        }
    }
}
