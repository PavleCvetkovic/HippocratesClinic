using NHibernate;
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects;
using SBP2017.Hippocrates.Bolnica.Data.DataProvider;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace SBP2017.Hippocrates.Bolnica.Data.DataProvider
{
    public class SmenaDataProvider
    {
        public static IList<SmenaDto> GetAll()
        {
            ISession s = DataLayer.GetSession();
            IList<Smena> smenalist = s.QueryOver<Smena>().List<Smena>();
            List<SmenaDto> stolist = new List<SmenaDto>();
            foreach (Smena smena in smenalist)
            {
                SmenaDto smenadto = new SmenaDto()
                {
                    IdZaposlenog = smena.Zaposleni.Id,
                    DatumOd = smena.DatumOd.ToString(),
                    DatumDo = smena.DatumDo.ToString(),
                    TipSmene = smena.TipSmene,
                    Id = smena.Id
                };
                stolist.Add(smenadto);
            }
            s.Close();
            return stolist;
        }

        public static SmenaDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            Smena smena = s.Get<Smena>(id);
            if (smena == null)
            {
                s.Close();
                found = false;
                return new SmenaDto();
            }

            SmenaDto dto = new SmenaDto()
            {
                IdZaposlenog = smena.Zaposleni.Id,
                DatumOd = smena.DatumOd.ToString(),
                DatumDo = smena.DatumDo.ToString(),
                TipSmene = smena.TipSmene,
                Id = smena.Id
            };
            s.Close();
            return dto;
        }

        public static bool AddSmena(SmenaDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            Smena smena = new Smena();
            smena.TipSmene = dto.TipSmene;
            smena.Zaposleni = s.Load<Zaposleni>(dto.IdZaposlenog);
            smena.DatumOd = DateTime.Parse(dto.DatumOd);
            smena.DatumDo = DateTime.Parse(dto.DatumDo);
            try
            {
                s.Save(smena);
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

        public static bool UpdateSmena(int id, SmenaDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            Smena smena = s.Get<Smena>(id);
            if (smena == null)
                smena = new Smena();

            smena.TipSmene = dto.TipSmene;
            smena.Zaposleni = s.Load<Zaposleni>(dto.IdZaposlenog);
            smena.DatumOd = DateTime.Parse(dto.DatumOd);
            smena.DatumDo = DateTime.Parse(dto.DatumDo);
            try
            {
                s.Save(smena);
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
      
        public static bool DeleteSmena(int id, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno obrisan objekat";

            Smena smena = s.Get<Smena>(id);
            smena.Zaposleni.Smene.Remove(smena);
            smena.Zaposleni = null;
            try
            {
                s.Delete(smena);
                s.Flush();
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                s.Close();
                success = "Greska prilikom brisanja " + ex.Message;
                return false;
            }
        }
    }
}
