using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manja_bolnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Manja_bolnica.Mapiranja
{
    class RadiNaMapiranja : ClassMap<Manja_bolnica.Entiteti.RadiNa>
    {
        public RadiNaMapiranja()
        {
            Table("RADI_NA");

            Id(x => x.RadiId, "RADI_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Smena, "SMENA");
            Map(x => x.DatumOd, "DATUM_OD");
            Map(x => x.DatumDo, "DATUM_DO");

            References(x => x.RadiNaStolica).Column("STOLICARADI").LazyLoad();
            References(x => x.RadiNaStomatolog).Column("STOMATOLOGRADI").LazyLoad();
        }
    }
}
