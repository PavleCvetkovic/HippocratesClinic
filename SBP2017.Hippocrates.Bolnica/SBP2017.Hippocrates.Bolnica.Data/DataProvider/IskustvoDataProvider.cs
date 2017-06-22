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
    public class IskustvoDataProvider
    {
        public static IList<IskustvoDto> GetAll()
        {
            //st = "";
            ISession s = DataLayer.GetSession();
            IList<Iskustvo> iskustva = s.QueryOver<Iskustvo>().List();
            List<IskustvoDto> listDTO = new List<IskustvoDto>();
            foreach (Iskustvo i in iskustva)
            {
                IskustvoDto dto = new IskustvoDto()
                {
                    Id = i.Id,
                    Pozicija = i.Pozicija,
                    Institucija = i.Institucija,
                    IdZaposleni = i.Zaposleni.Id
                };
                listDTO.Add(dto);
            }
            return listDTO;
        }
    }
}
