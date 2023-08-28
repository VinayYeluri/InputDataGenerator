using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.Model
{
    public class BranchesStif
    {
        public string code { get; set; }
        public string sens { get; set; }
        public string type { get; set; }
    }

    public class Course
    {
        public string idCourse { get; set; }
        public string refCourse { get; set; }
        public string type { get; set; }
        public string statutCourse { get; set; }
        public string dateCourse { get; set; }
        public string mode { get; set; }
        public string codeMission { get; set; }
        public string typeDeCourse { get; set; }
        public string uoTransporteur { get; set; }
        public DateTime utcDateMajCourse { get; set; }
        public string typeReference { get; set; }
        public string source { get; set; }
        public string technicalId { get; set; }
        public string ecartJMoins1a17h { get; set; }
        public DateTime destinationUtcHoraire { get; set; }
        public DateTime origineUtcHoraire { get; set; }
        public string destinationJalon { get; set; }
        public string origineJalon { get; set; }
        public string nomCourse { get; set; }
        public string compositionCourtLong { get; set; }
        public List<Sillon> sillons { get; set; } = new List<Sillon>();
        public List<BranchesStif> branchesStif { get; set; } = new List<BranchesStif>();
        public List<EtapesSupervision> etapesSupervision { get; set; } = new List<EtapesSupervision>();
        public List<PointsJalonnement> pointsJalonnement { get; set; } = new List<PointsJalonnement>();
    }

    public class EtapesSupervision
    {
        public string jalonDebut { get; set; }
        public string jalonFin { get; set; }
        public string tct { get; set; }
        public string uoSuperviseur { get; set; }
    }

    public class PointsHoraire
    {
        public string typeHoraire { get; set; }
        public DateTime horairePrevu { get; set; }
        public string numeroMarche { get; set; }
    }

    public class PointsJalonnement
    {
        public string @ref { get; set; }
        public string refCourse { get; set; }
        public int rang { get; set; }
        public bool estSupprimee { get; set; }
        public string refZoneEmbarquement { get; set; }
        public string clcclc { get; set; }
        public List<PointsHoraire> pointsHoraire { get; set; } = new List<PointsHoraire>();
        public List<VoiesCirculationPrevue> voiesCirculationPrevues { get; set; } = new List<VoiesCirculationPrevue>();
    }

    public class Root
    {
        public List<Course> courses { get; set; } = new List<Course>();
    }

    public class Sillon
    {
        public string idSillon { get; set; }
        public string refSillon { get; set; }
        public string numeroMarche { get; set; }
    }

    public class VoiesCirculationPrevue
    {
        public string voieSortie { get; set; }
        public string voieVia { get; set; }
    }
}
