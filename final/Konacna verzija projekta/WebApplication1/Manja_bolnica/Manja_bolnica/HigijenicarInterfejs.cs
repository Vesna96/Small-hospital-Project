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
    public partial class HigijenicarInterfejs : Form
    {
        public string JMBGHigijenicar;
        public HigijenicarInterfejs()
        {
            InitializeComponent();
        }

        public HigijenicarInterfejs(string jmbg)
        {
            this.JMBGHigijenicar = jmbg;
            InitializeComponent();
        }

        private void HigijenicarInterfejs_Load(object sender, EventArgs e)
        {
            this.popuniInterfejsZaHigijenicara();
        }

        private void popuniInterfejsZaHigijenicara()
        {
            txtJMBG.Clear();
            txtIme.Clear();
            txtPrezime.Clear();
            txtBroj.Clear();

            List<HigijenicarPregled> lista = DTOManager.VratiListuOdeljenjaZaHigijenicara(this.JMBGHigijenicar);
            foreach (HigijenicarPregled tsp in lista)
            {
                ListViewItem item = new ListViewItem(new string[] { tsp.SifraOdeljenja.ToString(), tsp.TipOdeljenja });
                listView1.Items.Add(item);

            }
            int ukupno = lista.Count();
            txtBroj.Text = ukupno.ToString();
            HigijenicarPregled hig = lista.ElementAt(0);
            txtJMBG.Text = hig.JMBGHigijenicar;
            txtIme.Text = hig.Ime;
            txtPrezime.Text = hig.Prezime;
           

            txtJMBG.Refresh();
            txtIme.Refresh();
            txtPrezime.Refresh();
            txtBroj.Refresh();
           

            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jmbg = txtBrisanje.Text;
            try
            {
                ISession s = DataLayer.GetSession();

                Higijenicar hig = s.Load<Higijenicar>(jmbg);


                s.Delete(hig);


                s.Flush();
                s.Close();
                MessageBox.Show("Uspesno brisanje!");

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string jmbgL = txtJMBG.Text;
            string ime = txtIme.Text;
            string prezime = txtPrezime.Text;
            
            txtBroj.Text = "0";

            try
            {
                ISession s = DataLayer.GetSession();


                Entiteti.Higijenicar lek = new Entiteti.Higijenicar();

                lek.JMBGNemedicinsko = jmbgL;
                lek.ImeNemedicinsko = ime;
                lek.PrezimeNemedicinsko = prezime;
                
                lek.TipNemedicinsko = "higijenicar";

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
    }
}
