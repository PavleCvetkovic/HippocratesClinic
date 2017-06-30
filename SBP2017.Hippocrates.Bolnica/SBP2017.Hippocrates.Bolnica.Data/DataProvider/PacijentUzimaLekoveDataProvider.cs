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
    public class PacijentUzimaLekoveDataProvider
    {
        public static IList<PacijentUzimaLekoveDto> GetAll()
        {
            //st = "";
            ISession s = DataLayer.GetSession();
            IList<PacijentUzimaLekove> iskustva = s.QueryOver<PacijentUzimaLekove>().List();
            List<PacijentUzimaLekoveDto> listDTO = new List<PacijentUzimaLekoveDto>();
            foreach (PacijentUzimaLekove i in iskustva)
            {
                PacijentUzimaLekoveDto dto = new PacijentUzimaLekoveDto()
                {
                    Id = i.Id,
                    DatumDo = i.DatumDo,
                    DatumOd = i.DatumOd,
                    IdPacijent = i.Pacijent == null ? -1 : i.Pacijent.Id,
                    IdLek = i.Lek == null ? -1 : i.Lek.Id
                };
                listDTO.Add(dto);
            }
            return listDTO;
        }

        public static PacijentUzimaLekoveDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            PacijentUzimaLekove i = s.Get<PacijentUzimaLekove>(id);
            if (i == null)
            {
                s.Close();
                found = false;
                return new PacijentUzimaLekoveDto();
            }
            PacijentUzimaLekoveDto kdto = new PacijentUzimaLekoveDto()
            {
                Id = i.Id,
                DatumDo = i.DatumDo,
                DatumOd = i.DatumOd,
                IdPacijent = i.Pacijent == null ? -1 : i.Pacijent.Id,
                IdLek = i.Lek == null ? -1 : i.Lek.Id
            };
            s.Close();
            return kdto;
        }

        public static bool Add(PacijentUzimaLekoveDto i, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            PacijentUzimaLekove d = new PacijentUzimaLekove();


            //d.Id = i.Id,
            d.DatumDo = i.DatumDo;
            d.DatumOd = i.DatumOd;
            d.Pacijent = s.Get<PacijentKlinickogCentra>(i.IdPacijent);
            d.Lek = s.Get<PotrosniMaterijal>(i.IdLek);
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

        public static bool Update(int id, PacijentUzimaLekoveDto i, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            PacijentUzimaLekove obj = s.Get<PacijentUzimaLekove>(id);
            if (obj == null)
                obj = new PacijentUzimaLekove();

            obj.DatumDo = i.DatumDo;
            obj.DatumOd = i.DatumOd;
            obj.Pacijent = s.Get<PacijentKlinickogCentra>(i.IdPacijent);
            obj.Lek = s.Get<PotrosniMaterijal>(i.IdLek);
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

            PacijentUzimaLekove d = s.Get<PacijentUzimaLekove>(id);
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
