using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class EtapesSupervisionUCViewModel : ObservableObject
    {
        EtapesSupervision _etapesSupervisionModel;
        public EtapesSupervisionUCViewModel(EtapesSupervision etapesSupervisionModel)
        {
            _etapesSupervisionModel = etapesSupervisionModel;
        }
        private string _jalonDebut;
        public string JalonDebut
        {
            get { return _etapesSupervisionModel?.jalonDebut; }
            set
            {
                _etapesSupervisionModel.jalonDebut = value;
                OnPropertyChanged(nameof(JalonDebut));
            }
        }

        private string _tCT;
        public string TCT
        {
            get { return _etapesSupervisionModel?.tct; }
            set
            {
                _etapesSupervisionModel.tct = value;
                OnPropertyChanged(nameof(TCT));
            }
        }

        private string _jalonFin;
        public string JalonFin
        {
            get { return _etapesSupervisionModel?.jalonFin; }
            set
            {
                _etapesSupervisionModel.jalonFin = value;
                OnPropertyChanged(nameof(JalonDebut));
            }
        }

        private string _uOSuperviseur;
        public string UOSuperviseur
        {
            get { return _etapesSupervisionModel?.uoSuperviseur; }
            set
            {
                _etapesSupervisionModel.uoSuperviseur = value;
                OnPropertyChanged(nameof(UOSuperviseur));
            }
        }
    }
}
