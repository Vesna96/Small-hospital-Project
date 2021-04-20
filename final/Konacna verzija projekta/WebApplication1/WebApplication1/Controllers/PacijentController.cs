using Manja_bolnica;
using Manja_bolnica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class PacijentController : ApiController
    {
        

        public int Delete(string jmbg)
        {
            DataProvider provider = new DataProvider();
            return provider.DeletePacijent(jmbg);
        }
    }
}
