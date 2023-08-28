using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class ElementsUCViewModel : ObservableObject
    {
        Elements _elementModel;
        public ElementsUCViewModel(Elements elementModel)
        {
            _elementModel = elementModel;
        }

        public string Id
        {
            get { return _elementModel?.id; }
            set { _elementModel.id = value; OnPropertyChanged(nameof(Id)); }
        }


        public string IdProprietaire
        {
            get { return _elementModel?.idProprietaire; }
            set { _elementModel.idProprietaire = value; OnPropertyChanged(nameof(IdProprietaire)); }
        }



        public int Rang
        {
            get { return _elementModel.rang; }
            set { _elementModel.rang = value; OnPropertyChanged(nameof(Rang)); }
        }



        public int Orientation
        {
            get { return _elementModel.orientation; }
            set { _elementModel.orientation = value; OnPropertyChanged(nameof(Orientation)); }
        }



        public int Nature
        {
            get { return _elementModel.nature; }
            set { _elementModel.nature = value; OnPropertyChanged(nameof(Nature)); }
        }



        public bool SupLogique
        {
            get { return _elementModel.supLogique; }
            set { _elementModel.supLogique = value; OnPropertyChanged(nameof(SupLogique)); }
        }



        public string NumeroCommercial
        {
            get { return _elementModel?.numeroCommercial; }
            set { _elementModel.numeroCommercial = value; OnPropertyChanged(nameof(NumeroCommercial)); }
        }



        public string IdCourse
        {
            get { return _elementModel?.idCourse; }
            set { _elementModel.idCourse = value; OnPropertyChanged(nameof(IdCourse)); }
        }



        public DateTime DateHeureModification
        {
            get { return _elementModel.dateHeureModification; }
            set { _elementModel.dateHeureModification = value; OnPropertyChanged(nameof(DateHeureModification)); }
        }
    }
}

