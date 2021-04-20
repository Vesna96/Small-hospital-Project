using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manja_bolnica.Entiteti;
using FluentNHibernate.Mapping;


namespace Manja_bolnica.Mapiranja
{
        class NemedicinskoMapiranje : ClassMap<Manja_bolnica.Entiteti.Nemedicinsko>
        {
            public NemedicinskoMapiranje()
            {
                Table("NEMEDICINSKO");

                DiscriminateSubClassesOnColumn("TIP_NEMEDICINSKO");

                //KeyColumn("JMBG_Medicinsko");
                Id(x => x.JMBGNemedicinsko, "JMBG_NEMEDICINSKO").GeneratedBy.Assigned();


                Map(x => x.ImeNemedicinsko, "IME_NEMEDICINSKO");
                Map(x => x.PrezimeNemedicinsko, "PREZIME_NEMEDICINSKO");


            }
        }
        class TehnicarMapiranja : SubclassMap<Tehnicar>
        {
            public TehnicarMapiranja()
            {
                Map(x => x.Struka, "STRUKA");
                DiscriminatorValue("tehnicar");
                //HasMany(x => x.Pacijenti).KeyColumn("LEKAR").LazyLoad().Cascade.All();//.Inverse();
                HasMany(x => x.Stolice).KeyColumn("TEHNICAR").LazyLoad().Cascade.All().Inverse();
        }
        }
        class HigijenicarMapiranja : SubclassMap<Higijenicar>
        {
            public HigijenicarMapiranja()
            {
                DiscriminatorValue("higijenicar");
                HasMany(x => x.Odeljenja).KeyColumn("JMBG_HIGIJENICARA").LazyLoad().Cascade.All().Inverse();
        }
        }
        
    }

