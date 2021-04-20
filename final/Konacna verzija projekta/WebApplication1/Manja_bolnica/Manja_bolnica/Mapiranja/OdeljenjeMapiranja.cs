using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manja_bolnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Manja_bolnica.Mapiranja
{
    class OdeljenjeMapiranja: ClassMap<Manja_bolnica.Entiteti.Odeljenje>
    {
        public OdeljenjeMapiranja()
        {

        Table("ODELJENJE");

            Id(x => x.Sifra, "SIFRA").GeneratedBy.TriggerIdentity();


            Map(x => x.Tip, "TIP");
            Map(x => x.DatumIzgradnje, "DATUM_IZGRADNJE");

            References(x => x.DodeljeniSpecijalista).Column("SPECIJALISTA").LazyLoad();
            HasMany(x => x.LeziNaStacionarni).KeyColumn("ODELJENJELEZI").LazyLoad().Cascade.All();//.Inverse(); 
             
            HasMany(x => x.Higijenicari).KeyColumn("ODELJENJEODRZAVA").LazyLoad().Cascade.All().Inverse();
        }
    }
}

