using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Manja_bolnica.Entiteti;
using Manja_bolnica.DTO;
using NHibernate.Linq;

namespace Manja_bolnica
{
    public class DataProvider
    {

        #region Odeljenje

        public IList<OdeljenjeView> GetOdeljenjaView()
        {
            IList<OdeljenjeView> odeljenja = new List<OdeljenjeView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Odeljenje> od = from odeljenje in s.Query<Odeljenje>() select odeljenje;

                foreach (Odeljenje odelj in od)
                {
                    odeljenja.Add(new OdeljenjeView(odelj));
                }

                return odeljenja;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public OdeljenjeView GetOdeljenjeView(int sifra)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Odeljenje od = s.Load<Odeljenje>(sifra);
                if (od == null)
                    return null;
                OdeljenjeView ov = new OdeljenjeView(od);
                return ov;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public int AddOdeljenje(Odeljenje od)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(od);
                s.Flush();
                s.Close();
                return 1;
            }

            catch (Exception)
            {
                return -1;
            }
        }

        public int UpdateOdeljenje(int sifra, Odeljenje od)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Odeljenje odeljenje = s.Load<Odeljenje>(sifra);
                odeljenje.Tip = od.Tip;
                odeljenje.DatumIzgradnje = od.DatumIzgradnje;

                s.Update(odeljenje);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int DeleteOdeljenje(int sifra)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Odeljenje od = s.Load<Odeljenje>(sifra);
                s.Delete(od);
                s.Flush();
                s.Close();
                return 1;
            }

            catch (Exception)
            {
                return -1;
            }
        }

        #endregion

        #region Pacijent
        public IList<StacionarniView> GetStacionarniView()
        {
            IList<StacionarniView> stacionarni = new List<StacionarniView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Stacionarno> stac = from stacionar in s.Query<Stacionarno>() select stacionar;

                foreach (Stacionarno st in stac)
                {
                    stacionarni.Add(new StacionarniView(st));
                }

                return stacionarni;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public StacionarniView GetStacionarnoView(string jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Stacionarno stac = s.Load<Stacionarno>(jmbg);
                if (stac == null)
                    return null;
                StacionarniView st = new StacionarniView(stac);
                return st;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public IList<AmbulantniView> GetAmbulantniView()
        {
            IList<AmbulantniView> ambulantni = new List<AmbulantniView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Ambulantno> amb = from ambul in s.Query<Ambulantno>() select ambul;

                foreach (Ambulantno am in amb)
                {
                    ambulantni.Add(new AmbulantniView(am));
                }

                return ambulantni;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public AmbulantniView GetAmbulantnoView(string jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Ambulantno am = s.Load<Ambulantno>(jmbg);
                if (am == null)
                    return null;
                AmbulantniView a = new AmbulantniView(am);
                return a;
            }

            catch (Exception)
            {
                return null;
            }
        }

       

        public int AddStacionarno(Stacionarno st)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(st);
                s.Flush();
                s.Close();
                return 1;
            }

            catch (Exception)
            {
                return -1;
            }
        }

        public int AddAmbulantno(Ambulantno am)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(am);
                s.Flush();
                s.Close();
                return 1;
            }

            catch (Exception)
            {
                return -1;
            }
        }

        public int UpdateStacionarno(string jmbg, Stacionarno st)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Stacionarno stac = s.Load<Stacionarno>(jmbg);
                stac.ImePacijenta = st.ImePacijenta;
                stac.PrezimePacijenta = st.PrezimePacijenta;
                s.Update(stac);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int UpdateAmbulantno(string jmbg, Ambulantno am)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Ambulantno amb = s.Load<Ambulantno>(jmbg);
                amb.ImePacijenta = am.ImePacijenta;
                amb.PrezimePacijenta = am.PrezimePacijenta;
                amb.Ulica = am.Ulica;
                amb.Broj = am.Broj;
                s.Update(amb);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int DeletePacijent(string jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Pacijent p = s.Load<Pacijent>(jmbg);
                s.Delete(p);
                s.Flush();
                s.Close();
                return 1;
            }

            catch (Exception)
            {
                return -1;
            }
        }

        #endregion

        #region Medicinsko
        public IList<LekarView> GetLekariView()
        {
            IList<LekarView> lekari = new List<LekarView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Lekar> lek = from lekar in s.Query<Lekar>() select lekar;

                foreach (Lekar l in lek)
                {
                    lekari.Add(new LekarView(l));
                }

                return lekari;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public LekarView GetLekarView(string jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Lekar lek = s.Load<Lekar>(jmbg);
                if (lek == null)
                    return null;
                LekarView lv = new LekarView(lek);
                return lv;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public IList<SpecijalistaView> GetSpecijalistiView()
        {
            IList<SpecijalistaView> specijaliste = new List<SpecijalistaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Specijalista> sp = from spec in s.Query<Specijalista>() select spec;

                foreach (Specijalista spe in sp)
                {
                    specijaliste.Add(new SpecijalistaView(spe));
                }

                return specijaliste;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public SpecijalistaView GetSpecijalistaView(string jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Specijalista spec = s.Load<Specijalista>(jmbg);
                if (spec == null)
                    return null;
                SpecijalistaView sp = new SpecijalistaView(spec);
                return sp;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public IList<StomatologView> GetStomatoloziView()
        {
            IList<StomatologView> stomatolozi = new List<StomatologView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Stomatolog> st = from stom in s.Query<Stomatolog>() select stom;

                foreach (Stomatolog stomat in st)
                {
                    stomatolozi.Add(new StomatologView(stomat));
                }

                return stomatolozi;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public StomatologView GetStomatologView(string jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Stomatolog stom = s.Load<Stomatolog>(jmbg);
                if (stom == null)
                    return null;
                StomatologView st = new StomatologView(stom);
                return st;
            }

            catch (Exception)
            {
                return null;
            }
        }

        

        public int AddLekar(Lekar lek)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(lek);
                s.Flush();
                s.Close();
                return 1;
            }

            catch (Exception)
            {
                return -1;
            }
        }

        public int AddStomatolog(Stomatolog st)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(st);
                s.Flush();
                s.Close();
                return 1;
            }

            catch (Exception)
            {
                return -1;
            }
        }

        public int AddSpecijalista(Specijalista sp)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(sp);
                s.Flush();
                s.Close();
                return 1;
            }

            catch (Exception)
            {
                return -1;
            }
        }

        public int UpdateLekar(string jmbg, Lekar lek)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Lekar lekar = s.Load<Lekar>(jmbg);
                lekar.ImeMedicinsko = lek.ImeMedicinsko;
                lekar.PrezimeMedicinsko = lek.PrezimeMedicinsko;
                lekar.RadniStaz = lek.RadniStaz;
                lekar.BrojOrdinacije = lek.BrojOrdinacije;

                s.Update(lekar);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int UpdateStomatolog(string jmbg, Stomatolog st)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Stomatolog stom = s.Load<Stomatolog>(jmbg);
                stom.ImeMedicinsko = st.ImeMedicinsko;
                stom.PrezimeMedicinsko = st.PrezimeMedicinsko;
                stom.RadniStaz = st.RadniStaz;

                s.Update(stom);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int UpdateSpecijalista(string jmbg, Specijalista st)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Specijalista spec = s.Load<Specijalista>(jmbg);
                spec.ImeMedicinsko = st.ImeMedicinsko;
                spec.PrezimeMedicinsko = st.PrezimeMedicinsko;
                spec.RadniStaz = st.RadniStaz;
                spec.Specijalnost = st.Specijalnost;

                s.Update(spec);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }


        public int DeleteMedicinsko(string jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Medicinsko m = s.Load<Medicinsko>(jmbg);
                s.Delete(m);
                s.Flush();
                s.Close();
                return 1;
            }

            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        #region Nemedicinsko
        public IList<TehnicarView> GetTehnicariView()
        {
            IList<TehnicarView> tehnicari = new List<TehnicarView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Tehnicar> teh = from tehn in s.Query<Tehnicar>() select tehn;

                foreach (Tehnicar t in teh)
                {
                    tehnicari.Add(new TehnicarView(t));
                }

                return tehnicari;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public TehnicarView GetTehnicarView(string jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Tehnicar teh = s.Load<Tehnicar>(jmbg);
                if (teh == null)
                    return null;
                TehnicarView tv = new TehnicarView(teh);
                return tv;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public IList<HigijenicarView> GetHigijenicariView()
        {
            IList<HigijenicarView> higijenicari = new List<HigijenicarView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Higijenicar> hig = from higijenicar in s.Query<Higijenicar>() select higijenicar;

                foreach (Higijenicar h in hig)
                {
                    higijenicari.Add(new HigijenicarView(h));
                }

                return higijenicari;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public HigijenicarView GetHigijenicarView(string jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Higijenicar hig = s.Load<Higijenicar>(jmbg);
                if (hig == null)
                    return null;
                HigijenicarView h = new HigijenicarView(hig);
                return h;
            }

            catch (Exception)
            {
                return null;
            }
        }
      


        public int AddTehnicar(Tehnicar teh)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(teh);
                s.Flush();
                s.Close();
                return 1;
            }

            catch (Exception)
            {
                return -1;
            }
        }

        public int AddHigijenicar(Higijenicar hig)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(hig);
                s.Flush();
                s.Close();
                return 1;
            }

            catch (Exception)
            {
                return -1;
            }
        }

        public int UpdateTehnicar(string jmbg, Tehnicar teh)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Tehnicar tehnicar = s.Load<Tehnicar>(jmbg);
                tehnicar.ImeNemedicinsko = teh.ImeNemedicinsko;
                tehnicar.PrezimeNemedicinsko = teh.PrezimeNemedicinsko;
                tehnicar.Struka = teh.Struka;
                s.Update(tehnicar);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int UpdateHigijenicar(string jmbg, Higijenicar hig)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Higijenicar higijenicar = s.Load<Higijenicar>(jmbg);
                higijenicar.ImeNemedicinsko = hig.ImeNemedicinsko;
                higijenicar.PrezimeNemedicinsko = hig.PrezimeNemedicinsko;

                s.Update(higijenicar);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int DeleteNemedicinsko(string jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Nemedicinsko n = s.Load<Nemedicinsko>(jmbg);
                s.Delete(n);
                s.Flush();
                s.Close();
                return 1;
            }

            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        #region Stolica
        public IList<StolicaView> GetStoliceView()
        {
            IList<StolicaView> stolice = new List<StolicaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Stolica> st = from stolica in s.Query<Stolica>() select stolica;

                foreach (Stolica stol in st)
                {
                    stolice.Add(new StolicaView(stol));
                }

                return stolice;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public StolicaView GetStolicaView(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Stolica st = s.Load<Stolica>(id);
                if (st == null)
                    return new StolicaView();

                return new StolicaView(st);
            }

            catch (Exception)
            {
                return null;
            }
        }

        public int AddStolica(Stolica st)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(st);
                s.Flush();
                s.Close();
                return 1;
            }

            catch (Exception)
            {
                return -1;
            }
        }

        public int UpdateStolica(int id, Stolica st)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Stolica stolica = s.Load<Stolica>(id);
                stolica.Proizvodjac = st.Proizvodjac;
                stolica.DatumProizvodnje = st.DatumProizvodnje;

                s.Update(stolica);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int DeleteStolica(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Stolica stolica = s.Load<Stolica>(id);
                s.Delete(stolica);
                s.Flush();
                s.Close();
                return 1;
            }

            catch (Exception)
            {
                return -1;
            }
        }

        #endregion
    }
}
