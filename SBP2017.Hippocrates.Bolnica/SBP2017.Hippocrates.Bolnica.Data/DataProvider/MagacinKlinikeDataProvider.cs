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
    public class MagacinKlinikeDataProvider
    {
        public static IList<MagacinKlinikeDto> GetAll()
        {
            //st = "";
            ISession s = DataLayer.GetSession();
            IList<MagacinKlinike> iskustva = s.QueryOver<MagacinKlinike>().List();
            List<MagacinKlinikeDto> listDTO = new List<MagacinKlinikeDto>();
            foreach (MagacinKlinike i in iskustva)
            {
                MagacinKlinikeDto dto = new MagacinKlinikeDto()
                {
                    Id = i.Id,
                    IdKlinika = i.Klinika == null ? -1 : i.Klinika.Id
                };
                listDTO.Add(dto);
            }
            return listDTO;
        }

        public static MagacinKlinikeDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            MagacinKlinike d = s.Get<MagacinKlinike>(id);
            if (d == null)
            {
                s.Close();
                found = false;
                return new MagacinKlinikeDto();
            }
            MagacinKlinikeDto kdto = new MagacinKlinikeDto()
            {
                Id = d.Id,
                IdKlinika = d.Klinika == null ? -1 : d.Klinika.Id
            };
            s.Close();
            return kdto;
        }

        public static bool Add(MagacinKlinikeDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            MagacinKlinike d = new MagacinKlinike();

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

        public static bool Update(int id, MagacinKlinikeDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            MagacinKlinike obj = s.Get<MagacinKlinike>(id);
            if (obj == null)
                obj = new MagacinKlinike();

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

            MagacinKlinike d = s.Get<MagacinKlinike>(id);
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
