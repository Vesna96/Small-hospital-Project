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
    public partial class LekarInterfejs : Form
    {
        public string JMBGLekar;
        public LekarInterfejs()
        {
            InitializeComponent();
        }
        public LekarInterfejs(string jmbg)
        {
            this.JMBGLekar = jmbg;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LekarInterfejs_Load(object sender, EventArgs e)
        {
            this.popuniInterfejsZaLekara();
        }

        private void popuniInterfejsZaLekara()
        {
            txtJMBG.Clear();
            txtIme.Clear();
            txtPrezime.Clear();
            txtUkupno.Clear();

            List<LekarPacijentPregled> intervencije = DTOManager.VratiListuPacijenataZaLekara(this.JMBGLekar);
            foreach (LekarPacijentPregled lpp in intervencije)
            {
                ListViewItem item = new ListViewItem(new string[] { lpp.JMBGPacijenta, lpp.ImePacijenta, lpp.PrezimePacijenta });
                listView1.Items.Add(item);

            }
            int ukupno = intervencije.Count();
            txtUkupno.Text = ukupno.ToString();
            LekarPacijentPregled interven = intervencije.ElementAt(0);
            txtJMBG.Text = interven.JMBGLekara;
            txtIme.Text = interven.ImeLekara;
            txtPrezime.Text = interven.PrezimeLekara;

            numStaz.Value = interven.RadniStaz;
            numOrdinacija.Value = interven.BrojOrdinacije;

            txtJMBG.Refresh();
            txtIme.Refresh();
            txtPrezime.Refresh();
            txtUkupno.Refresh();
            numOrdinacija.Refresh();
            numStaz.Refresh();
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lekar lek = s.Load<Lekar>(this.JMBGLekar);
                int stazStaro = lek.RadniStaz;
                int stazNovo = (int)numStaz.Value;
                if (stazNovo > stazStaro)
                {
                    lek.RadniStaz = stazNovo;
                }
                else
                {
                    lek.RadniStaz = stazStaro;
                    MessageBox.Show("Nevalidni podaci!");
                }
                lek.BrojOrdinacije = (int)numOrdinacija.Value;

                s.Update(lek);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtIme_TextChanged(object sender, EventArgs e)
        {

        }

        private void numStaz_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numOrdinacija_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtUkupno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJMBG_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPrezime_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DodavanjePacijenta form = new DodavanjePacijenta(this.JMBGLekar);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string jmbgL = txtJMBG.Text;
            string ime = txtIme.Text;
            string prezime = txtPrezime.Text;
            int radniStaz = (int)numStaz.Value;
            int ordinacija = (int)numOrdinacija.Value;
            txtUkupno.Text = "0";

            try
            {
                ISession s = DataLayer.GetSession();


                Entiteti.Lekar lek = new Entiteti.Lekar();

                lek.JMBGMedicinsko = jmbgL;
                lek.ImeMedicinsko = ime;
                lek.PrezimeMedicinsko = prezime;
                lek.RadniStaz = radniStaz;
                lek.BrojOrdinacije = ordinacija;
                lek.TipMedicinsko = "lekar";

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

        private void button4_Click(object sender, EventArgs e)
        {
            string jmbg = txtBrisanje.Text;
            try
            {
                ISession s = DataLayer.GetSession();

                Lekar lek = s.Load<Lekar>(jmbg);


                s.Delete(lek);


                s.Flush();
                s.Close();
                MessageBox.Show("Uspesno brisanje!");

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
