using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class AffectationMaterielUCViewModel : ObservableObject
    {
        AffectationMateriel _affectationModel;
        public AffectationMaterielUCViewModel(AffectationMateriel affectationModel)
        {
            _affectationModel = affectationModel;
        }

        public string Id
        {
            get { return _affectationModel?.id; }
            set { _affectationModel.id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string NatureAffectation
        {
            get { return _affectationModel?.natureAffectation; }
            set { _affectationModel.natureAffectation = value; OnPropertyChanged(nameof(NatureAffectation)); }
        }

        public bool SupLogique
        {
            get { return _affectationModel.supLogique; }
            set { _affectationModel.supLogique = value; OnPropertyChanged(nameof(SupLogique)); }
        }

        public DateTime DateHeureModification
        {
            get { return _affectationModel.dateHeureModification; }
            set { _affectationModel.dateHeureModification = value; OnPropertyChanged(nameof(DateHeureModification)); }
        }
    }
}
