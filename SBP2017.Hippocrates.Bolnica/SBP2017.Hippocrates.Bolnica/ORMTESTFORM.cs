using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using SBP2017.Hippocrates.Bolnica.Data;
using NHibernate;
using MetroFramework.Forms;
namespace SBP2017.Hippocrates.Bolnica
{
    public partial class ORMTESTFORM : Form
    {
        public ORMTESTFORM()
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
            
            Ugovor u = new Ugovor()
            {
                BrojSatiNedeljno = 40,
                KlinickiCentar = kc,
                Plata = 700000,
                Pozicija = "DIREKTOR",
                TipIsplate = "NEDELJNO",
                TipUgovora = "STALNO",
                Zaposleni = sp
            };
            sp.Ugovor = u;
            kc.Ugovori.Add(u);
            
            s.Save(kc);
            s.Save(sp);
            s.Flush();
            s.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            IList<Klinika> k = s.QueryOver<Klinika>().Where(x=>x.Telefon == "121414").List<Klinika>();
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
    }
}
