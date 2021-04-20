using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manja_bolnica.Entiteti;
using FluentNHibernate.Mapping;

namespace Manja_bolnica.Mapiranja
{
    class MedicinskoMapiranja :  ClassMap<Manja_bolnica.Entiteti.Medicinsko>
    {
        public MedicinskoMapiranja()
        {
            Table("MEDICINSKO");

            DiscriminateSubClassesOnColumn("TIP_MEDICINSKO");

            //KeyColumn("JMBG_Medicinsko");
            Id(x => x.JMBGMedicinsko, "JMBG_MEDICINSKO").GeneratedBy.Assigned();


            Map(x => x.ImeMedicinsko, "IME_MEDICINSKO");
            Map(x => x.PrezimeMedicinsko, "PREZIME_MEDICINSKO");
            Map(x => x.RadniStaz, "RADNI_STAZ");

            
        }
    }
    class LekarMapiranja : SubclassMap<Lekar>
    {
        public LekarMapiranja()
        {
            Map(x => x.BrojOrdinacije, "BROJ_ORDINACIJE");
            DiscriminatorValue("lekar");
            HasMany(x => x.Pacijenti).KeyColumn("LEKAR").LazyLoad().Cascade.All();//.Inverse();
        }
    }
    class SpecijalistaMapiranja : SubclassMap<Specijalista>
    {
        public SpecijalistaMapiranja()
        {
            Map(x => x.Specijalnost, "SPECIJALNOST");
            DiscriminatorValue("specijalista");
            HasMany(x => x.Odeljenja).KeyColumn("SPECIJALISTA").LazyLoad().Cascade.All();//.Inverse();
        }
    }
    class StomatologMapiranja : SubclassMap<Stomatolog>
    {
        public StomatologMapiranja()
        {
            DiscriminatorValue("stomatolog");
            HasMany(x => x.IntervencijeStomatolog).KeyColumn("STOMATOLOGINTERVENCIJA").LazyLoad().Cascade.All();//.Inverse();
            HasMany(x => x.Stolice).KeyColumn("STOMATOLOGRADI").LazyLoad().Cascade.All().Inverse();
        }
    }
}
