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
    public partial class ListaIntervencijaPacijenta : Form
    {
        public string JMBGAmbulantno { get; set; }
        public ListaIntervencijaPacijenta()
        {
            InitializeComponent();
        }

        public ListaIntervencijaPacijenta(string jmbg)
        {
            this.JMBGAmbulantno = jmbg;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ambulantno o = s.Load<Ambulantno>(this.JMBGAmbulantno);
                o.Ulica = txtUlica.Text;
                o.Broj = Int32.Parse(txtBroj.Text);

                s.Update(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void popuniListuIntervencija()
        {
            txtUlica.Clear();
            txtBroj.Clear();
            listView1.Items.Clear();
            
            List<IntervencijaPregled> intervencije = DTOManager.VratiListuIntervencijaZaPacijenta(this.JMBGAmbulantno);
            foreach (IntervencijaPregled inter in intervencije)
            {
                ListViewItem item = new ListViewItem(new string[] { inter.IdIntervencije.ToString(),inter.Vrsta,inter.Datum.ToString("yyyy/MM/dd"),inter.ImeStomatologa,inter.PrezimeStomatologa });
                listView1.Items.Add(item);
                
            }
            IntervencijaPregled interven = intervencije.ElementAt(0);
            txtUlica.Text = interven.Ulica;
            txtBroj.Text = (interven.Broj).ToString();
            txtUlica.Refresh();
            txtBroj.Refresh();
            listView1.Refresh();
        }

        private void ListaIntervencijaPacijenta_Load(object sender, EventArgs e)
        {
            this.popuniListuIntervencija();
        }
        private void popuniTextBox()
        {
            txtUlica.Clear();
            txtBroj.Clear();

        }

        private void txtUlica_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
