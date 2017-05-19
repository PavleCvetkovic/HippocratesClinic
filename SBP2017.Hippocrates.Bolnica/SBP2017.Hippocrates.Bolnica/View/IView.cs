using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.Controller;
using SBP2017.Hippocrates.Bolnica.Model;

namespace SBP2017.Hippocrates.Bolnica.View
{
    public interface IView
    {
        void AddControler(IController controller);
        void AttachToModel(IModel model);
        void Update();
    }
}
