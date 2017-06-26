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
    public class ListaCekanjaDataProvider
    {
        public static IList<ListaCekanjaDto> GetAll()
        {
            //st = "";
            ISession s = DataLayer.GetSession();
            IList<ListaCekanja> iskustva = s.QueryOver<ListaCekanja>().List();
            List<ListaCekanjaDto> listDTO = new List<ListaCekanjaDto>();
            foreach (ListaCekanja i in iskustva)
            {
                ListaCekanjaDto dto = new ListaCekanjaDto()
                {
                    Id = i.Id,
                    IdKlinika = i.Klinika == null ? -1 : i.Klinika.Id
                };
                listDTO.Add(dto);
            }
            return listDTO;
        }

        public static ListaCekanjaDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            ListaCekanja d = s.Get<ListaCekanja>(id);
            if (d == null)
            {
                s.Close();
                found = false;
                return new ListaCekanjaDto();
            }
            ListaCekanjaDto kdto = new ListaCekanjaDto()
            {
                Id = d.Id,
                IdKlinika = d.Klinika == null ? -1 : d.Klinika.Id
            };
            s.Close();
            return kdto;
        }

        public static bool Add(ListaCekanjaDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            ListaCekanja d = new ListaCekanja();

            //d.Id = dto.Id;
            d.Klinika = s.Get<Klinika>(dto.IdKlinika);
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

        public static bool Update(int id, ListaCekanjaDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            ListaCekanja obj = s.Get<ListaCekanja>(id);
            if (obj == null)
                obj = new ListaCekanja();

            //obj.Id = dto.Id;
            obj.Klinika = s.Get<Klinika>(dto.IdKlinika);
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

            ListaCekanja d = s.Get<ListaCekanja>(id);
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
