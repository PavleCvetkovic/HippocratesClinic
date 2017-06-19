using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql;
using SBP2017.Hippocrates.Bolnica.Model;

namespace SBP2017.Hippocrates.Bolnica.Controller
{
    public class SpecijalistaController : SestraBolnicarController
    {
        public bool scheduleNewExam(int time)
        {
            return (model as SpecijalistaModel).scheduleNewExam(time);
        }

        public void SetDateTime(DateTime dt)
        {
            (model as SpecijalistaModel).DatumPretragePregleda = dt;
        }

        public void addNewMedication(int idLeka, DateTime datumDo)
        {
            (model as SpecijalistaModel).addNewMedication(idLeka, datumDo);
        }

        public void deleteMedication(int idLek)
        {
            (model as SpecijalistaModel).deleteMedication(idLek);
        }
    }
}
