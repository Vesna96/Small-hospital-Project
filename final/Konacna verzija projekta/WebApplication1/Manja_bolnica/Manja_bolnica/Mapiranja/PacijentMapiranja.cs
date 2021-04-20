using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manja_bolnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Manja_bolnica.Mapiranja
{
    class PacijentMapiranja : ClassMap<Pacijent>
    {
        public PacijentMapiranja()
        {
            Table("PACIJENT");
            DiscriminateSubClassesOnColumn("TIP_PACIJENT");
            //mapiranje primarnog kljuca
            Id(x => x.JMBGPacijenta, "JMBG_PACIJENTA").GeneratedBy.Assigned();

            //mapiranje svojstava
            Map(x => x.ImePacijenta, "IME_PACIJENTA");
            Map(x => x.PrezimePacijenta, "PREZIME_PACIJENTA");



            //mapiranje veze 1:N Prodavnica-Odeljenje
            References(x => x.IzabraniLekar).Column("LEKAR").LazyLoad();
            
        }
    }
    class StacionarnoMapiranja : SubclassMap<Stacionarno>
    {
        public StacionarnoMapiranja()
        {
           
            DiscriminatorValue("stacionarno");
            //References(x => x.IzabraniLekar).Column("LEKAR").LazyLoad();
            HasMany(x => x.LeziNaOdeljenja).KeyColumn("PACIJENTLEZI").LazyLoad().Cascade.All();//.Inverse();
        }
    }
    class AmbulantnoMapiranja : SubclassMap<Ambulantno>
    {
        public AmbulantnoMapiranja()
        {
            DiscriminatorValue("ambulantno");
            Map(x => x.Ulica, "ULICA");
            Map(x => x.Broj, "BROJ");
            //References(x => x.IzabraniLekar).Column("LEKAR").LazyLoad();
            HasMany(x => x.IntervecijePacijenta).KeyColumn("PACIJENTINTERVENCIJA").LazyLoad().Cascade.All();//.Inverse();

        }
    }
}


