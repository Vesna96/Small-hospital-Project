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
    public partial class DodavanjePacijenta : Form
    {
        public string JMBGLekar;
        public DodavanjePacijenta()
        {
            InitializeComponent();
        }
        public DodavanjePacijenta(string jmbg)
        {
            this.JMBGLekar = jmbg;
            InitializeComponent();
        }
        private void DodavanjePacijenta_Load(object sender, EventArgs e)
        {
            txtJMBG.Clear();
            txtIme.Clear();
            txtPrezime.Clear();
          
            txtUlica.Clear();
            
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            string jmbgP = txtJMBG.Text;
            string ime = txtIme.Text;
            string prezime = txtPrezime.Text;
            string tip = cmbTip.SelectedText;
            if(tip == "stacionarno")
            {
                
                try
                {
                    ISession s = DataLayer.GetSession();

                    Entiteti.Lekar l = s.Load<Lekar>(this.JMBGLekar);

                    Entiteti.Stacionarno st = new Entiteti.Stacionarno();


                    st.JMBGPacijenta = jmbgP;
                    st.ImePacijenta = ime;
                    st.PrezimePacijenta = prezime;
                    st.TipPacijenta = tip;

                    st.IzabraniLekar = l;
                    s.Save(st);

                    l.Pacijenti.Add(st);
                    

                    s.Save(l);
                    MessageBox.Show("Uspesno kreiranje!");
                    s.Flush();
                    s.Close();

                }
                catch (Exception ec)
                {
                    MessageBox.Show(ec.Message);
                }
            }
            else
            {
                string ulica = txtUlica.Text;
                int broj = (int)numBroj.Value;
                try
                {
                    ISession s = DataLayer.GetSession();

                    Entiteti.Lekar l = s.Load<Lekar>(this.JMBGLekar);

                    Entiteti.Ambulantno st = new Entiteti.Ambulantno();


                    st.JMBGPacijenta = jmbgP;
                    st.ImePacijenta = ime;
                    st.PrezimePacijenta = prezime;
                    st.TipPacijenta = tip;
                    st.Ulica = ulica;
                    st.Broj = broj;
                    st.IzabraniLekar = l;
                    s.Save(st);

                    l.Pacijenti.Add(st);


                    s.Save(l);
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

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbTip_DropDownClosed(object sender, EventArgs e)
        {
          
        }
    }
}
