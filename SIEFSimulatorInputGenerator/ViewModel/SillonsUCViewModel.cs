using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class SillonsUCViewModel : ObservableObject
    {
        Sillon _sillonModel;
        public SillonsUCViewModel(Sillon sillonModel)
        {
            _sillonModel = sillonModel;
        }

        private string _idSillon;
        public string IdSillon
        {
            get => _sillonModel?.idSillon;
            set
            {
                _sillonModel.idSillon = value;
                OnPropertyChanged(nameof(IdSillon));
            }
        }

        private string _numeroMarche;
        public string NumeroMarche
        {
            get => _sillonModel?.numeroMarche;
            set
            {
                _sillonModel.numeroMarche = value;
                OnPropertyChanged(nameof(NumeroMarche));
            }
        }

        private string _refSillon;
        public string RefSillon
        {
            get => _sillonModel?.refSillon;
            set
            {
                _sillonModel.refSillon = value;
                OnPropertyChanged(nameof(RefSillon));
            }
        }
    }
}
