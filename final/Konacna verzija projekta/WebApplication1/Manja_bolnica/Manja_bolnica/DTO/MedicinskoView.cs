using Manja_bolnica.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manja_bolnica.DTO
{
    public class MedicinskoView
    {
        public string JMBGMedicinsko { get; set; }

        public string ImeMedicinsko { get; set; }

        public string PrezimeMedicinsko { get; set; }
        public int RadniStaz { get; set; }

       

        public MedicinskoView()
        {

        }

        public MedicinskoView(Medicinsko med)
        {
            this.JMBGMedicinsko = med.JMBGMedicinsko;
            this.ImeMedicinsko = med.ImeMedicinsko;
            this.PrezimeMedicinsko = med.PrezimeMedicinsko;
            this.RadniStaz = med.RadniStaz;
           
        }

    }

    public class LekarView : MedicinskoView
    {
        public int BrojOrdinacije { get; set; }

        public LekarView()
            : base()
        {

        }

        public LekarView(Lekar lek)
            : base(lek)
        {
            this.BrojOrdinacije = lek.BrojOrdinacije;
        }
    }

    public class SpecijalistaView : MedicinskoView
    {
        public string Specijalnost { get; set; }

        public SpecijalistaView()
            : base()
        {

        }

        public SpecijalistaView(Specijalista sp)
            : base(sp)
        {
            this.Specijalnost = sp.Specijalnost;
        }
    }

    public class StomatologView : MedicinskoView
    {
        public StomatologView()
            : base()
        {

        }

        public StomatologView(Stomatolog st)
            : base(st)
        {

        }
    }
}
