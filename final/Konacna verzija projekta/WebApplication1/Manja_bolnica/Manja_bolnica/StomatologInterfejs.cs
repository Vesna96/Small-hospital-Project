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
    public partial class StomatologInterfejs : Form
    {
        public string JMBGStomatologa { get; set; }
        public StomatologInterfejs()
        {
            InitializeComponent();
        }

        public StomatologInterfejs(string jmbg)
        {
            this.JMBGStomatologa = jmbg;
            InitializeComponent();
            this.popuniFormu();
        }

        public void popuniFormu()
        {
            txtJMBG.Clear();
            txtIme.Clear();
            txtPrezime.Clear();
            txtUkupno.Clear();


            StomatologPregled sp = DTOManager.vratiStomatologInterfejs(this.JMBGStomatologa);
            txtJMBG.Text = sp.JMBGStomatologa;
            txtIme.Text = sp.ImeStomatologa;
            txtPrezime.Text = sp.PrezimeStomatologa;
            txtUkupno.Text = (sp.BrojIntervencija).ToString();
            numStaz.Value = sp.RadniStaz;

            txtJMBG.Refresh();
            txtIme.Refresh();
            txtPrezime.Refresh();
            txtUkupno.Refresh();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Stomatolog st = s.Load<Stomatolog>(this.JMBGStomatologa);
                int stazStaro = st.RadniStaz;
                int stazNovo = (int)numStaz.Value;
                if (stazStaro <= stazNovo)
                {
                    st.RadniStaz = stazNovo;
                }
                else
                {
                    st.RadniStaz = stazStaro;
                    MessageBox.Show("Nevalidni podaci!");
                }

                s.Update(st);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void StomatologInterfejs_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            ListaAmbulantnihPacijenata form = new ListaAmbulantnihPacijenata(this.JMBGStomatologa);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListaStolicaStomatolog form = new ListaStolicaStomatolog(this.JMBGStomatologa);
            form.Show();
        }

        private void txtIme_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJMBG_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrezime_TextChanged(object sender, EventArgs e)
        {

        }

        private void numStaz_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtUkupno_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Entiteti.Ambulantno amb = s.Load<Ambulantno>(txtPacijent.Text);
                Entiteti.Stomatolog st = s.Load<Stomatolog>(this.JMBGStomatologa);
                Entiteti.Intervencija inter = new Intervencija();
                inter.Datum = dtpDatum.Value;
                inter.Vrsta = txtVrsta.Text;
                inter.PacijentIntervencija = amb;
                inter.StomatologIntervencija = st;

                s.Save(inter);
                amb.IntervecijePacijenta.Add(inter);
                s.Save(amb);
                st.IntervencijeStomatolog.Add(inter);
                s.Save(st);
                MessageBox.Show("Uspesno kreiranje!");
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string jmbgL = txtJMBG.Text;
            string ime = txtIme.Text;
            string prezime = txtPrezime.Text;
            int radniStaz = (int)numStaz.Value;
            
            txtUkupno.Text = "0";

            try
            {
                ISession s = DataLayer.GetSession();


                Entiteti.Stomatolog lek = new Entiteti.Stomatolog();

                lek.JMBGMedicinsko = jmbgL;
                lek.ImeMedicinsko = ime;
                lek.PrezimeMedicinsko = prezime;
                lek.RadniStaz = radniStaz;
                
                lek.TipMedicinsko = "stomatolog";

                s.Save(lek);

                MessageBox.Show("Uspesno kreiranje!");
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtIdStolice.Text);
            string smena = txtSmena.Text;
            DateTime dOd = dtpDatumOd.Value;
            DateTime dDo = dtpdatumDo.Value;
            try
            {
                ISession s = DataLayer.GetSession();


                Entiteti.Stomatolog lek = s.Load<Stomatolog>(this.JMBGStomatologa);
                Entiteti.Stolica st = s.Load<Stolica>(id);
                Entiteti.RadiNa rn = new RadiNa();
                rn.RadiNaStolica = st;
                rn.RadiNaStomatolog = lek;
                rn.Smena = smena;
                rn.DatumOd = dOd;
                rn.DatumDo = dDo;
                s.Save(rn);
                st.Stomatolozi.Add(rn);
                s.Save(st);
                lek.Stolice.Add(rn);
                s.Save(lek);

                MessageBox.Show("Uspesno kreiranje!");
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string jmbg = txtBrisanje.Text;
            try
            {
                ISession s = DataLayer.GetSession();

                Stomatolog st = s.Load<Stomatolog>(jmbg);


                s.Delete(st);


                s.Flush();
                s.Close();
                MessageBox.Show("Uspesno brisanje!");

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
