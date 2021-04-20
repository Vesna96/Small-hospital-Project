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
    public class HigijenicarController : ApiController
    {
        public IList<HigijenicarView> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetHigijenicariView();
        }

        //GET api/Higijenicar?jmbg=9999999999999
        public HigijenicarView Get(string jmbg)
        {
            DataProvider provider = new DataProvider();

            return provider.GetHigijenicarView(jmbg);
        }

        public int Post([FromBody] Higijenicar hig)
        {
            DataProvider provider = new DataProvider();
            return provider.AddHigijenicar(hig);
        }

        public int Put(string jmbg, [FromBody]Higijenicar hig)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateHigijenicar(jmbg, hig);
        }
    }
}
