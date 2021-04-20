using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manja_bolnica.Entiteti;
using NHibernate;


namespace Manja_bolnica
{
    public partial class IntervencijaEditBasic : Form
    {
        public AmbulantniBasic ab;
        public IntervencijaEditBasic()
        {
            InitializeComponent();
        }

        public IntervencijaEditBasic(AmbulantniBasic ab)
        {
            this.ab = ab;
            InitializeComponent();
            popuniFormu();
        }

        public void popuniFormu()
        {
            dtpDatum.Value = ab.Datum;
            txtVrsta.Text = ab.Vrsta;
        }

        private void IntervencijaEditBasic_Load(object sender, EventArgs e)
        {

        }

        private void dtpDatum_ValueChanged(object sender, EventArgs e)
        {
            ab.Datum = dtpDatum.Value;
        }

        private void txtVrsta_TextChanged(object sender, EventArgs e)
        {
            ab.Vrsta = txtVrsta.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                    ISession s = DataLayer.GetSession();

                    Intervencija inter = s.Load<Intervencija>(ab.IntervencijaiId);

                    inter.Datum = ab.Datum;
                    inter.Vrsta = ab.Vrsta;

                    s.Update(inter);
                    s.Flush();
                    s.Close();
               
            }
            catch (Exception ex)
            {

            }
        }
    }
}
