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
    public class OdeljenjeController : ApiController
    {
        public IList<OdeljenjeView> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetOdeljenjaView();
        }

        //GET api/Odeljenje?sifra=24
        public OdeljenjeView Get(int sifra)
        {
            DataProvider provider = new DataProvider();

            return provider.GetOdeljenjeView(sifra);
        }

        public int Post([FromBody] Odeljenje od)
        {
            DataProvider provider = new DataProvider();
            return provider.AddOdeljenje(od);
        }

        public int Put(int sifra, [FromBody]Odeljenje od)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateOdeljenje(sifra, od);
        }

        public int Delete(int sifra)
        {
            DataProvider provider = new DataProvider();
            return provider.DeleteOdeljenje(sifra);
        }
    }
}
