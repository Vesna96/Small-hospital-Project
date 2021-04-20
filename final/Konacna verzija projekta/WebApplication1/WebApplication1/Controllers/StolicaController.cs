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
    public class StolicaController : ApiController
    {
        public IList<StolicaView> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetStoliceView();
        }

        public StolicaView Get(int id)
        {
            DataProvider provider = new DataProvider();

            return provider.GetStolicaView(id);
        }

        public int Post([FromBody] Stolica st)
        {
            DataProvider provider = new DataProvider();
            return provider.AddStolica(st);
        }

        public int Put(int id, [FromBody]Stolica st)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateStolica(id, st);
        }

        public int Delete(int id)
        {
            DataProvider provider = new DataProvider();
            return provider.DeleteStolica(id);
        }
    }
}
