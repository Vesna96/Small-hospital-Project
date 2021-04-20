using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manja_bolnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Manja_bolnica.Mapiranja
{
    class StolicaMapiranja : ClassMap<Stolica>
    {
        public StolicaMapiranja()
        {
            Table("STOLICA");
            //mapiranje primarnog kljuca
            Id(x => x.IdStolice, "ID_STOLICE").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.Proizvodjac, "PROIZVODJAC");
            Map(x => x.DatumProizvodnje, "DATUM_PROIZVODNJE");



            
            References(x => x.DodeljeniTehnicar).Column("TEHNICAR").LazyLoad().Cascade.All();
            HasMany(x => x.Stomatolozi).KeyColumn("STOLICARADI").LazyLoad().Cascade.All().Inverse();
        }
    }
}
