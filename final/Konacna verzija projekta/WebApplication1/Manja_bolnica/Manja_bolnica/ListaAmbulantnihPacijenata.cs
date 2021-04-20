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
    public partial class ListaAmbulantnihPacijenata : Form
    {
        public string JMBGStomatologa { get; set; }

        public ListaAmbulantnihPacijenata()
        {
            InitializeComponent();
        }

        public ListaAmbulantnihPacijenata(string jmbg)
        {
            this.JMBGStomatologa = jmbg;
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListaAmbulantnihPacijenata_Load(object sender, EventArgs e)
        {
            this.popuniListuPacijenata();
        }

        private void popuniListuPacijenata()
        {
            listView1.Items.Clear();
            List<AmbulantniPregled> ambulantni = DTOManager.VratiPacijenteStomatologu(this.JMBGStomatologa);
            foreach (AmbulantniPregled amb in ambulantni)
            {
                ListViewItem item = new ListViewItem(new string[] { amb.IntervencijaId.ToString(), amb.ImeStomatologa,amb.PrezimeStomatologa,amb.Datum.ToString("yyyy/MM/dd"),amb.Vrsta,amb.ImeAmbulantno,amb.PrezimeAmbulantno });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite intervenciju!");
                return;
            }
            int odId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            AmbulantniBasic ab = DTOManager.vratiAmbulantniBasic(odId);

            IntervencijaEditBasic edbForm = new IntervencijaEditBasic(ab);
            if (edbForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DTOManager.AzurirajAmbulantniBasic(edbForm.ab);
                popuniListuPacijenata();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string jmbg = txtJMBG.Text;
            ListaIntervencijaPacijenta form = new ListaIntervencijaPacijenta(jmbg);
            form.Show();
        }
    }
}
