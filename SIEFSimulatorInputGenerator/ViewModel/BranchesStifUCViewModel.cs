using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class BranchesStifUCViewModel : ObservableObject
    {
        BranchesStif _branchesStifModel;
        public BranchesStifUCViewModel(BranchesStif branchesStifModel)
        {
            _branchesStifModel = branchesStifModel;
        }

        private string _code;
        public string Code
        {
            get { return _branchesStifModel?.code; }
            set
            {
                _branchesStifModel.code = value;
                OnPropertyChanged(nameof(Code));
            }
        }

        private string _type;
        public string Type
        {
            get { return _branchesStifModel?.type; }
            set
            {
                _branchesStifModel.type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        private string _sens;
        public string Sens
        {
            get { return _branchesStifModel?.sens; }
            set
            {
                _branchesStifModel.sens = value;
                OnPropertyChanged(nameof(Sens));
            }
        }
    }
}
