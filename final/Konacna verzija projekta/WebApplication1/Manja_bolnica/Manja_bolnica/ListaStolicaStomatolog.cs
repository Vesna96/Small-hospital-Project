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
    public partial class ListaStolicaStomatolog : Form
    {
        public string JMBGStomatolog;
        public ListaStolicaStomatolog()
        {
            InitializeComponent();
        }
        public ListaStolicaStomatolog(string jmbg)
        {
            this.JMBGStomatolog = jmbg;
            InitializeComponent();
        }

        private void ListaStolicaStomatolog_Load(object sender, EventArgs e)
        {
            this.popuniListu();
        }
        private void popuniListu()
        {
            
            listView1.Items.Clear();

            List<StolicePregled> stolice = DTOManager.VratiListuStolicaZaStomatologa(this.JMBGStomatolog);
            foreach (StolicePregled sto in stolice)
            {
                ListViewItem item = new ListViewItem(new string[] {  sto.IdRadiNa.ToString(),sto.Proizvodjac,sto.DatumProizvodnje.ToString("yyyy/MM/dd"),
                sto.Smena,sto.DatumOd.ToString("yyyy/MM/dd"),sto.DatumDo.ToString("yyyy/MM/dd")});
                listView1.Items.Add(item);

            }
            
            
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite!");
                return;
            }
            int odId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            RadiNaStolicaBasic ob = DTOManager.vratiRadiNa(odId);

            RadiNaBasic edbForm = new RadiNaBasic(ob);
            if (edbForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DTOManager.AzurirajRadiNa(ob);
                popuniListu();
            }
        }
    }
}
