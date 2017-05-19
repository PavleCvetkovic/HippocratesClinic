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
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql;

namespace SBP2017.Hippocrates.Bolnica
{
    public partial class OrmTest : Form
    {
        public OrmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            KlinickiCentar kc = new KlinickiCentar()
            {
                Ime = "ORM TEST",
                Lokacija = "ORM TEST"
            };
            Klinika k = new Klinika()
            {
                KlinickiCentar = kc,
                Telefon = "121414",
                Lokacija = "TEST",
                Naziv = "AAaaa",
            };
            kc.Klinike.Add(k);

            Specijalista sp = new Specijalista()
            {
                Ime = "TEST",
                Adresa = "test",
                BrojOrdinacije = "1111",
                DatumRodjenja = new DateTime(1980, 10, 10),
                JMBG = "1234567890123",
                Pol = "M",
                Prezime = "TEST",
                Telefon = "TEST",
                Klinika = k,
                Password = "TEST"
            };
            Sestra sestra = new Sestra()
            {
                Ime = "TestSestra",
                Prezime = "Prezime",
                Adresa = "NekaLokacija",
                Telefon = "381613332221",
                Pol = "Z",
                DatumRodjenja = new DateTime(1985, 10, 10),
                JMBG = "1010985001124",
                Password = "TEST",
                Klinika = k
            };
            sestra.TipSestre = "MLAĐA";

            Ugovor u1 = new Ugovor()
            {
                BrojSatiNedeljno = 40,
                KlinickiCentar = kc,
                Plata = 700000,
                Pozicija = "DIREKTOR",
                TipIsplate = "NEDELJNO",
                TipUgovora = "STALNO",
                Zaposleni = sp
            };

            Ugovor u2 = new Ugovor()
            {
                BrojSatiNedeljno = 40,
                KlinickiCentar = kc,
                Plata = 35000,
                Pozicija = "MLAĐA SESTRA",
                TipIsplate = "MESEČNO",
                TipUgovora = "STALNO",
                Zaposleni = sestra
            };
            sp.Ugovor = u1;
            kc.Ugovori.Add(u1);
            sestra.Ugovor = u2;
            kc.Ugovori.Add(u2);

            s.Save(kc);
            s.Save(sp);
            s.Save(sestra);
            s.Flush();
            s.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            IList<Klinika> k = s.QueryOver<Klinika>().Where(x => x.Telefon == "121414").List<Klinika>();
            if (k.Count > 0)
            {

                Klinika klin = k[0];
                MagacinKlinike mk = new MagacinKlinike()
                {
                    Klinika = klin,
                };
                CentralniMagacin cm = new CentralniMagacin()
                {
                    KlinickiCentar = klin.KlinickiCentar
                };
                PotrosniMaterijal pm = new PotrosniMaterijal()
                {
                    CenaPoJedinici = 100,
                    CentralniMagacin = cm,
                    KriticniNivoZaNarucivanje = 10,
                    NacinAdministracije = "test",
                    NacinUzimanja = "test",
                    Naziv = "PM TEST",
                    Opis = "PM OPIS",
                    TipicnaDoza = "1",
                    TipMaterijala = "test",
                };
                klin.Magacin = mk;
                mk.PotrosniMaterijal.Add(pm);
                s.Save(cm);
                s.Save(pm);
                s.Save(mk);
            }

            s.Flush();
            s.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            IList<Klinika> k = s.QueryOver<Klinika>().Where(x => x.Telefon == "121414").List<Klinika>();
            if (k.Count > 0)
            {
                Klinika klin = k[0];
                ListaCekanja lc = new ListaCekanja()
                {
                    Klinika = klin
                };
                klin.ListaCekanja = lc;
                s.Save(lc);

            }
            s.Flush();
            s.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from ListaCekanja");
            IList<ListaCekanja> lc = q.List<ListaCekanja>();
            q = s.CreateQuery("from Klinika");
            IList<Klinika> k = q.List<Klinika>();
            foreach(Klinika klin in k)
            {
                MessageBox.Show(klin.ListaCekanja.Id.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from Zaposleni");
            IList<Zaposleni> zap = q.List<Zaposleni>();
            foreach(Zaposleni z in zap)
            {
                MessageBox.Show(z.Ime);
            }
            s.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            PacijentKlinickogCentra pac = new PacijentKlinickogCentra()
            {
                Ime = "TestPacijent",
                Prezime = "TEST",
                DatumRodjenja = new DateTime(1984, 2, 14),
                JMBG = "1122334455123",
                Pol = "M",
                Adresa = "TEST",
                BracniStatus = "SLOBODAN"            
            };

            Klinika kl = s.Load<Klinika>(25);
            KlinickiCentar kc = kl.KlinickiCentar;

            Krevet krevet = new Krevet()
            {
                Klinika = kl,
                KlinickiCentar = kc
            };
            kl.KoristiKrevete.Add(krevet);

            BoraviNaKlinici bnk = new BoraviNaKlinici()
            {
                DatumPrijema = new DateTime(2017,4,20),
                OcekivaniBoravak = 15,
                KrevetPacijenta = krevet,
                Pacijent = pac,
                Klinika = kl 
            };

            //pac.Klinike.Add(bnk); //<-- glup sam
            s.Update(kl);
            s.Save(pac);

            s.Flush();
            s.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            Klinika kl = s.Load<Klinika>(25);
            PotrosniMaterijal pm = s.Load<PotrosniMaterijal>(1);

            Narudzbenica nar = new Narudzbenica()
            {
                Naziv = "TEST",
                Opis = "TEST",
                ImeKlinike = kl.Naziv,
                DatumNarudzbine = new DateTime(2017,5,1),
                DatumIsporuke = new DateTime(2017,5,8),
                Klinika = kl,
                Cena = 25000,
                NaruceniMaterijal = pm,
                ImeZaposlenog = "Mira"
            };
            
            s.Save(nar);
            s.Flush();        
            s.Close();        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            KlinickiCentar kc = s.Load<KlinickiCentar>(41);

            Dobavljac d1 = new Dobavljac()
            {
                Ime = "TEST",              
            };
            d1.DobavljaMaterijal.Add(s.Load<PotrosniMaterijal>(1));
            d1.DobavljaZaKC.Add(kc);
            s.Save(d1);
            s.Flush();
            s.Close();

            ISession s1 = DataLayer.GetSession();
            KlinickiCentar kc1 = s1.Load<KlinickiCentar>(41);

            foreach (Dobavljac d in kc1.Dobavljaci)
            {
                MessageBox.Show("Dobavljac: " + d.Ime);
            }

            s1.Close();

        }
    }
}
