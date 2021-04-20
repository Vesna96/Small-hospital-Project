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
    public class LekarController : ApiController
    {
        public IList<LekarView> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetLekariView();
        }

        //GET api/Lekar?jmbg=3333333333333
        public LekarView Get(string jmbg)
        {
            DataProvider provider = new DataProvider();

            return provider.GetLekarView(jmbg);
        }

        public int Post([FromBody] Lekar lek)
        {
            DataProvider provider = new DataProvider();
            return provider.AddLekar(lek);
        }

        public int Put(string jmbg, [FromBody]Lekar lek)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateLekar(jmbg, lek);
        }
    }
}
