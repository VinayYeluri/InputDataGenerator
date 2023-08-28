using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.Model
{
    public class TreeViewProvider : ObservableObject
    {
        private readonly TreeNodeItem _rootDirectoryItem;
        public TreeViewProvider()
        {
            if (LaunchUIViewModel._Select == "Courses")
            {
                _rootDirectoryItem = new TreeNodeItem { Name = "X" };
                try
                {
                    if (Path.GetFileName(LaunchUIViewModel._Path) != null)
                    {
                        var CoursesList = new TreeNodeItem { Name = "Courses" };
                        for (int i = 0; i < CourseData.JsonCourseData.courses.Count(); i++)
                        {
                            var CourseItems = new TreeNodeItem { Name = "Course", Values = CourseData.JsonCourseData.courses[i], Index_I = i };
                            CoursesList.AddDirItem(CourseItems);

                            var SillonsList = new TreeNodeItem { Name = "Sillons", Index_I = i };
                            CourseItems.AddDirItem(SillonsList);

                            var BranchesStifList = new TreeNodeItem { Name = "BranchesStifs", Index_I = i };
                            CourseItems.AddDirItem(BranchesStifList);

                            var EtapesSupervisionList = new TreeNodeItem { Name = "EtapesSupervisions", Index_I = i };
                            CourseItems.AddDirItem(EtapesSupervisionList);

                            var PointsJalonnementList = new TreeNodeItem { Name = "PointsJalonnements", Index_I = i };
                            CourseItems.AddDirItem(PointsJalonnementList);

                            for (int j = 0; j < CourseData.JsonCourseData.courses[i].sillons.Count(); j++)
                            {
                                var SillonsItems = new TreeNodeItem { Name = "Sillon", Values = CourseData.JsonCourseData.courses[i].sillons[j], Index_I = i, Index_J = j };
                                SillonsList.AddDirItem(SillonsItems);
                            }

                            for (int j = 0; j < CourseData.JsonCourseData.courses[i].branchesStif.Count(); j++)
                            {
                                var BranchesStifItems = new TreeNodeItem { Name = "BranchesStif", Values = CourseData.JsonCourseData.courses[i].branchesStif[j], Index_I = i, Index_J = j };
                                BranchesStifList.AddDirItem(BranchesStifItems);
                            }

                            for (int j = 0; j < CourseData.JsonCourseData.courses[i].etapesSupervision.Count(); j++)
                            {
                                var EtapesSuperVisionItems = new TreeNodeItem { Name = "EtapesSupervision", Values = CourseData.JsonCourseData.courses[i].etapesSupervision[j], Index_I = i, Index_J = j };
                                EtapesSupervisionList.AddDirItem(EtapesSuperVisionItems);
                            }

                            for (int j = 0; j < CourseData.JsonCourseData.courses[i].pointsJalonnement.Count(); j++)
                            {
                                var PointsJalonnementItems = new TreeNodeItem { Name = "PointsJalonnement", Values = CourseData.JsonCourseData.courses[i].pointsJalonnement[j], Index_I = i, Index_J = j };
                                PointsJalonnementList.AddDirItem(PointsJalonnementItems);

                                var PointsHoraireList = new TreeNodeItem { Name = "PointsHoraires", Index_I = i, Index_J = j };
                                PointsJalonnementItems.AddDirItem(PointsHoraireList);

                                var VoieCirculationPrevueList = new TreeNodeItem { Name = "VoieCirculationPrevues", Index_I = i, Index_J = j };
                                PointsJalonnementItems.AddDirItem(VoieCirculationPrevueList);

                                for (int k = 0; k < CourseData.JsonCourseData.courses[i].pointsJalonnement[j].pointsHoraire.Count(); k++)
                                {
                                    var PointsHoraireItems = new TreeNodeItem { Name = "PointsHoraire", Values = CourseData.JsonCourseData.courses[i].pointsJalonnement[j].pointsHoraire[k], Index_I = i, Index_J = j, Index_K = k };
                                    PointsHoraireList.AddDirItem(PointsHoraireItems);
                                }

                                for (int k = 0; k < CourseData.JsonCourseData.courses[i].pointsJalonnement[j].voiesCirculationPrevues.Count(); k++)
                                {
                                    var VoieCirculationPrevueItems = new TreeNodeItem { Name = "VoieCirculationPrevue", Values = CourseData.JsonCourseData.courses[i].pointsJalonnement[j].voiesCirculationPrevues[k], Index_I = i, Index_J = j, Index_K = k };
                                    VoieCirculationPrevueList.AddDirItem(VoieCirculationPrevueItems);
                                }
                            }
                        }

                        var childList1 = new ObservableCollection<TreeNodeItem>
                     {
                        CoursesList
                     };

                        _rootDirectoryItem.Items = childList1;
                    }

                    else if (Path.GetFileName(LaunchUIViewModel._Path) == null)
                    {
                        var newCoursesList = new TreeNodeItem { Name = "Courses" };

                        var childList2 = new ObservableCollection<TreeNodeItem>
                    {
                        newCoursesList
                    };

                        _rootDirectoryItem.Items = childList2;
                    }
                }
                catch
                {

                }
            }

            else if (LaunchUIViewModel._Select == "Roulement")
            {
                _rootDirectoryItem = new TreeNodeItem { Name = "X" };

                try
                {
                    if (Path.GetFileName(LaunchUIViewModel._Path) != null)
                    {

                        var RoulementsList = new TreeNodeItem { Name = "Roulements" };

                        for (int i = 0; i < CourseData.JsonRoulementData.roulement.Count(); i++)
                        {
                            var RoulementItems = new TreeNodeItem { Name = "Roulement", Values = CourseData.JsonRoulementData.roulement[i], Index_I = i };

                            RoulementsList.AddDirItem(RoulementItems);

                            var RoulementChildItems = new TreeNodeItem { Name = "RoulementChild", Values = CourseData.JsonRoulementData.roulement[i].roulement, Index_I = i };

                            RoulementItems.AddDirItem(RoulementChildItems);

                            var CoursesList = new TreeNodeItem { Name = "Courses", Index_I = i };

                            RoulementItems.AddDirItem(CoursesList);

                            var ElementsList = new TreeNodeItem { Name = "Elements", Index_I = i };

                            RoulementItems.AddDirItem(ElementsList);


                            for (int j = 0; j < CourseData.JsonRoulementData.roulement[i].courses.Count(); j++)
                            {
                                var CourseItems = new TreeNodeItem { Name = "Course", Values = CourseData.JsonRoulementData.roulement[i].courses[j], Index_I = i, Index_J = j };

                                CoursesList.AddDirItem(CourseItems);
                            };


                            for (int j = 0; j < CourseData.JsonRoulementData.roulement[i].elements.Count(); j++)
                            {
                                var ElementItems = new TreeNodeItem { Name = "Element", Values = CourseData.JsonRoulementData.roulement[i].elements[j], Index_I = i, Index_J = j };

                                ElementsList.AddDirItem(ElementItems);

                                var AffectionItems = new TreeNodeItem { Name = "AffectationMateriel", Values = CourseData.JsonRoulementData.roulement[i].elements[j].affectationMateriel, Index_I = i, Index_J = j };

                                ElementItems.AddDirItem(AffectionItems);

                                var RefblocItems = new TreeNodeItem { Name = "RefblocMateriel", Values = CourseData.JsonRoulementData.roulement[i].elements[j].affectationMateriel.refblocMateriel, Index_I = i, Index_J = j };

                                AffectionItems.AddDirItem(RefblocItems);

                                var EtapeItems = new TreeNodeItem { Name = "Etape", Values = CourseData.JsonRoulementData.roulement[i].elements[j].etape, Index_I = i, Index_J = j };

                                ElementItems.AddDirItem(EtapeItems);

                                var JalonsEtapeslist = new TreeNodeItem { Name = "JalonsEtapes", Index_I = i, Index_J = j };

                                EtapeItems.AddDirItem(JalonsEtapeslist);

                                for (int k = 0; k < CourseData.JsonRoulementData.roulement[i].elements[j].etape.jalonsEtape.Count(); k++)
                                {
                                    var JalonsEtapeItems = new TreeNodeItem { Name = "JalonsEtape", Values = CourseData.JsonRoulementData.roulement[i].elements[j].etape.jalonsEtape[k], Index_I = i, Index_J = j, Index_K = k };

                                    JalonsEtapeslist.AddDirItem(JalonsEtapeItems);
                                }
                            }
                        }

                        var TreeList = new ObservableCollection<TreeNodeItem> { RoulementsList };

                        _rootDirectoryItem.Items = TreeList;
                    }

                    else if (Path.GetFileName(LaunchUIViewModel._Path) == null)
                    {
                        var EmptyRoulementsList = new TreeNodeItem { Name = "Roulements" };

                        var EmptyTreeList = new ObservableCollection<TreeNodeItem> { EmptyRoulementsList };

                        _rootDirectoryItem.Items = EmptyTreeList;
                    }
                }
                catch
                {

                }
            }
        }
        public ObservableCollection<TreeNodeItem> _DirItems => _rootDirectoryItem.Traverse(_rootDirectoryItem);
    }
}
