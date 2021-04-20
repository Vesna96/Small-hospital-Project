using Manja_bolnica.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manja_bolnica.DTO
{
    public class NemedicinskoView
    {
        public string JMBGNemedicinsko { get; set; }

        public string ImeNemedicinsko { get; set; }

        public string PrezimeNemedicinsko { get; set; }

        

        public NemedicinskoView()
        {

        }

        public NemedicinskoView(Nemedicinsko nemed)
        {
            this.JMBGNemedicinsko = nemed.JMBGNemedicinsko;
            this.ImeNemedicinsko = nemed.ImeNemedicinsko;
            this.PrezimeNemedicinsko = nemed.PrezimeNemedicinsko;
            
        }
    }

    public class TehnicarView : NemedicinskoView
    {
        public string Struka { get; set; }

        public TehnicarView()
            : base()
        {

        }

        public TehnicarView(Tehnicar teh)
            : base(teh)
        {
            this.Struka = teh.Struka;
        }
    }

    public class HigijenicarView : NemedicinskoView
    {
        public HigijenicarView()
            : base()
        {

        }

        public HigijenicarView(Higijenicar hig)
            : base(hig)
        {

        }
    }


}
