using NHibernate;
using SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.DataProvider
{
    public class PotrosniMaterijalDataProvider
    {
        public static IList<PotrosniMaterijalDto> GetAll()
        {
            //st = "";
            ISession s = DataLayer.GetSession();
            IList<PotrosniMaterijal> iskustva = s.QueryOver<PotrosniMaterijal>().List();
            List<PotrosniMaterijalDto> listDTO = new List<PotrosniMaterijalDto>();
            foreach (PotrosniMaterijal i in iskustva)
            {
                PotrosniMaterijalDto dto = new PotrosniMaterijalDto()
                {
                    Id = i.Id,
                    Naziv = i.Naziv,
                    Opis = i.Opis,
                    NacinAdministracije = i.NacinAdministracije,
                    NacinUzimanja = i.NacinUzimanja,
                    CenaPoJedinici = i.CenaPoJedinici,
                    IdCentralniMagacin = i.CentralniMagacin == null ? -1 : i.CentralniMagacin.Id,
                    KriticniNivoZaNarucivanje = i.KriticniNivoZaNarucivanje,
                    TipicnaDoza = i.TipicnaDoza,
                    TipMaterijala = i.TipMaterijala
                };
                listDTO.Add(dto);
            }
            return listDTO;
        }

        public static PotrosniMaterijalDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            PotrosniMaterijal i = s.Get<PotrosniMaterijal>(id);
            if (i == null)
            {
                s.Close();
                found = false;
                return new PotrosniMaterijalDto();
            }
            PotrosniMaterijalDto kdto = new PotrosniMaterijalDto()
            {
                Id = i.Id,
                Naziv = i.Naziv,
                Opis = i.Opis,
                NacinAdministracije = i.NacinAdministracije,
                NacinUzimanja = i.NacinUzimanja,
                CenaPoJedinici = i.CenaPoJedinici,
                IdCentralniMagacin = i.CentralniMagacin == null ? -1 : i.CentralniMagacin.Id,
                KriticniNivoZaNarucivanje = i.KriticniNivoZaNarucivanje,
                TipicnaDoza = i.TipicnaDoza,
                TipMaterijala = i.TipMaterijala
            };
            s.Close();
            return kdto;
        }

        public static bool Add(PotrosniMaterijalDto i, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            PotrosniMaterijal d = new PotrosniMaterijal();


            //d.Id = i.Id;
            //d.Id = i.Id,
            d.Naziv = i.Naziv;
            d.Opis = i.Opis;
            d.NacinAdministracije = i.NacinAdministracije;
            d.NacinUzimanja = i.NacinUzimanja;
            d.CenaPoJedinici = i.CenaPoJedinici;
            d.CentralniMagacin = s.Get<CentralniMagacin>(i.IdCentralniMagacin);
            d.KriticniNivoZaNarucivanje = i.KriticniNivoZaNarucivanje;
            d.TipicnaDoza = i.TipicnaDoza;
            d.TipMaterijala = i.TipMaterijala;
            try
            {
                s.Save(d);
                s.Flush();
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                s.Close();
                success = "Greska prilikom upisa u bazu " + ex.Message;
                return false;
            }
        }

        public static bool Update(int id, PotrosniMaterijalDto i, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            PotrosniMaterijal obj = s.Get<PotrosniMaterijal>(id);
            if (obj == null)
                obj = new PotrosniMaterijal();

            obj.Naziv = i.Naziv;
            obj.Opis = i.Opis;
            obj.NacinAdministracije = i.NacinAdministracije;
            obj.NacinUzimanja = i.NacinUzimanja;
            obj.CenaPoJedinici = i.CenaPoJedinici;
            obj.CentralniMagacin = s.Get<CentralniMagacin>(i.IdCentralniMagacin);
            obj.KriticniNivoZaNarucivanje = i.KriticniNivoZaNarucivanje;
            obj.TipicnaDoza = i.TipicnaDoza;
            obj.TipMaterijala = i.TipMaterijala;

            try
            {
                s.Save(obj);
                s.Flush();
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                s.Close();
                success = "Greska prilikom upisa u bazu " + ex.Message;
                return false;
            }
        }

        public static bool Delete(int id, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno obrisan objekat";

            PotrosniMaterijal d = s.Get<PotrosniMaterijal>(id);
            if (d == null)
            {
                success = "Ne postoji objekata sa ID: " + id;
                return false;
            }
            try
            {
                s.Delete(d);
                s.Flush();
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                s.Close();
                success = "Greska prilikom upisa u bazu " + ex.Message;
                return false;
            }
        }
    }
}
