using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class RoulementChildUCViewModel : ObservableObject
    {
        Roulement_child _roulementChildModel;
        public RoulementChildUCViewModel(Roulement_child roulementChildModel)
        {
            _roulementChildModel = roulementChildModel;
        }

        public string Id
        {
            get { return _roulementChildModel?.id; }
            set { _roulementChildModel.id = value; OnPropertyChanged(nameof(Id)); }
        }
        public string Source
        {
            get { return _roulementChildModel?.source; }
            set { _roulementChildModel.source = value; OnPropertyChanged(nameof(Source)); }
        }

        public string CodeEntiteOffre
        {
            get { return _roulementChildModel?.codeEntiteOffre; }
            set { _roulementChildModel.codeEntiteOffre = value; OnPropertyChanged(nameof(CodeEntiteOffre)); }
        }

        public string DateDebutValidite
        {
            get { return _roulementChildModel?.dateDebutValidite; }
            set { _roulementChildModel.dateDebutValidite = value; OnPropertyChanged(nameof(DateDebutValidite)); }
        }

        public string DateFinValidite
        {
            get { return _roulementChildModel?.dateFinValidite; }
            set { _roulementChildModel.dateFinValidite = value; OnPropertyChanged(nameof(DateFinValidite)); }
        }

        public string NumeroRoulement
        {
            get { return _roulementChildModel?.numeroRoulement; }
            set { _roulementChildModel.numeroRoulement = value; OnPropertyChanged(nameof(NumeroRoulement)); }
        }
    }
}
