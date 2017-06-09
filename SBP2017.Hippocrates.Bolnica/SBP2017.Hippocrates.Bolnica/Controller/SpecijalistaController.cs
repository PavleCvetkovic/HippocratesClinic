using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using SBP2017.Hippocrates.Bolnica.Model;

namespace SBP2017.Hippocrates.Bolnica.Controller
{
    public class SpecijalistaController : SestraBolnicarController
    {
        public void scheduleNewExam(PacijentKlinickogCentra patient, int time)
        {
            (model as SpecijalistaModel).scheduleNewExam(patient, time); //treba da preradim da vraca bool
        }
    }
}
