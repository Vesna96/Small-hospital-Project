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
    public class TehnicarController : ApiController
    {
        public IList<TehnicarView> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetTehnicariView();
        }

        //GET api/Tehnicar?jmbg=7777777777777
        public TehnicarView Get(string jmbg)
        {
            DataProvider provider = new DataProvider();

            return provider.GetTehnicarView(jmbg);
        }

        public int Post([FromBody] Tehnicar teh)
        {
            DataProvider provider = new DataProvider();
            return provider.AddTehnicar(teh);
        }

        public int Put(string jmbg, [FromBody]Tehnicar teh)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateTehnicar(jmbg, teh);
        }
    }
}
