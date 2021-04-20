using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Manja_bolnica.Entiteti
{
    public abstract class Medicinsko
    {
        public virtual string JMBGMedicinsko { get; set; }
   
        public virtual  string ImeMedicinsko { get; set; }

        public virtual string PrezimeMedicinsko { get; set; }
        public virtual int RadniStaz { get; set; }

        public virtual string TipMedicinsko { get; set; }


        
        public Medicinsko()
        {

        }

    }
    public class Lekar : Medicinsko
    {
        public virtual int BrojOrdinacije { get; set; }
        public virtual IList<Pacijent> Pacijenti { get; set; }
        public Lekar()
        {
            Pacijenti = new List<Pacijent>();
        }
    }
    public class Specijalista : Medicinsko
    {
        public virtual string Specijalnost { get; set; }
        public virtual IList<Odeljenje> Odeljenja { get; set; }
        public Specijalista()
        {
            Odeljenja = new List<Odeljenje>();
        }
    }
    public class Stomatolog : Medicinsko
    {
        public virtual IList<Intervencija> IntervencijeStomatolog { get; set; }

        public virtual IList<RadiNa> Stolice  { get; set; }
        public Stomatolog()
        {
            IntervencijeStomatolog = new List<Intervencija>();

            Stolice = new List<RadiNa>();
        }
    }

}
