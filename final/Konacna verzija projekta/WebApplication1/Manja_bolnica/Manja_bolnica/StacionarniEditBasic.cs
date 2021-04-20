using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using Manja_bolnica.Entiteti;

namespace Manja_bolnica
{
    public partial class StacionarniEditBasic : Form
    {
        public StacionarniBasic sb;
        public StacionarniEditBasic()
        {
            InitializeComponent();
        }

        public StacionarniEditBasic(StacionarniBasic sb)
        {
            this.sb = sb;
            InitializeComponent();
            popuniFormu();
        }

        public void popuniFormu()
        {
            dtpPrijem.Value = sb.DatumPrijema;
            dtpOtpust.Value = sb.DatumOtpusta;
        }


        private void StacionarniEditBasic_Load(object sender, EventArgs e)
        {

        }

        private void dtpPrijem_ValueChanged(object sender, EventArgs e)
        {
            sb.DatumPrijema = dtpPrijem.Value;
        }

        private void dtpOtpust_ValueChanged(object sender, EventArgs e)
        {
            sb.DatumOtpusta = dtpOtpust.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(DateTime.Compare(dtpPrijem.Value,dtpOtpust.Value) <= 0 )
                {
                    ISession s = DataLayer.GetSession();

                    LeziNa ln = s.Load<LeziNa>(sb.LeziId);

                    ln.DatumPrijema = sb.DatumPrijema;
                    ln.DatumOtpusta = sb.DatumOtpusta;

                    s.Update(ln);
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
    }
}
