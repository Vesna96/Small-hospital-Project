using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manja_bolnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Manja_bolnica.Mapiranja
{
    class LeziNaMapiranja : ClassMap<Manja_bolnica.Entiteti.LeziNa>
    {
        public LeziNaMapiranja()
        {
            Table("LEZI_NA");

            Id(x => x.LeziId, "LEZI_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.DatumPrijema, "DATUM_PRIJEMA");
            Map(x => x.DatumOtpusta, "DATUM_OTPUSTA");

            References(x => x.PacijentLezi).Column("PACIJENTLEZI").LazyLoad();
            References(x => x.OdeljenjeLezi).Column("ODELJENJELEZI").LazyLoad();
        }
    }
}
