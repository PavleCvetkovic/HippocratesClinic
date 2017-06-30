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
    public class DobavljacDataProvider
    {
        public static IList<DobavljacDto> GetAll()
        {
            ISession s = DataLayer.GetSession();
            IList<Dobavljac> dlist = s.QueryOver<Dobavljac>().List<Dobavljac>();
            List<DobavljacDto> dtolist = new List<DobavljacDto>();
            foreach (Dobavljac d in dlist)
            {
                DobavljacDto dto = new DobavljacDto()
                {
                    Id = d.Id,
                    Ime = d.Ime
                };
                dtolist.Add(dto);
            }
            s.Close();
            return dtolist;
        }

        public static DobavljacDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            Dobavljac d = s.Get<Dobavljac>(id);
            if (d == null)
            {
                s.Close();
                found = false;
                return new DobavljacDto();
            }
            //DobavljacDto dto = new DobavljacDto();
            //dto.Id = d.Id;
            //dto.Ime = d.Ime;
            //DobavljacDto dto = new DobavljacDto(d.Id, d.Ime);
            DobavljacDto dto = new DobavljacDto()
            {
                Id = d.Id,
                Ime = d.Ime
            };
            s.Close();
            return dto;
        }

        public static bool AddDobavljac(DobavljacDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            Dobavljac d = new Dobavljac();
            d.Id = dto.Id;
            d.Ime = dto.Ime;
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

        public static bool UpdateDobavljac(int id, DobavljacDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";
            
            Dobavljac d = s.Get<Dobavljac>(id);
            if (d == null)
                d = new Dobavljac();

            d.Id = dto.Id;
            d.Ime = dto.Ime;
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

        public static bool DeleteDobavljac(int id, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno obrisan objekat";

            Dobavljac d = s.Get<Dobavljac>(id);
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
