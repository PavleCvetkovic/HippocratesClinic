using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.View;

namespace SBP2017.Hippocrates.Bolnica.Model
{
    public interface IModel
    {
        void AddView(IView view);
        void UpdateViews();
        void refreshData();
    }
}
