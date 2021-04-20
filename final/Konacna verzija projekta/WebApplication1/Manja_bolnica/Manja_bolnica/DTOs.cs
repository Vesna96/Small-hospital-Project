using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manja_bolnica
{
    public class OdeljenjePregled
    {
        public string JMBGSpecijalista { get; set; }
        public int Sifra { get; set; }
        public string Tip { get; set; }
        public string ImeSpecijaliste { get; set; }
        public string PrezimeSpecijaliste { get; set; }
        public string Specijalnost { get; set; }
        public int BrojPacijenata { get; set; }
        public int BrojOdeljenja { get; set; }
        public int RadniStaz { get; set; }

        public OdeljenjePregled(string jmbg,int sifra, string tip, string ime, string prezime,string specijalnost,int brojP,int brojO,int staz)
        {
            this.JMBGSpecijalista = jmbg;
            this.Sifra = sifra;
            this.Tip = tip;
            this.ImeSpecijaliste = ime;
            this.PrezimeSpecijaliste = prezime;
            this.Specijalnost = specijalnost;
            this.BrojPacijenata = brojP;
            this.BrojOdeljenja = brojO;
            this.RadniStaz = staz;
        }
    }

    public class OdeljenjeBasic
    {
        public string JMBGSpecijalista { get; set; }
        public int Sifra { get; set; }
        public string Tip { get; set; }
        public DateTime DatumIzgradnje { get; set; }

        public OdeljenjeBasic(string jmbg,int sifra, string tip, DateTime datum)
        {
            this.JMBGSpecijalista = jmbg;
            this.Sifra = sifra;
            this.Tip = tip;
            this.DatumIzgradnje = datum;
            
        }
        public OdeljenjeBasic()
        {

        }

    }

    public class StacionarniPregled
    {
        public int Sifra { get; set; }   //mozda?
        public int LeziId { get; set; }
        public string Tip { get; set; }
        public string JMBGStacionarno { get; set; }
        public string ImeStacionarno { get; set; }
        public string PrezimeStacionarno { get; set; }
        public DateTime DatumPrijema { get; set; }
        public DateTime DatumOtpusta { get; set; }

        public StacionarniPregled()
        {

        }

        public StacionarniPregled(int leziId,int Sifra,string tip,string jmbg, string ime,string prezime,DateTime dp,DateTime dOt)
        {
            this.LeziId = leziId;
            this.Sifra = Sifra;
            this.Tip = tip;
            this.JMBGStacionarno = jmbg;
            this.ImeStacionarno = ime;
            this.PrezimeStacionarno = prezime;
            this.DatumPrijema = dp;
            this.DatumOtpusta = dOt;

        }
    }

    public class StacionarniBasic
    {
        public int LeziId { get; set; }
        public DateTime DatumPrijema { get; set; }
        public DateTime DatumOtpusta { get; set; }

        public StacionarniBasic(int leziId, DateTime dPrijem, DateTime dOtpust)
        {
            this.LeziId = leziId;
            this.DatumPrijema = dPrijem;
            this.DatumOtpusta = dOtpust;

        }
        public StacionarniBasic()
        {

        }

    }
    public class AmbulantniPregled
    {
        public string JMBGStomatologa { get; set; }
        public string ImeStomatologa { get; set; }
        public string PrezimeStomatologa { get; set; }
        public string JMBGAmbulantno { get; set; }

        public string ImeAmbulantno { get; set; }
        public string PrezimeAmbulantno { get; set; }
        public string Vrsta { get; set; }
        
        public DateTime Datum { get; set; }
        public int IntervencijaId { get; set; }

        public AmbulantniPregled()
        {

        }

        public AmbulantniPregled(string jmbgS, string imeS, string prezimeS, string jmbgA, string imeA, string prezimeA, string vrsta, DateTime datum, int idInt)
        {
            this.JMBGStomatologa = jmbgS;
            this.ImeStomatologa = imeS;
            this.PrezimeStomatologa = prezimeS;
            this.JMBGAmbulantno = jmbgA;
            this.ImeAmbulantno= imeA;
            this.PrezimeAmbulantno = prezimeA;
            this.Vrsta = vrsta;
            this.Datum = datum;
            this.IntervencijaId = idInt;

        }
    }
    public class AmbulantniBasic
    {
        public int IntervencijaiId { get; set; }
        public DateTime Datum { get; set; }
        public string Vrsta { get; set; }

        public AmbulantniBasic(int intId, DateTime datum, string vrsta)
        {
            this.IntervencijaiId = intId;
            this.Datum = datum;
            this.Vrsta = vrsta;

        }
        public AmbulantniBasic()
        {

        }

    }

    public class IntervencijaPregled
    {
        public int IdIntervencije { get; set; }
        
        public string Vrsta { get; set; }

        public DateTime Datum { get; set; }
        public string JMBGAmbulantno { get; set; }
        public string Ulica { get; set; }
        public int Broj { get; set; }
        public string ImeStomatologa { get; set; }
        public string PrezimeStomatologa { get; set; }


        public IntervencijaPregled()
        {

        }

        public IntervencijaPregled(int id, string vrsta, DateTime datum,string jmbg,string ulica, int broj,string ime,string prezime)
        {
            
            this.Vrsta = vrsta;
            this.Datum = datum;
            this.IdIntervencije = id;
            this.JMBGAmbulantno = jmbg;
            this.Ulica = ulica;
            this.Broj = broj;
            this.ImeStomatologa = ime;
            this.PrezimeStomatologa = prezime;

        }


    }
    public class LekarPacijentPregled
    {
        public string JMBGLekara { get; set; }

        public string ImeLekara { get; set; }

        public string PrezimeLekara { get; set; }
        public int RadniStaz { get; set; }
        public int BrojOrdinacije { get; set; }
        public string JMBGPacijenta { get; set; }
        public string ImePacijenta { get; set; }
        public string PrezimePacijenta { get; set; }


        public LekarPacijentPregled()
        {

        }

        public LekarPacijentPregled(string jmbgL,string imeL,string prezimeL,int staz,int ordinacija,string jmbgP,string imeP,string prezimeP)
        {

            this.JMBGLekara = jmbgL;
            this.ImeLekara = imeL;
            this.PrezimeLekara = prezimeL;
            this.RadniStaz = staz;
            this.BrojOrdinacije = ordinacija;
            this.JMBGPacijenta = jmbgP;
            this.ImePacijenta = imeP;
            this.PrezimePacijenta = prezimeP;

        }


    }

    public class TehnicarStolicePregled
    {
        public string JMBGTehnicara { get; set; }

        public string ImeTehnicara { get; set; }

        public string PrezimeTehnicara { get; set; }
        public string Struka { get; set; }
        public int IdStolice { get; set; }
        public string Proizvodjac { get; set; }
        public DateTime Datum { get; set; }
        
        public TehnicarStolicePregled()
        {

        }

        public TehnicarStolicePregled(string jmbg, string ime, string prezime, string struka, int id, string proizvodjac, DateTime datum)
        {

            this.JMBGTehnicara = jmbg;
            this.ImeTehnicara = ime;
            this.PrezimeTehnicara = prezime;
            this.Struka = struka;
            this.IdStolice = id;
            this.Proizvodjac = proizvodjac;
            this.Datum = datum;
           

        }


    }

    public class StomatologPregled
    {
        public string JMBGStomatologa { get; set; }

        public string ImeStomatologa { get; set; }

        public string PrezimeStomatologa { get; set; }
        public int RadniStaz { get; set; }
        public int BrojIntervencija { get; set; }

        public StomatologPregled()
        {

        }

        public StomatologPregled(string jmbg, string ime, string prezime, int staz, int broj)
        {

            this.JMBGStomatologa = jmbg;
            this.ImeStomatologa = ime;
            this.PrezimeStomatologa = prezime;
            this.RadniStaz = staz;
            this.BrojIntervencija = broj;
            

        }


    }
    public class StolicePregled
    {
        public string JMBGStomatologa { get; set; }

        public int IdRadiNa { get; set; }

        public int IdStolice { get; set; }
        public string Proizvodjac { get; set; }
        public DateTime DatumProizvodnje { get; set; }
        public string Smena{ get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }

        public StolicePregled()
        {

        }

        public StolicePregled(string jmbg, int idRadiNa,int idStolica, string proizvodjac,DateTime datumPr,string smena,DateTime datumOd,DateTime datumDo)
        {

            this.JMBGStomatologa = jmbg;
            this.IdRadiNa = idRadiNa;
            this.IdStolice = idStolica;
            this.Proizvodjac = proizvodjac;
            this.DatumProizvodnje = datumPr;
            this.Smena = smena;
            this.DatumOd = datumOd;
            this.DatumDo = datumDo;


        }


    }
    public class RadiNaStolicaBasic
    {
        

        public int IdRadiNa { get; set; }
       
        public string Smena { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }

        public RadiNaStolicaBasic()
        {

        }

        public RadiNaStolicaBasic(int idRadiNa, string smena, DateTime datumOd, DateTime datumDo)
        {

            
            this.IdRadiNa = idRadiNa;
            this.Smena = smena;
            this.DatumOd = datumOd;
            this.DatumDo = datumDo;


        }


    }
    public class HigijenicarPregled
    {
        public string JMBGHigijenicar { get; set; }

        public int IdOdrzava { get; set; }

        public int SifraOdeljenja { get; set; }
        
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string TipOdeljenja { get; set; }
        

        public HigijenicarPregled()
        {

        }

        public HigijenicarPregled(string jmbg, int idOdrzava, int sifra, string ime, string prezime, string tip)
        {

            this.JMBGHigijenicar = jmbg;
            this.IdOdrzava = idOdrzava;
            this.SifraOdeljenja = sifra;
            this.Ime = ime;
            this.Prezime = prezime;
            this.TipOdeljenja = tip;


        }

        /*public class DodavanjePacijent
        {


            public string JMBGLekar { get; set; }

            public string JMBGPacijent { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Tip { get; set; }
            public string Ulica { get; set; }
            public int Broj { get; set; }
           
            public DodavanjePacijent()
            {

            }

            public DodavanjePacijent(string jmbgL,string jmbgP,string ime,string prezime,string tip,string ulica, int broj)
            {
                this.JMBGLekar = jmbgL;
                this.JMBGPacijent = jmbgP;
                this.Ime = ime;
                this.Prezime = prezime;
                this.Tip = tip;
                this.Ulica = ulica;
                this.Broj = broj;
                
            }


        }*/
    }
} 
