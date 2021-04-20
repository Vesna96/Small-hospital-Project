using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manja_bolnica.Entiteti
{
    public abstract class Nemedicinsko
    {
        public virtual string JMBGNemedicinsko { get; set; }

        public virtual string ImeNemedicinsko { get; set; }

        public virtual string PrezimeNemedicinsko { get; set; }

        public virtual string TipNemedicinsko { get; set; }

        public Nemedicinsko()
        {

        }
    }
    public class Tehnicar : Nemedicinsko
    {
        public virtual string Struka { get; set; }
        // public virtual IList<Pacijent> Pacijenti { get; set; }
        public virtual IList<Stolica> Stolice { get; set; }
        public Tehnicar()
        {
            //Pacijenti = new List<Pacijent>();
            Stolice = new List<Stolica>();
        }
    }
    public class Higijenicar : Nemedicinsko
    {
        
        public virtual IList<Odrzava> Odeljenja { get; set; }
        public Higijenicar()
        {
            Odeljenja = new List<Odrzava>();
        }
    }

}
