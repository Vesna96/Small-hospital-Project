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
    public partial class Pocetna : Form
    {
        public Pocetna()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jmbg;
            jmbg = txtJMBG.Text;
            if(jmbg == "")
            {
                MessageBox.Show("Uneti jmbg!");
            }
            if (rbLekar.Checked)
            {
                
                LekarInterfejs form = new LekarInterfejs(jmbg);
                form.Show();
            }
            else if(rbSpecijalista.Checked)
            {
                OdeljenjaInformacije form = new OdeljenjaInformacije(jmbg);
                form.Show();
            }
            else if(rbStomatolog.Checked)
            {
                StomatologInterfejs form = new StomatologInterfejs(jmbg);
                form.Show();
            }
            else if(rbTehnicar.Checked)
            {
                TehnicarInterfejs form = new TehnicarInterfejs(jmbg);
                form.Show();
            }
            else if(rbHigijenicar.Checked)
            {
                HigijenicarInterfejs form = new HigijenicarInterfejs(jmbg);
                form.Show();
            }
            else
            {
                MessageBox.Show("Selektovati odgovarajuci tip profila!");
            }
            
        }

        private void Pocetna_Load(object sender, EventArgs e)
        {

        }
    }
}
