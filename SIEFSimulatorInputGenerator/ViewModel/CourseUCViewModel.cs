using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class CourseUCViewModel : ObservableObject
    {
        Course _courseModel;

        public CourseUCViewModel(Course courseModel)
        {
            _courseModel = courseModel;
        }

        private string _idCourse;
        public string IdCourse
        {
            get { return _courseModel?.idCourse; }
            set
            {
                _courseModel.idCourse = value;
                OnPropertyChanged(nameof(IdCourse));
            }
        }

        private string _refCourse;
        public string RefCourse
        {
            get { return _courseModel?.refCourse; }
            set
            {
                _courseModel.refCourse = value;
                OnPropertyChanged(nameof(RefCourse));
            }
        }

        private string _dateCourse;
        public string DateCourse
        {
            get { return _courseModel?.dateCourse; }
            set
            {
                _courseModel.dateCourse = value;
                OnPropertyChanged(nameof(DateCourse));
            }
        }

        private string _codeMission;
        public string CodeMission
        {
            get { return _courseModel?.codeMission; }
            set
            {
                _courseModel.codeMission = value;
                OnPropertyChanged(nameof(CodeMission));
            }
        }

        private string _uOTransporteur;
        public string UOTransporteur
        {
            get { return _courseModel?.uoTransporteur; }
            set
            {
                _courseModel.uoTransporteur = value;
                OnPropertyChanged(nameof(UOTransporteur));
            }
        }

        private string _typeReference;
        public string TypeReference
        {
            get { return _courseModel?.typeReference; }
            set
            {
                _courseModel.typeReference = value;
                OnPropertyChanged(nameof(TypeReference));
            }
        }

        private string _technicalId;
        public string TechnicalId
        {
            get { return _courseModel?.technicalId; }
            set
            {
                _courseModel.technicalId = value;
                OnPropertyChanged(nameof(TechnicalId));
            }
        }

        private DateTime _destinationUtcHoraire;
        public DateTime DestinationUtcHoraire
        {
            get { return _courseModel.destinationUtcHoraire; }
            set
            {
                _courseModel.destinationUtcHoraire = value;
                OnPropertyChanged(nameof(DestinationUtcHoraire));
            }
        }

        private string _destinationJalon;
        public string DestinationJalon
        {
            get { return _courseModel?.destinationJalon; }
            set
            {
                _courseModel.destinationJalon = value;
                OnPropertyChanged(nameof(DestinationJalon));
            }
        }

        private string _nomCourse;
        public string NomCourse
        {
            get { return _courseModel?.nomCourse; }
            set
            {
                _courseModel.nomCourse = value;
                OnPropertyChanged(nameof(NomCourse));
            }
        }

        private string _type;
        public string Type
        {
            get { return _courseModel?.type; }
            set
            {
                _courseModel.type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        private string _statutCourse;
        public string StatutCourse
        {
            get { return _courseModel?.statutCourse; }
            set
            {
                _courseModel.statutCourse = value;
                OnPropertyChanged(nameof(StatutCourse));
            }
        }

        private string _mode;
        public string Mode
        {
            get { return _courseModel?.mode; }
            set
            {
                _courseModel.mode = value;
                OnPropertyChanged(nameof(Mode));
            }
        }

        private string _typedeCourse;
        public string TypedeCourse
        {
            get { return _courseModel?.typeDeCourse; }
            set
            {
                _courseModel.typeDeCourse = value;
                OnPropertyChanged(nameof(TypedeCourse));
            }
        }

        private DateTime _uTCDateMajCourse;
        public DateTime UTCDateMajCourse
        {
            get { return _courseModel.utcDateMajCourse; }
            set
            {
                _courseModel.utcDateMajCourse = value;
                OnPropertyChanged(nameof(UTCDateMajCourse));
            }
        }

        private string _source;
        public string Source
        {
            get { return _courseModel?.source; }
            set
            {
                _courseModel.source = value;
                OnPropertyChanged(nameof(Source));
            }
        }

        private string _ecartMoins1a17h;
        public string EcartMoins1a17h
        {
            get { return _courseModel?.ecartJMoins1a17h; }
            set
            {
                _courseModel.ecartJMoins1a17h = value;
                OnPropertyChanged(nameof(EcartMoins1a17h));
            }
        }

        private DateTime _origineUtcHoraire;
        public DateTime OrigineUtcHoraire
        {
            get { return _courseModel.origineUtcHoraire; }
            set
            {
                _courseModel.origineUtcHoraire = value;
                OnPropertyChanged(nameof(OrigineUtcHoraire));
            }
        }

        private string _origineJalon;
        public string OrigineJalon
        {
            get { return _courseModel?.origineJalon; }
            set
            {
                _courseModel.origineJalon = value;
                OnPropertyChanged(nameof(OrigineJalon));
            }
        }

        private string _compositionCourtLong;
        public string CompositionCourtLong
        {
            get { return _courseModel?.compositionCourtLong; }
            set
            {
                _courseModel.compositionCourtLong = value;
                OnPropertyChanged(nameof(CompositionCourtLong));
            }
        }
    }
}
