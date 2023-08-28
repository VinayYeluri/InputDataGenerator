using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class EtapeUCViewModel : ObservableObject
    {
        Etape _etapeModel;
        public EtapeUCViewModel(Etape etapeModel)
        {
            _etapeModel = etapeModel;

        }

        public string Id
        {
            get { return _etapeModel?.id; }
            set { _etapeModel.id = value; OnPropertyChanged(nameof(Id)); }
        }



        public string TypeEtape
        {
            get { return _etapeModel?.typeEtape; }
            set { _etapeModel.typeEtape = value; OnPropertyChanged(nameof(TypeEtape)); }
        }



        public DateTime DateHeureDepart
        {
            get { return _etapeModel.dateHeureDepart; }
            set { _etapeModel.dateHeureDepart = value; OnPropertyChanged(nameof(DateHeureDepart)); }
        }



        public DateTime DateHeureArrivee
        {
            get { return _etapeModel.dateHeureArrivee; }
            set { _etapeModel.dateHeureArrivee = value; OnPropertyChanged(nameof(DateHeureArrivee)); }
        }



        public string NumeroEtape
        {
            get { return _etapeModel?.numeroEtape; }
            set { _etapeModel.numeroEtape = value; OnPropertyChanged(nameof(NumeroEtape)); }
        }



        public string NatureEtape
        {
            get { return _etapeModel?.natureEtape; }
            set { _etapeModel.natureEtape = value; OnPropertyChanged(nameof(NatureEtape)); }
        }



        public int NbElement
        {
            get { return _etapeModel.nbElement; }
            set { _etapeModel.nbElement = value; OnPropertyChanged(nameof(NbElement)); }
        }



        public string StatutEtape
        {
            get { return _etapeModel?.statutEtape; }
            set { _etapeModel.statutEtape = value; OnPropertyChanged(nameof(StatutEtape)); }
        }



        public string Observation
        {
            get { return _etapeModel?.observation; }
            set { _etapeModel.observation = value; OnPropertyChanged(nameof(Observation)); }
        }



        public string JourCirculation
        {
            get { return _etapeModel?.jourCirculation; }
            set { _etapeModel.jourCirculation = value; OnPropertyChanged(nameof(JourCirculation)); }
        }



        public bool SupLogique
        {
            get { return _etapeModel.supLogique; }
            set { _etapeModel.supLogique = value; OnPropertyChanged(nameof(SupLogique)); }
        }



        public DateTime DateHeureModification
        {
            get { return _etapeModel.dateHeureModification; }
            set { _etapeModel.dateHeureModification = value; OnPropertyChanged(nameof(DateHeureModification)); }
        }
    }
}
