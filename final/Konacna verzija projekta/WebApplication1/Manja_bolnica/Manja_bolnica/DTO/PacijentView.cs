using Manja_bolnica.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manja_bolnica.DTO
{
    public class PacijentView
    {
        public string JMBGPacijenta { get; set; }
        public string ImePacijenta { get; set; }
        public string PrezimePacijenta { get; set; }
       

        public PacijentView()
        {

        }

        public PacijentView(Pacijent p)
        {
            this.JMBGPacijenta = p.JMBGPacijenta;
            this.ImePacijenta = p.ImePacijenta;
            this.PrezimePacijenta = p.PrezimePacijenta;
          


        }
    }

    public class StacionarniView : PacijentView
    {
        public StacionarniView()
            : base()
        {

        }
        public StacionarniView(Stacionarno st)
            : base(st)
        {

        }
    }
    public class AmbulantniView : PacijentView
    {
        public string Ulica { get; set; }
        public int Broj { get; set; }

        public AmbulantniView()
            : base()
        {

        }
        public AmbulantniView(Ambulantno am)
            : base(am)
        {
            this.Ulica = am.Ulica;
            this.Broj = am.Broj;
        }
    }
}
