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
    public class MagacinKlinikeSadrziDataProvider
    {
        public static IList<MagacinKlinikeSadrziDto> GetAll()
        {
            //st = "";
            ISession s = DataLayer.GetSession();
            IList<MagacinKlinikeSadrzi> iskustva = s.QueryOver<MagacinKlinikeSadrzi>().List();
            List<MagacinKlinikeSadrziDto> listDTO = new List<MagacinKlinikeSadrziDto>();
            foreach (MagacinKlinikeSadrzi i in iskustva)
            {
                MagacinKlinikeSadrziDto dto = new MagacinKlinikeSadrziDto()
                {
                    Id = i.Id,
                    IdMagacinKlinike = i.MagacinKlinike  == null ? -1: i.MagacinKlinike.Id,
                    IdPotrosniMaterijal = i.PotrosniMaterijal == null ? -1: i.PotrosniMaterijal.Id,
                    Kolicina = i.Kolicina
                };
                listDTO.Add(dto);
            }
            return listDTO;
        }

        public static MagacinKlinikeSadrziDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            MagacinKlinikeSadrzi d = s.Get<MagacinKlinikeSadrzi>(id);
            if (d == null)
            {
                s.Close();
                found = false;
                return new MagacinKlinikeSadrziDto();
            }
            MagacinKlinikeSadrziDto kdto = new MagacinKlinikeSadrziDto()
            {
                Id = d.Id,
                IdMagacinKlinike = d.MagacinKlinike == null ? -1 : d.MagacinKlinike.Id,
                IdPotrosniMaterijal = d.PotrosniMaterijal == null ? -1 : d.PotrosniMaterijal.Id,
                Kolicina = d.Kolicina
            };
            s.Close();
            return kdto;
        }

        public static bool Add(MagacinKlinikeSadrziDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            MagacinKlinikeSadrzi d = new MagacinKlinikeSadrzi();

            //d.Id = dto.Id; // protected set
            d.Kolicina = dto.Kolicina;
            d.PotrosniMaterijal = s.Get<PotrosniMaterijal>(dto.IdPotrosniMaterijal);
            d.MagacinKlinike = s.Get<MagacinKlinike>(dto.IdMagacinKlinike);
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

        public static bool Update(int id, MagacinKlinikeSadrziDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            MagacinKlinikeSadrzi obj = s.Get<MagacinKlinikeSadrzi>(id);
            if (obj == null)
                obj = new MagacinKlinikeSadrzi();

            obj.Kolicina = dto.Kolicina;
            obj.PotrosniMaterijal = s.Get<PotrosniMaterijal>(dto.IdPotrosniMaterijal);
            obj.MagacinKlinike = s.Get<MagacinKlinike>(dto.IdMagacinKlinike);
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

            MagacinKlinikeSadrzi d = s.Get<MagacinKlinikeSadrzi>(id);
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
