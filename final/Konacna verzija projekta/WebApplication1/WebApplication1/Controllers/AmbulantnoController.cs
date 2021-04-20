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
    public class AmbulantnoController : ApiController
    {
        public IList<AmbulantniView> Get()
        {
            DataProvider provider = new DataProvider();
            return provider.GetAmbulantniView();
        }

        //GET api/Ambulantno?jmbg=1111119999999
        public AmbulantniView Get(string jmbg)
        {
            DataProvider provider = new DataProvider();

            return provider.GetAmbulantnoView(jmbg);
        }

        public int Post([FromBody] Ambulantno am)
        {
            DataProvider provider = new DataProvider();
            return provider.AddAmbulantno(am);
        }

        public int Put(string jmbg, [FromBody]Ambulantno am)
        {
            DataProvider provider = new DataProvider();
            return provider.UpdateAmbulantno(jmbg, am);
        }
    }
}
