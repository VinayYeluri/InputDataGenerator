using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class VoiesCirculationPrevuesUCViewModel : ObservableObject
    {
        VoiesCirculationPrevue _voiesCirculationPrevueModel;
        public VoiesCirculationPrevuesUCViewModel(VoiesCirculationPrevue voiesCirculationPrevueModel)
        {
            _voiesCirculationPrevueModel = voiesCirculationPrevueModel;
        }

        private string _voieSortie;
        public string VoieSortie
        {
            get { return _voiesCirculationPrevueModel?.voieSortie; }
            set
            {
                _voiesCirculationPrevueModel.voieSortie = value;
                OnPropertyChanged(nameof(VoieSortie));
            }
        }

        private string _voieVia;
        public string VoieVia
        {
            get { return _voiesCirculationPrevueModel?.voieVia; }
            set
            {
                _voiesCirculationPrevueModel.voieVia = value;
                OnPropertyChanged(nameof(VoieVia));
            }
        }
    }
}
