using Manja_bolnica;
using Manja_bolnica.DTO;
using Manja_bolnica.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class SpecijalistaController : ApiController
    {
        public IList<SpecijalistaView> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetSpecijalistiView();
        }

        //GET api/Lekar?jmbg=3333333333333
        public SpecijalistaView Get(string jmbg)
        {
            DataProvider provider = new DataProvider();

            return provider.GetSpecijalistaView(jmbg);
        }

        public int Post([FromBody] Specijalista sp)
        {
            DataProvider provider = new DataProvider();
            return provider.AddSpecijalista(sp);
        }

        public int  Put(string jmbg, [FromBody]Specijalista sp)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateSpecijalista(jmbg, sp);
        }
    }
}
