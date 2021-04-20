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
    public partial class TehnicarInterfejs : Form
    {
        public string JMBGTehnicar;
        public TehnicarInterfejs()
        {
            InitializeComponent();
        }

        public TehnicarInterfejs(string jmbg)
        {
            this.JMBGTehnicar = jmbg;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Tehnicar teh = s.Load<Tehnicar>(this.JMBGTehnicar);

                teh.Struka = txtStruka.Text;

                s.Update(teh);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {

            }
        }
        private void popuniInterfejsZaTehnicara()
        {
            txtJMBG.Clear();
            txtIme.Clear();
            txtPrezime.Clear();
            txtStruka.Clear();
            txtUkupno.Clear();

            List<TehnicarStolicePregled> lista = DTOManager.VratiListuStolicaZaTehnicara(this.JMBGTehnicar);
            foreach (TehnicarStolicePregled tsp in lista)
            {
                ListViewItem item = new ListViewItem(new string[] { tsp.IdStolice.ToString(), tsp.Proizvodjac,tsp.Datum.ToString("yyyy/MM/dd") });
                listView1.Items.Add(item);

            }
            int ukupno = lista.Count();
            txtUkupno.Text = ukupno.ToString();
            TehnicarStolicePregled teh = lista.ElementAt(0);
            txtJMBG.Text = teh.JMBGTehnicara;
            txtIme.Text = teh.ImeTehnicara;
            txtPrezime.Text = teh.PrezimeTehnicara;
            
            txtStruka.Text = teh.Struka;

            txtJMBG.Refresh();
            txtIme.Refresh();
            txtPrezime.Refresh();
            txtUkupno.Refresh();
            txtStruka.Refresh();
            
            listView1.Refresh();
        }

        private void TehnicarInterfejs_Load(object sender, EventArgs e)
        {
            this.popuniInterfejsZaTehnicara();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string jmbg = txtBrisanje.Text;
            try
            {
                ISession s = DataLayer.GetSession();

                Tehnicar teh = s.Load<Tehnicar>(jmbg);

                
                s.Delete(teh);
                

                s.Flush();
                s.Close();
                MessageBox.Show("Uspesno brisanje!");

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string jmbgL = txtJMBG.Text;
            string ime = txtIme.Text;
            string prezime = txtPrezime.Text;
            string struka = txtStruka.Text;
            string tip = "tehnicar";
            txtUkupno.Text = "0";

            try
            {
                ISession s = DataLayer.GetSession();


                Entiteti.Tehnicar lek = new Entiteti.Tehnicar();

                lek.JMBGNemedicinsko = jmbgL;
                lek.ImeNemedicinsko = ime;
                lek.PrezimeNemedicinsko = prezime;
                lek.Struka = struka;
                lek.TipNemedicinsko = tip;
                

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
