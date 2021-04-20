using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manja_bolnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Manja_bolnica.Mapiranja
{
    class NemedicinskoMapiranja : ClassMap<Manja_bolnica.Entiteti.Nemedicinsko>
    {
        public NemedicinskoMapiranja()
        {
            Table("NEMEDICINSKO");

            //Id(x => x.JMBGNemedicinsko, "JMBG_Nemedicinsko");

            Map(x => x.ImeNemedicinsko, "Ime_Nemedicinsko");
            Map(x => x.PrezimeNemedicinsko, "Prezime_Nemedicinsko");
            Map(x => x.FHigijenicar, "FHigijenicar");
            Map(x => x.FTehnicar, "FTehnicar");
            Map(x => x.Struka, "Struka");
           
        }
    }
}
