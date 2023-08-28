using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class PointsJalonnementUCViewModel : ObservableObject
    {
        PointsJalonnement _pointsJalonnementModel;
        public PointsJalonnementUCViewModel(PointsJalonnement pointsJalonnementModel)
        {
            _pointsJalonnementModel = pointsJalonnementModel;
        }

        private string _ref;
        public string Ref
        {
            get { return _pointsJalonnementModel?.@ref; }
            set
            {
                _pointsJalonnementModel.@ref = value;
                OnPropertyChanged(nameof(Ref));
            }
        }

        private int _rang;
        public int Rang
        {
            get { return _pointsJalonnementModel.rang; }
            set
            {
                _pointsJalonnementModel.rang = value;
                OnPropertyChanged(nameof(Rang));
            }
        }

        private string _refCourse;
        public string RefCourse
        {
            get { return _pointsJalonnementModel?.refCourse; }
            set
            {
                _pointsJalonnementModel.refCourse = value;
                OnPropertyChanged(nameof(RefCourse));
            }
        }

        private bool _estSupprimee;
        public bool EstSupprimee
        {
            get { return _pointsJalonnementModel.estSupprimee; }
            set
            {
                _pointsJalonnementModel.estSupprimee = value;
                OnPropertyChanged(nameof(EstSupprimee));
            }
        }

        private string _clcclc;
        public string Clcclc
        {
            get { return _pointsJalonnementModel?.clcclc; }
            set
            {
                _pointsJalonnementModel.clcclc = value;
                OnPropertyChanged(nameof(Clcclc));
            }
        }

        private string _refZoneEmbarquement;
        public string RefZoneEmbarquement
        {
            get { return _pointsJalonnementModel?.refZoneEmbarquement; }
            set
            {
                _pointsJalonnementModel.refZoneEmbarquement = value;
                OnPropertyChanged(nameof(RefZoneEmbarquement));
            }
        }
    }
}
