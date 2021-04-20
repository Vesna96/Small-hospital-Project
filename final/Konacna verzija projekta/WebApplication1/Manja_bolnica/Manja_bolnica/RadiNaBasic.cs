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
    public partial class RadiNaBasic : Form
    {
        public RadiNaStolicaBasic sb;
        public RadiNaBasic()
        {
            InitializeComponent();
        }
        public RadiNaBasic(RadiNaStolicaBasic sb)
        {
            this.sb = sb;
            InitializeComponent();
            this.popuniFormu();
        }

        public void popuniFormu()
        {
            txtSmena.Text = sb.Smena;
            dtpDatumOd.Value = sb.DatumOd;
            dtpDatumDo.Value = sb.DatumDo;
        }

        private void RadiNaBasic_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (DateTime.Compare(dtpDatumOd.Value, dtpDatumDo.Value) <= 0)
                {
                    ISession s = DataLayer.GetSession();
                    
                    RadiNa rn = s.Load<RadiNa>(sb.IdRadiNa);

                    rn.Smena = sb.Smena;
                    rn.DatumOd = sb.DatumOd;
                    rn.DatumDo = sb.DatumDo;

                    s.Update(rn);
                    s.Flush();
                    s.Close();
                }
                else
                {
                    MessageBox.Show("Nevalidno uneti datumi!");

                }




            }
            catch (Exception ex)
            {

            }
        }

        private void txtSmena_TextChanged(object sender, EventArgs e)
        {
            sb.Smena = txtSmena.Text;
        }

        private void dtpDatumOd_ValueChanged(object sender, EventArgs e)
        {
            sb.DatumOd = dtpDatumOd.Value;
        }

        private void dtpDatumDo_ValueChanged(object sender, EventArgs e)
        {
            sb.DatumDo = dtpDatumDo.Value;
        }
    }
}
