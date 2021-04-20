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
    public partial class OdeljenjaInformacije : Form

    {
        public string SpecijalistaJMBG { get; set; }
        public OdeljenjaInformacije()
        {
            InitializeComponent();
        }

        public OdeljenjaInformacije(string spec)
        {
            this.SpecijalistaJMBG = spec;
            InitializeComponent();
        }

        private void OdeljenjaInformacije_Load(object sender, EventArgs e)
        {
            this.popuniListuOdeljenja();
            
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite odeljenje!");
                return;
            }
            int odId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            OdeljenjeBasic ob = DTOManager.vratiOdeljenjeBasic(odId);

            OdeljenjeEditBasic edbForm = new OdeljenjeEditBasic(ob);
            if(edbForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DTOManager.AzurirajOdeljenjeBasic(edbForm.oBasic);
                popuniListuOdeljenja();
            }
        }


        private void popuniListuOdeljenja()
        {
            listView1.Items.Clear();
            List<OdeljenjePregled> odeljenja = DTOManager.VratiOdeljenjaZaSpecijalistu(this.SpecijalistaJMBG);
            foreach(OdeljenjePregled op in odeljenja)
            {
                ListViewItem item = new ListViewItem(new string[] { op.Sifra.ToString(), op.Tip, op.ImeSpecijaliste, op.PrezimeSpecijaliste, op.BrojPacijenata.ToString() });
                listView1.Items.Add(item);
            }
            
            txtJMBG.Clear();
            txtIme.Clear();
            txtPrezime.Clear();
            txtSpecijalnost.Clear();
            txtBroj.Clear();
            txtStaz.Clear();
            
            OdeljenjePregled specijalista = odeljenja.ElementAt(0);
            txtJMBG.Text = specijalista.JMBGSpecijalista;
            txtIme.Text = specijalista.ImeSpecijaliste;
            txtPrezime.Text = specijalista.PrezimeSpecijaliste;
            txtSpecijalnost.Text = specijalista.Specijalnost;
            txtBroj.Text = (specijalista.BrojOdeljenja).ToString();
            txtStaz.Text = specijalista.RadniStaz.ToString();


            txtJMBG.Refresh();
            txtIme.Refresh();
            txtPrezime.Refresh();
            txtBroj.Refresh();
            txtStaz.Refresh();
            txtSpecijalnost.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite odeljenje!");
                return;
            }
            int odId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ListaStacionarnihPacijenata odinfo = new ListaStacionarnihPacijenata(odId);
            odinfo.Show();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Specijalista spec = s.Load<Specijalista>(this.SpecijalistaJMBG);

                spec.Specijalnost = txtSpecijalnost.Text;
                spec.RadniStaz = Int32.Parse(txtStaz.Text);
                s.Update(spec);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string jmbgL = txtJMBG.Text;
            string ime = txtIme.Text;
            string prezime = txtPrezime.Text;
            string spec = txtSpecijalnost.Text;
            int staz = Int32.Parse(txtStaz.Text);
            txtBroj.Text = "0";

            try
            {
                ISession s = DataLayer.GetSession();


                Entiteti.Specijalista lek = new Entiteti.Specijalista();

                lek.JMBGMedicinsko = jmbgL;
                lek.ImeMedicinsko = ime;
                lek.PrezimeMedicinsko = prezime;
                lek.Specijalnost = spec;
                lek.TipMedicinsko = "specijalista";
                lek.RadniStaz = staz;
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

        private void button5_Click(object sender, EventArgs e)
        {
            string jmbg = txtBrisanje.Text;
            try
            {
                ISession s = DataLayer.GetSession();

                Specijalista spec = s.Load<Specijalista>(jmbg);


                s.Delete(spec);


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
