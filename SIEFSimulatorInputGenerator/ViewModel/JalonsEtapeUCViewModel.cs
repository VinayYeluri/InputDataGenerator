using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class JalonsEtapeUCViewModel : ObservableObject
    {
        JalonsEtapes _jalonetapeModel;
        public JalonsEtapeUCViewModel(JalonsEtapes jalonetapeModel)
        {
            _jalonetapeModel = jalonetapeModel;
        }



        public string Jalon
        {
            get { return _jalonetapeModel?.jalon; }
            set { _jalonetapeModel.jalon = value; OnPropertyChanged(nameof(Jalon)); }
        }


        public int Rang
        {
            get { return _jalonetapeModel.rang; }
            set { _jalonetapeModel.rang = value; OnPropertyChanged(nameof(Rang)); }
        }



        public string TypeJalon
        {
            get { return _jalonetapeModel?.typeJalon; }
            set { _jalonetapeModel.typeJalon = value; OnPropertyChanged(nameof(TypeJalon)); }
        }
    }
}
