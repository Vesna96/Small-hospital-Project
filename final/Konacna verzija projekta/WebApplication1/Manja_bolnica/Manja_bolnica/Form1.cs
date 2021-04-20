using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using Manja_bolnica.Entiteti;

namespace Manja_bolnica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Manja_bolnica.Entiteti.Medicinsko med = s.Load<Manja_bolnica.Entiteti.Medicinsko>("1111111111111");
                
                MessageBox.Show(med.ImeMedicinsko);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Manja_bolnica.Entiteti.Odeljenje od = s.Load<Manja_bolnica.Entiteti.Odeljenje>(111);

                MessageBox.Show(od.Tip);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Specijalista sp = new Entiteti.Specijalista();
                sp.JMBGMedicinsko = "1222222222222";
                sp.ImeMedicinsko = "Novak";
                sp.PrezimeMedicinsko = "Djokovic";
                sp.Specijalnost = "spec Hirurgija";
                sp.TipMedicinsko = "specijalista";

                Entiteti.Odeljenje od = new Entiteti.Odeljenje();
                Entiteti.Odeljenje od1 = new Entiteti.Odeljenje();

                od.Tip = "Pedijatrija";
                od.DatumIzgradnje = new DateTime(2000, 04, 11);

                od1.Tip = "Hirurgija";
                od1.DatumIzgradnje = new DateTime(2005, 10, 03);



                s.Save(sp);

                od.DodeljeniSpecijalista = sp;
                s.Save(od);

                od1.DodeljeniSpecijalista = sp;
                s.Save(od1);

                sp.Odeljenja.Add(od);
                sp.Odeljenja.Add(od1);

                s.Save(sp);
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
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Manja_bolnica.Entiteti.Pacijent p = s.Load<Manja_bolnica.Entiteti.Pacijent>("1111114444444");

                MessageBox.Show(p.ImePacijenta+" "+p.PrezimePacijenta);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Lekar l = new Entiteti.Lekar();
                l.JMBGMedicinsko = "9111111111111";
                l.ImeMedicinsko = "Ana";
                l.PrezimeMedicinsko = "Ivanovic";
                l.RadniStaz =10;
                l.BrojOrdinacije =104;
                l.TipMedicinsko = "lekar";

                Entiteti.Stacionarno st = new Entiteti.Stacionarno();
                Entiteti.Ambulantno am = new Entiteti.Ambulantno();

                st.JMBGPacijenta = "8222222222222";
                st.ImePacijenta ="Jelena";
                st.PrezimePacijenta = "Jankovic";
                st.TipPacijenta = "stacionarno";

                am.JMBGPacijenta = "7222222222222";
                am.ImePacijenta = "Dusan";
                am.PrezimePacijenta = "Lajovic";
                am.Ulica = "Nisavska";
                am.Broj = 7;
                am.TipPacijenta = "ambulantno";


                s.Save(l);

                st.IzabraniLekar = l;
                s.Save(st);

                am.IzabraniLekar = l;
                s.Save(am);

                l.Pacijenti.Add(st);
                l.Pacijenti.Add(am);

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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Stomatolog s1 = s.Load<Stomatolog>("4444444444444");

                foreach (Entiteti.Intervencija p1 in s1.IntervencijeStomatolog)
                {
                    MessageBox.Show(s1.ImeMedicinsko+" "+p1.Vrsta);
                }


                Entiteti.Ambulantno p2 = s.Load<Entiteti.Ambulantno>("1111118888888");

                foreach (Intervencija r2 in p2.IntervecijePacijenta)
                {
                    MessageBox.Show(p2.ImePacijenta+" "+r2.Datum + " " + r2.Vrsta);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Odeljenje odd1 = s.Load<Odeljenje>(111);

                foreach (Entiteti.LeziNa p1 in odd1.LeziNaStacionarni)
                {
                    MessageBox.Show(p1.PacijentLezi.ImePacijenta);
                }


                Entiteti.Stacionarno pp2 = s.Load<Entiteti.Stacionarno>("1111114444444");

                foreach (LeziNa r2 in pp2.LeziNaOdeljenja)
                {
                    MessageBox.Show(pp2.ImePacijenta + " " + pp2.PrezimePacijenta+" "+ r2.DatumPrijema + " "+r2.DatumOtpusta);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Higijenicar st = s.Load<Higijenicar>("9999999999999");


                foreach (Odrzava ptr1 in st.Odeljenja)
                {
                    MessageBox.Show(ptr1.OdeljenjeOdrzava.Tip);
                }


                Odeljenje pt2 = s.Load<Entiteti.Odeljenje>(111);

                foreach (Odrzava rr2 in pt2.Higijenicari)
                {
                    MessageBox.Show(rr2.JMBGHigijenicara.ImeNemedicinsko);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Manja_bolnica.Entiteti.Stolica stolica = s.Load<Manja_bolnica.Entiteti.Stolica>(1);

                MessageBox.Show(stolica.DodeljeniTehnicar.ImeNemedicinsko+" "+ stolica.DodeljeniTehnicar.PrezimeNemedicinsko+" "+ stolica.Proizvodjac);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                Stomatolog st = s.Load<Stomatolog>("5555555555555");

                
                foreach (RadiNa ptr1 in st.Stolice)
                {
                    MessageBox.Show(ptr1.RadiNaStolica.Proizvodjac );
                }


                Stolica pt2 = s.Load<Entiteti.Stolica>(1);

                foreach (RadiNa rr2 in pt2.Stomatolozi)
                {
                    MessageBox.Show(rr2.RadiNaStomatolog.ImeMedicinsko);
                }
                
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                

                Entiteti.Stacionarno p = new Entiteti.Stacionarno()
                {
                    JMBGPacijenta = "0118111181191",
                    ImePacijenta = "Marko",
                    PrezimePacijenta = "Markovic",
                    TipPacijenta = "stacionarno"
                  
                   
                };
               

                Odeljenje r = new Odeljenje()
                {
                    Tip = "Ortopedija",
                    DatumIzgradnje = new DateTime(1996, 11, 13)
                    
                    
                };
                

                LeziNa ln = new LeziNa();
                ln.DatumPrijema = new DateTime(2015,03,03);
                ln.DatumOtpusta = new DateTime(2015,03,13);
                ln.PacijentLezi = p;
                ln.OdeljenjeLezi = r;
                p.LeziNaOdeljenja.Add(ln);
                r.LeziNaStacionarni.Add(ln);
                //r.Stacionarni.Add(p);
                //p.Odeljenja.Add(r);

                s.Save(p);
                s.Save(r);
                s.Save(ln);
                

                s.Flush();
                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Stolica r = s.Load<Stolica>(3);
                Entiteti.Stomatolog st = s.Load<Entiteti.Stomatolog>("4444444444444");

                RadiNa rn = new RadiNa();
                rn.Smena = "Popodne";
                rn.DatumOd = new DateTime(2016,04,05);
                rn.DatumDo = new DateTime(2016,04,15);
                rn.RadiNaStolica = r;
                rn.RadiNaStomatolog = st;
                r.Stomatolozi.Add(rn);
                st.Stolice.Add(rn);

               

                s.Save(rn);

                s.Flush();
                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Odeljenje r = s.Load<Odeljenje>(333);
                Entiteti.Higijenicar st = s.Load<Entiteti.Higijenicar>("0718116181100");

                Odrzava rn = new Odrzava();
                
                rn.JMBGHigijenicara = st;
                rn.OdeljenjeOdrzava = r;
                r.Higijenicari.Add(rn);
                st.Odeljenja.Add(rn);



                s.Save(rn);

                s.Flush();
                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Tehnicar sp = new Entiteti.Tehnicar();
                sp.JMBGNemedicinsko = "1222222222555";
                sp.ImeNemedicinsko = "Nikola";
                sp.PrezimeNemedicinsko = "Nikolic";
                sp.Struka = "Bravar";
                sp.TipNemedicinsko = "tehnicar";

                Entiteti.Stolica st = new Entiteti.Stolica();

                st.Proizvodjac = "Forma ideale";
                st.DatumProizvodnje = new DateTime(2000, 06, 11);





                s.Save(sp);

                st.DodeljeniTehnicar = sp;
                s.Save(st);


                sp.Stolice.Add(st);


                s.Save(sp);
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ambulantno am = new Ambulantno();
                am.JMBGPacijenta = "9999999222222";
                am.ImePacijenta = "Petra";
                am.PrezimePacijenta = "Petric";
                am.TipPacijenta = "ambulantno";
                am.Ulica = "Bulevar Nikole Tesle";
                am.Broj = 100;
                

                Entiteti.Stomatolog st = s.Load<Entiteti.Stomatolog>("5555555555555");

                Intervencija rn = new Intervencija();
                rn.Vrsta = "Popravka zuba";
                rn.Datum = new DateTime(2016, 09, 25);
                
                rn.PacijentIntervencija = am;
                rn.StomatologIntervencija = st;
                am.IntervecijePacijenta.Add(rn);
                st.IntervencijeStomatolog.Add(rn);
                s.Save(am);


                s.Save(rn);

                s.Flush();
                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lekar st = s.Load<Lekar>("9111111111111");


                foreach (Pacijent ptr1 in st.Pacijenti)
                {
                    MessageBox.Show(ptr1.ImePacijenta + " " + ptr1.PrezimePacijenta);
                }


                

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Specijalista st = s.Load<Specijalista>("2222222222222");


                foreach (Odeljenje ptr1 in st.Odeljenja)
                {
                    MessageBox.Show(st.ImeMedicinsko + " " + st.PrezimeMedicinsko + " " + ptr1.Tip);
                }




                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                IList<Pacijent> pacijenti = s.QueryOver<Pacijent>()
                                                .List<Pacijent>();

                foreach (Pacijent p in pacijenti)
                {
                    if (p.GetType() == typeof(Ambulantno))
                    {
                        Ambulantno am = (Ambulantno)p;
                        MessageBox.Show(am.ImePacijenta + " " + am.PrezimePacijenta + " " + am.Ulica);
                    }
                    else 
                    {
                        Stacionarno st = (Stacionarno)p;
                        MessageBox.Show(st.ImePacijenta + " " + st.PrezimePacijenta);
                    }
                    
                }

                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                IList<Medicinsko> med = s.QueryOver<Medicinsko>()
                                                .List<Medicinsko>();

                foreach (Medicinsko m in med)
                {
                    if (m.GetType() == typeof(Lekar))
                    {
                        Lekar lek = (Lekar)m;
                        MessageBox.Show(lek.ImeMedicinsko + " " + lek.PrezimeMedicinsko + " " + lek.BrojOrdinacije);
                    }
                    else if (m.GetType() == typeof(Specijalista))
                    {
                        Specijalista sp = (Specijalista)m;
                        MessageBox.Show(sp.ImeMedicinsko + " " + sp.PrezimeMedicinsko + " " + sp.Specijalnost);
                    }
                    else
                    {
                        Stomatolog sp = (Stomatolog)m;
                        MessageBox.Show(sp.ImeMedicinsko + " " + sp.PrezimeMedicinsko);

                    }

                }

                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                IList<Nemedicinsko> nemed = s.QueryOver<Nemedicinsko>()
                                                .List<Nemedicinsko>();

                foreach (Nemedicinsko m in nemed)
                {
                    if (m.GetType() == typeof(Tehnicar))
                    {
                        Tehnicar teh = (Tehnicar)m;
                        MessageBox.Show(teh.ImeNemedicinsko + " " + teh.PrezimeNemedicinsko + " " + teh.Struka);
                    }
                    else 
                    {
                        Higijenicar h = (Higijenicar)m;
                        MessageBox.Show(h.ImeNemedicinsko + " " + h.PrezimeNemedicinsko);
                    }
                    

                }

                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }


        }

        private void button21_Click(object sender, EventArgs e)
        {
            OdeljenjaInformacije odinfo = new OdeljenjaInformacije("1111111111111");
            odinfo.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            StomatologInterfejs odinfo = new StomatologInterfejs("4444444444444");
            odinfo.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            LekarInterfejs form = new LekarInterfejs("3333333333333");
            form.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            TehnicarInterfejs form = new TehnicarInterfejs("8888888888888");
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
