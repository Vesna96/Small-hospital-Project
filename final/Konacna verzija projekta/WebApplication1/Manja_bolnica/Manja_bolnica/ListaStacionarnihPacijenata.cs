using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manja_bolnica
{
    public partial class ListaStacionarnihPacijenata : Form
    {
        public int Sifra { get; set; }
        public ListaStacionarnihPacijenata()
        {
            InitializeComponent();
        }

        public ListaStacionarnihPacijenata(int sif)
        {
            this.Sifra = sif;
            InitializeComponent();
        }

        private void ListaStacionarnihPacijenata_Load(object sender, EventArgs e)
        {
            this.popuniListuPacijenata();
        }

        private void popuniListuPacijenata()
        {
            listView1.Items.Clear();
            List<StacionarniPregled> stacionarni = DTOManager.VratiPacijenteNaOdeljenju(this.Sifra);
            foreach (StacionarniPregled sp in stacionarni)
            {
                ListViewItem item = new ListViewItem(new string[] { sp.LeziId.ToString(),sp.Tip, sp.JMBGStacionarno, sp.ImeStacionarno, sp.PrezimeStacionarno,sp.DatumPrijema.ToString("yyyy/MM/dd"),sp.DatumOtpusta.ToString("yyyy/MM/dd") });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite pacijenta!");
                return;
            }
            int odId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            StacionarniBasic sb = DTOManager.vratiStacionarniBasic(odId);

            StacionarniEditBasic edbForm = new StacionarniEditBasic(sb);
            if (edbForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DTOManager.AzurirajStacionarniBasic(edbForm.sb);
                popuniListuPacijenata();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
