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
    public class StomatologController : ApiController
    {
        public IList<StomatologView> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetStomatoloziView();
        }

        //GET api/Lekar?jmbg=3333333333333
        public StomatologView Get(string jmbg)
        {
            DataProvider provider = new DataProvider();

            return provider.GetStomatologView(jmbg);
        }

        public int Post([FromBody] Stomatolog st)
        {
            DataProvider provider = new DataProvider();
            return provider.AddStomatolog(st);
        }

        public int Put(string jmbg, [FromBody]Stomatolog st)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateStomatolog(jmbg, st);
        }
    }
}
