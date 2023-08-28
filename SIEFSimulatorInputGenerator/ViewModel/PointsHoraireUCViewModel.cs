using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class PointsHoraireUCViewModel : ObservableObject
    {
        PointsHoraire _pointsHoraireModel;
        public PointsHoraireUCViewModel(PointsHoraire pointsHoraireModel)
        {
            _pointsHoraireModel = pointsHoraireModel;
        }

        private string _typeHoraire;
        public string TypeHoraire
        {
            get { return _pointsHoraireModel?.typeHoraire; }
            set
            {
                _pointsHoraireModel.typeHoraire = value;
                OnPropertyChanged(nameof(TypeHoraire));
            }
        }

        private string _numeroMarche;
        public string NumeroMarche
        {
            get { return _pointsHoraireModel?.numeroMarche; }
            set
            {
                _pointsHoraireModel.numeroMarche = value;
                OnPropertyChanged(nameof(NumeroMarche));
            }
        }

        private DateTime _horairePrevu;
        public DateTime HorairePrevu
        {
            get { return _pointsHoraireModel.horairePrevu; }
            set
            {
                _pointsHoraireModel.horairePrevu = value;
                OnPropertyChanged(nameof(HorairePrevu));
            }
        }
    }
}
