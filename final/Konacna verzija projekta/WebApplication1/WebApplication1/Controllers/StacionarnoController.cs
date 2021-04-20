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
    public class StacionarnoController : ApiController
    {
        public IList<StacionarniView> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetStacionarniView();
        }

        //GET api/Stacionarno?jmbg=0222222222222
        public StacionarniView Get(string jmbg)
        {
            DataProvider provider = new DataProvider();

            return provider.GetStacionarnoView(jmbg);
        }
        public int Post([FromBody] Stacionarno st)
        {
            DataProvider provider = new DataProvider();
            return provider.AddStacionarno(st);
        }

        public int Put(string jmbg, [FromBody]Stacionarno st)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateStacionarno(jmbg, st);
        }
    }
}
