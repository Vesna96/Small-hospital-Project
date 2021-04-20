using Manja_bolnica.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manja_bolnica.DTO
{
    public class StolicaView
    {
        public int IdStolice { get; protected set; }

        public string Proizvodjac { get; set; }

        public DateTime DatumProizvodnje { get; set; }

        public StolicaView()
        {

        }

        public StolicaView(Stolica st)
        {
            this.IdStolice = st.IdStolice;
            this.Proizvodjac = st.Proizvodjac;
            this.DatumProizvodnje = st.DatumProizvodnje;
        }

    }


}
