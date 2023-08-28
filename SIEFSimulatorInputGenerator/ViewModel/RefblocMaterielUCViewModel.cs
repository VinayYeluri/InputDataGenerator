using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class RefblocMaterielUCViewModel : ObservableObject
    {
        RefblocMateriel _refblocModel;
        public RefblocMaterielUCViewModel(RefblocMateriel refblocModel)
        {
            _refblocModel = refblocModel;
        }

        public string CleMaterielPhysique
        {
            get { return _refblocModel?.cleMaterielPhysique; }
            set { _refblocModel.cleMaterielPhysique = value; OnPropertyChanged(nameof(CleMaterielPhysique)); }
        }

        public string IdentifiantEVN
        {
            get { return _refblocModel?.identifiantEVN; }
            set { _refblocModel.identifiantEVN = value; OnPropertyChanged(nameof(IdentifiantEVN)); }
        }

        public string NumeroInterneEF
        {
            get { return _refblocModel?.numeroInterneEF; }
            set { _refblocModel.numeroInterneEF = value; OnPropertyChanged(nameof(NumeroInterneEF)); }
        }
    }
}
