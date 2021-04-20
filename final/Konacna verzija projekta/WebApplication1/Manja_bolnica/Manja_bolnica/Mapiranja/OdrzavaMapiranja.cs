using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manja_bolnica.Entiteti;
using FluentNHibernate.Mapping;


namespace Manja_bolnica.Mapiranja
{
    class OdrzavaMapiranja : ClassMap<Manja_bolnica.Entiteti.Odrzava>
    {
        public OdrzavaMapiranja()
        {
            Table("ODRZAVA");

            Id(x => x.OdrzavaId, "ODRZAVA_ID").GeneratedBy.TriggerIdentity();

            References(x => x.OdeljenjeOdrzava).Column("ODELJENJEODRZAVA").LazyLoad();
            References(x => x.JMBGHigijenicara).Column("JMBG_HIGIJENICARA").LazyLoad();
        }
    }
}
