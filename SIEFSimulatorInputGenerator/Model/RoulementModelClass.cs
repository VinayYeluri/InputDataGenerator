using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.Model
{
    public class RoulementRoot
    {
        public List<Roulement> roulement { get; set; } = new List<Roulement>();
    }
    public class RefblocMateriel
    {
        public string cleMaterielPhysique { get; set; }
        public string identifiantEVN { get; set; }
        public string numeroInterneEF { get; set; }

    }
    public class AffectationMateriel
    {
        public string id { get; set; }
        public string natureAffectation { get; set; }
        public bool supLogique { get; set; }
        public DateTime dateHeureModification { get; set; }
        public RefblocMateriel refblocMateriel { get; set; } = new RefblocMateriel();
    }
    public class JalonsEtapes
    {
        public int rang { get; set; }
        public string jalon { get; set; }
        public string typeJalon { get; set; }
    }
    public class Etape
    {
        public string id { get; set; }
        public string typeEtape { get; set; }
        public DateTime dateHeureDepart { get; set; }
        public DateTime dateHeureArrivee { get; set; }
        public List<JalonsEtapes> jalonsEtape { get; set; } = new List<JalonsEtapes>();
        public string numeroEtape { get; set; }
        public string natureEtape { get; set; }
        public int nbElement { get; set; }
        public string statutEtape { get; set; }
        public string observation { get; set; }
        public string jourCirculation { get; set; }
        public bool supLogique { get; set; }
        public DateTime dateHeureModification { get; set; }


    }
    public class Elements
    {
        public string id { get; set; }
        public string idProprietaire { get; set; }
        public int rang { get; set; }
        public int orientation { get; set; }
        public int nature { get; set; }
        public bool supLogique { get; set; }
        public string numeroCommercial { get; set; }
        public string idCourse { get; set; }
        public DateTime dateHeureModification { get; set; }
        public AffectationMateriel affectationMateriel { get; set; } = new AffectationMateriel();
        public Etape etape { get; set; } = new Etape();

    }
    public class Courses
    {
        public string idCourse { get; set; }
    }
    public class Roulement_child
    {
        public string id { get; set; }
        public string source { get; set; }
        public string codeEntiteOffre { get; set; }
        public string dateDebutValidite { get; set; }
        public string dateFinValidite { get; set; }
        public string numeroRoulement { get; set; }

    }

    public class Roulement
    {
        public string id { get; set; }
        public string jourRoulement { get; set; }
        public string numLigneRoulement { get; set; }
        public int stade { get; set; }
        public int phase { get; set; }
        public string source { get; set; }
        public DateTime dateHeureModification { get; set; }
        public Roulement_child roulement { get; set; } = new Roulement_child();
        public List<Courses> courses { get; set; } = new List<Courses>();
        public List<Elements> elements { get; set; } = new List<Elements>();
    }
}
