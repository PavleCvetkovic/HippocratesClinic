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
    public class PacijentiCekajuDataProvider
    {
        public static IList<PacijentiCekajuDto> GetAll()
        {
            //st = "";
            ISession s = DataLayer.GetSession();
            IList<PacijentiCekaju> iskustva = s.QueryOver<PacijentiCekaju>().List();
            List<PacijentiCekajuDto> listDTO = new List<PacijentiCekajuDto>();
            foreach (PacijentiCekaju i in iskustva)
            {
                PacijentiCekajuDto dto = new PacijentiCekajuDto()
                {
                    Id = i.Id,
                    DatumUpisa = i.DatumUpisa,
                    OcekivanoVremeCekanja = i.OcekivanoVremeCekanja,
                    IdPacijent = i.Pacijent == null ? -1 : i.Pacijent.Id,
                    IdListaCekanja = i.ListaCekanja == null ? -1 : i.ListaCekanja.Id
                };
                listDTO.Add(dto);
            }
            return listDTO;
        }

        public static PacijentiCekajuDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            PacijentiCekaju i = s.Get<PacijentiCekaju>(id);
            if (i == null)
            {
                s.Close();
                found = false;
                return new PacijentiCekajuDto();
            }
            PacijentiCekajuDto kdto = new PacijentiCekajuDto()
            {
                Id = i.Id,
                DatumUpisa = i.DatumUpisa,
                OcekivanoVremeCekanja = i.OcekivanoVremeCekanja,
                IdPacijent = i.Pacijent == null ? -1 : i.Pacijent.Id,
                IdListaCekanja = i.ListaCekanja == null ? -1 : i.ListaCekanja.Id
            };
            s.Close();
            return kdto;
        }

        public static bool Add(PacijentiCekajuDto i, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            PacijentiCekaju d = new PacijentiCekaju();


            //d.Id = i.Id;
            d.DatumUpisa = i.DatumUpisa;
            d.OcekivanoVremeCekanja = i.OcekivanoVremeCekanja;
            d.Pacijent = s.Get< PacijentKlinickogCentra> (i.IdPacijent);
            d.ListaCekanja = s.Get<ListaCekanja>(i.IdListaCekanja);
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

        public static bool Update(int id, PacijentiCekajuDto i, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            PacijentiCekaju obj = s.Get<PacijentiCekaju>(id);
            if (obj == null)
                obj = new PacijentiCekaju();

            obj.DatumUpisa = i.DatumUpisa;
            obj.OcekivanoVremeCekanja = i.OcekivanoVremeCekanja;
            obj.Pacijent = s.Get<PacijentKlinickogCentra>(i.IdPacijent);
            obj.ListaCekanja = s.Get<ListaCekanja>(i.IdListaCekanja);
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

            PacijentiCekaju d = s.Get<PacijentiCekaju>(id);
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
