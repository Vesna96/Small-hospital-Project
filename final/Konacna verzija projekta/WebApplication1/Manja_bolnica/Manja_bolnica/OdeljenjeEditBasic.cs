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
    public partial class OdeljenjeEditBasic : Form
    {
        public OdeljenjeBasic oBasic;

        public OdeljenjeEditBasic()
        {
            InitializeComponent();
        }

        public OdeljenjeEditBasic(OdeljenjeBasic ob)
        {
            this.oBasic = ob;
            InitializeComponent();
            PopuniPodatke();
        }

        private void PopuniPodatke()
        {
            textTip.Text = oBasic.Tip;
            //textDatum.Text = oBasic.DatumIzgradnje.ToString("yyyyMMdd");
            dtpDatumIzgradnje.Value = oBasic.DatumIzgradnje;
        } 

        private void OdeljenjeEditBasic_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Odeljenje o = s.Load<Odeljenje>(oBasic.Sifra);
                o.Tip = oBasic.Tip;
                o.DatumIzgradnje = oBasic.DatumIzgradnje;

                s.Update(o);
                s.Flush();

                s.Close();
            }
            catch(Exception ex)
            {

            }
        }

        private void textTip_TextChanged(object sender, EventArgs e)
        {
            oBasic.Tip = textTip.Text;
        }

        private void textDatum_TextChanged(object sender, EventArgs e)
        {
            //oBasic.DatumIzgradnje = textTip.Text;
        }

        private void dtpDatumIzgradnje_ValueChanged(object sender, EventArgs e)
        {
            oBasic.DatumIzgradnje = dtpDatumIzgradnje.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tip = textTip.Text;
            DateTime datum = dtpDatumIzgradnje.Value;

            try
            {
                ISession s = DataLayer.GetSession();


                Entiteti.Odeljenje od = new Entiteti.Odeljenje();

                od.Tip = tip;
                od.DatumIzgradnje = datum;
                Entiteti.Specijalista spec = s.Load<Specijalista>(oBasic.JMBGSpecijalista);
                od.DodeljeniSpecijalista = spec;
                s.Save(od);

                MessageBox.Show("Uspesno kreiranje!");
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string jmbg = txtPacijent.Text;
            
            DateTime dOd = dtpPrijem.Value;
            DateTime dDo = dtpOtpust.Value;
            try
            {
                ISession s = DataLayer.GetSession();


                Entiteti.Odeljenje od = s.Load<Odeljenje>(this.oBasic.Sifra);
                Entiteti.Stacionarno st = s.Load<Stacionarno>(jmbg);
                Entiteti.LeziNa rn = new LeziNa();
                rn.OdeljenjeLezi = od;
                rn.PacijentLezi = st;
                rn.DatumPrijema = dOd;
                rn.DatumOtpusta = dDo;
                
                s.Save(rn);
                st.LeziNaOdeljenja.Add(rn);
                s.Save(st);
                od.LeziNaStacionarni.Add(rn);
                s.Save(od);

                MessageBox.Show("Uspesno kreiranje!");
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
