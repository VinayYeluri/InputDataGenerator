using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class RoulementUCViewModel : ObservableObject
    {
        Roulement _roulementModel;
        public RoulementUCViewModel(Roulement roulementModel)
        {
            _roulementModel = roulementModel;
        }
        public string Id
        {
            get { return _roulementModel?.id; }

            set { _roulementModel.id = value; OnPropertyChanged(nameof(Id)); }
        }
        public string JourRoulement
        {
            get { return _roulementModel?.jourRoulement; }
            set { _roulementModel.jourRoulement = value; OnPropertyChanged(nameof(JourRoulement)); }
        }
        public string NumLigneRoulement
        {
            get { return _roulementModel?.numLigneRoulement; }
            set { _roulementModel.numLigneRoulement = value; OnPropertyChanged(nameof(NumLigneRoulement)); }
        }
        public int Stade
        {
            get { return _roulementModel.stade; }
            set { _roulementModel.stade = value; OnPropertyChanged(nameof(Stade)); }
        }
        public int Phase
        {
            get { return _roulementModel.phase; }
            set { _roulementModel.phase = value; OnPropertyChanged(nameof(Phase)); }
        }
        public string Source
        {
            get { return _roulementModel?.source; }
            set { _roulementModel.source = value; OnPropertyChanged(nameof(Source)); }
        }
        public DateTime DateHeureModification
        {
            get { return _roulementModel.dateHeureModification; }
            set { _roulementModel.dateHeureModification = value; OnPropertyChanged(nameof(DateHeureModification)); }
        }
    }
}
