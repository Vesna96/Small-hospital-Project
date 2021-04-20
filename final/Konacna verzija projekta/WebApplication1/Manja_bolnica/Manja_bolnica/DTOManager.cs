using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using NHibernate;
using Manja_bolnica.Entiteti;

namespace Manja_bolnica
{
    public class DTOManager
    {
        public static List<OdeljenjePregled> VratiOdeljenjaZaSpecijalistu(string specijalistaJMBG)
        {
            List<OdeljenjePregled> lista = new List<OdeljenjePregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Odeljenje> odeljenja = from o in s.Query<Odeljenje>()
                                                   where o.DodeljeniSpecijalista.JMBGMedicinsko == specijalistaJMBG
                                                   select o;
                int broj = odeljenja.Count();
                foreach (Odeljenje o in odeljenja)
                {
                    lista.Add(new OdeljenjePregled(o.DodeljeniSpecijalista.JMBGMedicinsko,o.Sifra, o.Tip, o.DodeljeniSpecijalista.ImeMedicinsko, o.DodeljeniSpecijalista.PrezimeMedicinsko,o.DodeljeniSpecijalista.Specijalnost, o.LeziNaStacionarni.Count,broj,o.DodeljeniSpecijalista.RadniStaz));
                }
                s.Close();
            }
            catch (Exception ex)
            {

            }
            return lista;
        }

        /*public static OdeljenjeBasic AzurirajSpecijalistaBasic(OdeljenjeBasic ob)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Odeljenje o = s.Load<Odeljenje>(ob.Sifra);
                o.Tip = ob.Tip;
                o.DatumIzgradnje = ob.DatumIzgradnje;

                s.Update(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {

            }
            return ob;
        }*/

        public static OdeljenjeBasic vratiOdeljenjeBasic(int sifra)
        {
            OdeljenjeBasic ob = new Manja_bolnica.OdeljenjeBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Odeljenje o = s.Load<Odeljenje>(sifra);
                ob = new Manja_bolnica.OdeljenjeBasic(o.DodeljeniSpecijalista.JMBGMedicinsko,o.Sifra, o.Tip, o.DatumIzgradnje);

                s.Close();
            }
            catch (Exception ex)
            {

            }
            return ob;
        }

        public static OdeljenjeBasic AzurirajOdeljenjeBasic(OdeljenjeBasic ob)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Odeljenje o = s.Load<Odeljenje>(ob.Sifra);
                o.Tip = ob.Tip;
                o.DatumIzgradnje = ob.DatumIzgradnje;

                s.Update(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {

            }
            return ob;
        }


        public static List<StacionarniPregled> VratiPacijenteNaOdeljenju(int sifra)
        {
            List<StacionarniPregled> lista = new List<StacionarniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<LeziNa> listaLeziNa = from ln in s.Query<LeziNa>()
                                                  where ln.OdeljenjeLezi.Sifra == sifra
                                                  select ln;

                foreach (LeziNa ln in listaLeziNa)
                {
                    lista.Add(new StacionarniPregled(ln.LeziId, ln.OdeljenjeLezi.Sifra, ln.OdeljenjeLezi.Tip, ln.PacijentLezi.JMBGPacijenta, ln.PacijentLezi.ImePacijenta, ln.PacijentLezi.PrezimePacijenta, ln.DatumPrijema, ln.DatumOtpusta));
                }


                s.Close();
            }
            catch (Exception ex)
            {

            }
            return lista;

        }

        public static StacionarniBasic vratiStacionarniBasic(int leziId)
        {
            StacionarniBasic sb = new Manja_bolnica.StacionarniBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                LeziNa ln = s.Load<LeziNa>(leziId);
                sb = new StacionarniBasic(ln.LeziId, ln.DatumPrijema, ln.DatumOtpusta);

                s.Close();
            }
            catch (Exception ex)
            {

            }
            return sb;
        }

        public static StacionarniBasic AzurirajStacionarniBasic(StacionarniBasic sb)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LeziNa ln = s.Load<LeziNa>(sb.LeziId);
                ln.DatumPrijema = sb.DatumPrijema;
                ln.DatumOtpusta = sb.DatumOtpusta;

                s.Update(ln);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {

            }
            return sb;
        }

        public static List<AmbulantniPregled> VratiPacijenteStomatologu(string JMBGStomatolog)
        {
            List<AmbulantniPregled> lista = new List<AmbulantniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Intervencija> listaIntervencija = from i in s.Query<Intervencija>()
                                                              where i.StomatologIntervencija.JMBGMedicinsko == JMBGStomatolog
                                                              select i;

                foreach (Intervencija i in listaIntervencija)
                {

                    lista.Add(new AmbulantniPregled(i.StomatologIntervencija.JMBGMedicinsko, i.StomatologIntervencija.ImeMedicinsko, i.StomatologIntervencija.PrezimeMedicinsko, i.PacijentIntervencija.JMBGPacijenta, i.PacijentIntervencija.ImePacijenta, i.PacijentIntervencija.PrezimePacijenta, i.Vrsta, i.Datum, i.IntervencijaId));
                }


                s.Close();
            }
            catch (Exception ex)
            {

            }
            return lista;

        }
        public static AmbulantniBasic vratiAmbulantniBasic(int intervencijaId)
        {
            AmbulantniBasic ab = new Manja_bolnica.AmbulantniBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Intervencija inter = s.Load<Intervencija>(intervencijaId);
                ab = new AmbulantniBasic(inter.IntervencijaId, inter.Datum, inter.Vrsta);

                s.Close();
            }
            catch (Exception ex)
            {

            }
            return ab;
        }

        public static AmbulantniBasic AzurirajAmbulantniBasic(AmbulantniBasic ab)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Intervencija inter = s.Load<Intervencija>(ab.IntervencijaiId);
                inter.Datum = ab.Datum;
                inter.Vrsta = ab.Vrsta;

                s.Update(inter);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {

            }
            return ab;
        }


        public static List<IntervencijaPregled> VratiListuIntervencijaZaPacijenta(string JMBGPacijent)
        {
            List<IntervencijaPregled> lista = new List<IntervencijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Intervencija> listaIntervencija = from i in s.Query<Intervencija>()
                                                              where i.PacijentIntervencija.JMBGPacijenta == JMBGPacijent
                                                              select i;

                foreach (Intervencija i in listaIntervencija)
                {

                    lista.Add(new IntervencijaPregled(i.IntervencijaId, i.Vrsta, i.Datum, i.PacijentIntervencija.JMBGPacijenta, i.PacijentIntervencija.Ulica, i.PacijentIntervencija.Broj, i.StomatologIntervencija.ImeMedicinsko, i.StomatologIntervencija.PrezimeMedicinsko));
                }


                s.Close();
            }
            catch (Exception ex)
            {

            }
            return lista;

        }

        public static List<LekarPacijentPregled> VratiListuPacijenataZaLekara(string JMBGLekara)
        {
            List<LekarPacijentPregled> lista = new List<LekarPacijentPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Pacijent> listaP = from p in s.Query<Pacijent>()
                                               where p.IzabraniLekar.JMBGMedicinsko == JMBGLekara
                                               select p;

                foreach (Pacijent p in listaP)
                {

                    lista.Add(new LekarPacijentPregled(p.IzabraniLekar.JMBGMedicinsko, p.IzabraniLekar.ImeMedicinsko, p.IzabraniLekar.PrezimeMedicinsko, p.IzabraniLekar.RadniStaz, p.IzabraniLekar.BrojOrdinacije, p.JMBGPacijenta, p.ImePacijenta, p.PrezimePacijenta));
                }


                s.Close();
            }
            catch (Exception ex)
            {

            }
            return lista;

        }

        public static List<TehnicarStolicePregled> VratiListuStolicaZaTehnicara(string JMBGTehnicara)
        {
            List<TehnicarStolicePregled> lista = new List<TehnicarStolicePregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Stolica> listaS = from p in s.Query<Stolica>()
                                              where p.DodeljeniTehnicar.JMBGNemedicinsko == JMBGTehnicara
                                              select p;

                foreach (Stolica p in listaS)
                {

                    lista.Add(new TehnicarStolicePregled(p.DodeljeniTehnicar.JMBGNemedicinsko, p.DodeljeniTehnicar.ImeNemedicinsko, p.DodeljeniTehnicar.PrezimeNemedicinsko, p.DodeljeniTehnicar.Struka, p.IdStolice, p.Proizvodjac, p.DatumProizvodnje));

                }


                s.Close();
            }
            catch (Exception ex)
            {

            }
            return lista;

        }


        public static StomatologPregled vratiStomatologInterfejs(string jmbgStomatologa)
        {
            StomatologPregled sp = new Manja_bolnica.StomatologPregled();
            try
            {
                ISession s = DataLayer.GetSession();

                Stomatolog st = s.Load<Stomatolog>(jmbgStomatologa);
                sp = new StomatologPregled(st.JMBGMedicinsko, st.ImeMedicinsko, st.PrezimeMedicinsko, st.RadniStaz, st.IntervencijeStomatolog.Count);

                s.Close();
            }
            catch (Exception ex)
            {

            }
            return sp;
        }

        public static StomatologPregled AzurirajStomatologa(StomatologPregled sp)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Stomatolog st = s.Load<Stomatolog>(sp.JMBGStomatologa);
                st.RadniStaz = sp.RadniStaz;

                s.Update(st);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {

            }
            return sp;
        }
        public static List<StolicePregled> VratiListuStolicaZaStomatologa(string JMBGStomatolog)
        {
            List<StolicePregled> lista = new List<StolicePregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<RadiNa> listaS = from p in s.Query<RadiNa>()
                                              where p.RadiNaStomatolog.JMBGMedicinsko == JMBGStomatolog
                                              select p;

                foreach (RadiNa p in listaS)
                {

                    lista.Add(new StolicePregled(p.RadiNaStomatolog.JMBGMedicinsko,p.RadiId,p.RadiNaStolica.IdStolice,p.RadiNaStolica.Proizvodjac,
                        p.RadiNaStolica.DatumProizvodnje,p.Smena,p.DatumOd,p.DatumDo));

                }


                s.Close();
            }
            catch (Exception ex)
            {

            }
            return lista;

        }
        public static RadiNaStolicaBasic vratiRadiNa(int idRadiNa)
        {
            RadiNaStolicaBasic sp = new Manja_bolnica.RadiNaStolicaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                RadiNa st = s.Load<RadiNa>(idRadiNa);
                sp = new RadiNaStolicaBasic(st.RadiId,st.Smena,st.DatumOd,st.DatumDo);

                s.Close();
            }
            catch (Exception ex)
            {

            }
            return sp;
        }

        public static RadiNaStolicaBasic AzurirajRadiNa(RadiNaStolicaBasic sp)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadiNa st = s.Load<RadiNa>(sp.IdRadiNa);
                st.Smena = sp.Smena;
                st.DatumOd = sp.DatumOd;
                st.DatumDo = sp.DatumDo;
                

                s.Update(st);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {

            }
            return sp;
        }

        public static List<HigijenicarPregled> VratiListuOdeljenjaZaHigijenicara(string JMBGHigijenicar)
        {
            List<HigijenicarPregled> lista = new List<HigijenicarPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Odrzava> listaS = from p in s.Query<Odrzava>()
                                             where p.JMBGHigijenicara.JMBGNemedicinsko == JMBGHigijenicar
                                             select p;

                foreach (Odrzava p in listaS)
                {

                    lista.Add(new HigijenicarPregled(p.JMBGHigijenicara.JMBGNemedicinsko, p.OdrzavaId,
                        p.OdeljenjeOdrzava.Sifra,p.JMBGHigijenicara.ImeNemedicinsko,p.JMBGHigijenicara.PrezimeNemedicinsko,
                        p.OdeljenjeOdrzava.Tip));

                }


                s.Close();
            }
            catch (Exception ex)
            {

            }
            return lista;

        }
    }
    /*public static RadiNaStolicaBasic DodavanjePac(RadiNaStolicaBasic sp)
    {
        try
        {
            ISession s = DataLayer.GetSession();

            RadiNa st = s.Load<RadiNa>(sp.IdRadiNa);
            st.Smena = sp.Smena;
            st.DatumOd = sp.DatumOd;
            st.DatumDo = sp.DatumDo;


            s.Update(st);
            s.Flush();

            s.Close();
        }
        catch (Exception ex)
        {

        }
        return sp;
    }*/
}
