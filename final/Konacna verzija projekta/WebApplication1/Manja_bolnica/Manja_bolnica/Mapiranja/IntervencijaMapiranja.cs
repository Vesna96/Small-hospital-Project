using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manja_bolnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Manja_bolnica.Mapiranja
{
    class IntervencijaMapiranja : ClassMap<Manja_bolnica.Entiteti.Intervencija>
    {
        public IntervencijaMapiranja()
        {
            Table("INTERVENCIJA");

            Id(x => x.IntervencijaId, "INTERVENCIJA_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Datum, "DATUM");
            Map(x => x.Vrsta, "VRSTA");

            References(x => x.PacijentIntervencija).Column("PACIJENTINTERVENCIJA").LazyLoad();
            References(x => x.StomatologIntervencija).Column("STOMATOLOGINTERVENCIJA").LazyLoad();
        }
    }
}
