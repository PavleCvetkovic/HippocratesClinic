using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.Model;

namespace SBP2017.Hippocrates.Bolnica.Controller
{
    public class DirektorController : GlavnaSestraController
    {
        public DirektorController() : base()
        {
            
        }

        public bool AddSupplier(int idSupp)
        {
            return (model as DirektorModel).AddSupplier(idSupp);
        }

        public bool DeleteSupplier(int idSupp)
        {
            return (model as DirektorModel).DeleteSupplier(idSupp);
        }

        public bool AddBed(int bedId,int clinicId)
        {
            return (model as DirektorModel).addBed(bedId, clinicId);
        }

        public bool FireEmployee(int empId)
        {
            return (model as DirektorModel).FireEmployee(empId);
        }
    }
}
