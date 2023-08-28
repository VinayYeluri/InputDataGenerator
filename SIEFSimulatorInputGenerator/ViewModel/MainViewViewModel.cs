using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Win32;
using Newtonsoft.Json;
using SIEFSimulatorInputGenerator.Model;
using SIEFSimulatorInputGenerator.UserControls;
using SIEFSimulatorInputGenerator.View;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class MainViewViewModel : ObservableObject
    {
        /// <summary>
        /// This command binded to the treeview selection changed
        /// </summary>
        public ICommand TreeViewSelectedItemChangedCommand { get; set; }

        /// <summary>
        /// This command binded to the Add Child Menu item
        /// </summary>
        public ICommand AddChildCommand { get; set; }

        /// <summary>
        /// This command binded to the Delete Child Menu item
        /// </summary>
        public ICommand DeleteChildCommand { get; set; }

        //These objects will store the values of the properties of selected node
        CourseUCViewModel coursesObject;
        SillonsUCViewModel sillonsObject;
        BranchesStifUCViewModel branchesStifObject;
        EtapesSupervisionUCViewModel etapesSupervisionObject;
        PointsHoraireUCViewModel pointsHoraireObject;
        PointsJalonnementUCViewModel pointsJalonnementObject;
        VoiesCirculationPrevuesUCViewModel voiesCirculationObject;

        RoulementUCViewModel RoulementObject;
        RoulementChildUCViewModel Roulement_ChildObject;
        CoursesUCViewModel CourseObject;
        ElementsUCViewModel ElementsObject;
        AffectationMaterielUCViewModel AffectationMaterielObject;
        RefblocMaterielUCViewModel RefblocMaterielObject;
        EtapeUCViewModel EtapeObject;
        JalonsEtapeUCViewModel JalonsEtapeObject;

        //These objects are used to present the content based on the selected node
        CourseUC CourseUcContent;
        SillonsUC SillonsUcContent;
        BranchesStifUC BrancheStifUcContent;
        EtapesSupervisionUC EtapesSupervisionUcContent;
        PointsJalonnementUC PointsJalonnementUcContent;
        PointsHoraireUC PointsHoraireUcContent;
        VoiesCirculationPrevuesUC VoieCirculationPrevueUcContent;
        EmptyUC EmptyUcContent = new EmptyUC();

        RoulementUC RoulementUcContent;
        RoulementChildUC Roulement_ChildUcContent;
        CoursesUC CoursesUcContent;
        ElementsUC ElementsUcContent;
        AffectationMaterielUC AffectationMaterielUcContent;
        RefblocMaterielUC RefblocMaterielUcContent;
        EtapeUC EtapeUcContent;
        JalonsEtapeUC JalonsEtapeUcContent;

        public MainViewViewModel()
        {
            var treeViewProvider = new TreeViewProvider();
            TreeNodesCollection = treeViewProvider._DirItems;
            generateCommand = new RelayCommand(GenerateMethod);
            cancelCommand = new RelayCommand(CancelMethod);
            TreeViewSelectedItemChangedCommand = new RelayCommand<object>(OnTreeViewSelectedItemChanged);
            AddChildCommand = new RelayCommand(AddChildMethod);
            DeleteChildCommand = new RelayCommand(DeleteChildMethod);
            validateCommand = new RelayCommand(ValidateMethod);
        }

        /// <summary>
        /// This property is binded to the Treeview ItemSource
        /// </summary>
        private ObservableCollection<TreeNodeItem> _treeNodesCollection;
        public ObservableCollection<TreeNodeItem> TreeNodesCollection
        {
            get => _treeNodesCollection;
            set
            { SetProperty(ref _treeNodesCollection, value); OnPropertyChanged(nameof(TreeNodesCollection)); }
        }

        /// <summary>
        /// This Property is binded to the Content of ContentControl for UserControl projection
        /// </summary>
        private UserControl ucContent;
        public UserControl UcContent
        {
            get => ucContent;
            set { SetProperty(ref ucContent, value); OnPropertyChanged(nameof(UcContent)); }
        }

        /// <summary>
        /// This Command is binded to Validate button
        /// </summary>
        private RelayCommand validateCommand;
        public RelayCommand ValidateCommand
        {
            get => validateCommand;
            private set => SetProperty(ref validateCommand, value);
        }

        /// <summary>
        /// This Command is binded to Generate button
        /// </summary>
        private RelayCommand generateCommand;
        public RelayCommand GenerateCommand
        {
            get => generateCommand;
            private set => SetProperty(ref generateCommand, value);
        }

        /// <summary>
        /// This Command is binded to Cancel button
        /// </summary>
        private RelayCommand cancelCommand;
        public RelayCommand CancelCommand
        {
            get => cancelCommand;
            private set => SetProperty(ref cancelCommand, value);
        }

        /// <summary>
        /// This method is used to project the usercontrol(with respective values) based on the selected item of the treeview
        /// </summary>
        /// <param name="selectedItem">Selected Item of Treeview</param>
        private void OnTreeViewSelectedItemChanged(object selectedItem)
        {
            var item = selectedItem as TreeNodeItem;
            if (LaunchUIViewModel._Select == "Courses")
            {
                if (item.Name == "Course")
                {
                    var courseitem = item.Values as Course;
                    coursesObject = new CourseUCViewModel(courseitem);
                    CourseUcContent = new CourseUC(coursesObject);
                    UcContent = CourseUcContent;
                }
                else if (item.Name == "Sillon")
                {
                    var sillonitem = item.Values as Sillon;
                    sillonsObject = new SillonsUCViewModel(sillonitem);
                    SillonsUcContent = new SillonsUC(sillonsObject);
                    UcContent = SillonsUcContent;
                }
                else if (item.Name == "BranchesStif")
                {
                    var branchesStifItem = item.Values as BranchesStif;
                    branchesStifObject = new BranchesStifUCViewModel(branchesStifItem);
                    BrancheStifUcContent = new BranchesStifUC(branchesStifObject);
                    UcContent = BrancheStifUcContent;
                }
                else if (item.Name == "EtapesSupervision")
                {
                    var etapesSupervisionItem = item.Values as EtapesSupervision;
                    etapesSupervisionObject = new EtapesSupervisionUCViewModel(etapesSupervisionItem);
                    EtapesSupervisionUcContent = new EtapesSupervisionUC(etapesSupervisionObject);
                    UcContent = EtapesSupervisionUcContent;
                }
                else if (item.Name == "PointsHoraire")
                {
                    var pointsHoraireItem = item.Values as PointsHoraire;
                    pointsHoraireObject = new PointsHoraireUCViewModel(pointsHoraireItem);
                    PointsHoraireUcContent = new PointsHoraireUC(pointsHoraireObject);
                    UcContent = PointsHoraireUcContent;
                }
                else if (item.Name == "PointsJalonnement")
                {
                    var JItem = item.Values as PointsJalonnement;
                    pointsJalonnementObject = new PointsJalonnementUCViewModel(JItem);
                    PointsJalonnementUcContent = new PointsJalonnementUC(pointsJalonnementObject);
                    UcContent = PointsJalonnementUcContent;
                }
                else if (item.Name == "VoieCirculationPrevue")
                {
                    var voieItem = item.Values as VoiesCirculationPrevue;
                    voiesCirculationObject = new VoiesCirculationPrevuesUCViewModel(voieItem);
                    VoieCirculationPrevueUcContent = new VoiesCirculationPrevuesUC(voiesCirculationObject);
                    UcContent = VoieCirculationPrevueUcContent;
                }
                else
                {
                    UcContent = EmptyUcContent;
                }
            }

            else if (LaunchUIViewModel._Select == "Roulement")
            {
                if (item.Name == "Roulement")
                {
                    var roulementItem = item.Values as Roulement;
                    RoulementObject = new RoulementUCViewModel(roulementItem);
                    RoulementUcContent = new RoulementUC(RoulementObject);
                    UcContent = RoulementUcContent;

                }
                else if (item.Name == "RoulementChild")
                {
                    var roulementChildItem = item.Values as Roulement_child;
                    Roulement_ChildObject = new RoulementChildUCViewModel(roulementChildItem);
                    Roulement_ChildUcContent = new RoulementChildUC(Roulement_ChildObject);
                    UcContent = Roulement_ChildUcContent;
                }
                else if (item.Name == "Course")
                {
                    var courseItems = item.Values as Courses;
                    CourseObject = new CoursesUCViewModel(courseItems);
                    CoursesUcContent = new CoursesUC(CourseObject);
                    UcContent = CoursesUcContent;
                }
                else if (item.Name == "Element")
                {
                    var elementItem = item.Values as Elements;
                    ElementsObject = new ElementsUCViewModel(elementItem);
                    ElementsUcContent = new ElementsUC(ElementsObject);
                    UcContent = ElementsUcContent;
                }
                else if (item.Name == "AffectationMateriel")
                {
                    var affectationItem = item.Values as AffectationMateriel;
                    AffectationMaterielObject = new AffectationMaterielUCViewModel(affectationItem);
                    AffectationMaterielUcContent = new AffectationMaterielUC(AffectationMaterielObject);
                    UcContent = AffectationMaterielUcContent;
                }
                else if (item.Name == "RefblocMateriel")
                {
                    var refblocItem = item.Values as RefblocMateriel;
                    RefblocMaterielObject = new RefblocMaterielUCViewModel(refblocItem);
                    RefblocMaterielUcContent = new RefblocMaterielUC(RefblocMaterielObject);
                    UcContent = RefblocMaterielUcContent;
                }
                else if (item.Name == "Etape")
                {
                    var etapeItem = item.Values as Etape;
                    EtapeObject = new EtapeUCViewModel(etapeItem);
                    EtapeUcContent = new EtapeUC(EtapeObject);
                    UcContent = EtapeUcContent;
                }
                else if (item.Name == "JalonsEtape")
                {
                    var jalonsEtapeItem = item.Values as JalonsEtapes;
                    JalonsEtapeObject = new JalonsEtapeUCViewModel(jalonsEtapeItem);
                    JalonsEtapeUcContent = new JalonsEtapeUC(JalonsEtapeObject);
                    UcContent = JalonsEtapeUcContent;
                }
                else
                {
                    var emptyUc = new EmptyUC();
                    UcContent = emptyUc;
                }
            }
        }

        //Working
        /// <summary>
        /// This method will add the child to the selected item
        /// </summary>
        private void AddChildMethod()
        {
            var rightClickedItem = MainView.RightClickedItem as TreeNodeItem;
            if (LaunchUIViewModel._Select == "Courses")
            {
                if (rightClickedItem.Name == "Courses")
                {
                    var CourseItem = new TreeNodeItem { Name = "Course", Values = new Course(), Index_I = CourseData.JsonCourseData.courses.Count() };
                    rightClickedItem.AddDirItem(CourseItem);
                    CourseItem.AddDirItem(new TreeNodeItem { Name = "Sillons", Index_I = CourseData.JsonCourseData.courses.Count() });
                    CourseItem.AddDirItem(new TreeNodeItem { Name = "BranchesStifs", Index_I = CourseData.JsonCourseData.courses.Count() });
                    CourseItem.AddDirItem(new TreeNodeItem { Name = "EtapesSupervisions", Index_I = CourseData.JsonCourseData.courses.Count() });
                    CourseItem.AddDirItem(new TreeNodeItem { Name = "PointsJalonnements", Index_I = CourseData.JsonCourseData.courses.Count() });
                    CourseData.JsonCourseData.courses.Add(CourseItem.Values as Course);
                }
                else if (rightClickedItem.Name == "Sillons")
                {
                    var SillonItem = new TreeNodeItem { Name = "Sillon", Values = new Sillon(), Index_I = rightClickedItem.Index_I, Index_J = CourseData.JsonCourseData.courses[rightClickedItem.Index_I].sillons.Count() };
                    CourseData.JsonCourseData.courses[rightClickedItem.Index_I].sillons.Add(SillonItem.Values as Sillon);
                    rightClickedItem.AddDirItem(SillonItem);
                }
                else if (rightClickedItem.Name == "EtapesSupervisions")
                {
                    var EtapeItem = new TreeNodeItem { Name = "EtapesSupervision", Values = new EtapesSupervision(), Index_I = rightClickedItem.Index_I, Index_J = CourseData.JsonCourseData.courses[rightClickedItem.Index_I].etapesSupervision.Count() };
                    CourseData.JsonCourseData.courses[rightClickedItem.Index_I].etapesSupervision.Add(EtapeItem.Values as EtapesSupervision);
                    rightClickedItem.AddDirItem(EtapeItem);
                }
                else if (rightClickedItem.Name == "BranchesStifs")
                {
                    var BranchesStifItem = new TreeNodeItem { Name = "BranchesStif", Values = new BranchesStif(), Index_I = rightClickedItem.Index_I, Index_J = CourseData.JsonCourseData.courses[rightClickedItem.Index_I].branchesStif.Count() };
                    CourseData.JsonCourseData.courses[rightClickedItem.Index_I].branchesStif.Add(BranchesStifItem.Values as BranchesStif);
                    rightClickedItem.AddDirItem(BranchesStifItem);
                }
                else if (rightClickedItem.Name == "PointsJalonnements")
                {
                    var PJItem = new TreeNodeItem { Name = "PointsJalonnement", Values = new PointsJalonnement(), Index_I = rightClickedItem.Index_I, Index_J = CourseData.JsonCourseData.courses[rightClickedItem.Index_I].pointsJalonnement.Count() };
                    PJItem.AddDirItem(new TreeNodeItem { Name = "PointsHoraires", Index_I = rightClickedItem.Index_I, Index_J = CourseData.JsonCourseData.courses[rightClickedItem.Index_I].pointsJalonnement.Count() });
                    PJItem.AddDirItem(new TreeNodeItem { Name = "VoieCirculationPrevues", Index_I = rightClickedItem.Index_I, Index_J = CourseData.JsonCourseData.courses[rightClickedItem.Index_I].pointsJalonnement.Count() });
                    CourseData.JsonCourseData.courses[rightClickedItem.Index_I].pointsJalonnement.Add(PJItem.Values as PointsJalonnement);
                    rightClickedItem.AddDirItem(PJItem);
                }
                else if (rightClickedItem.Name == "PointsHoraires")
                {
                    var PointHorairesItem = new TreeNodeItem { Name = "PointsHoraire", Values = new PointsHoraire(), Index_I = rightClickedItem.Index_I, Index_J = rightClickedItem.Index_J, Index_K = CourseData.JsonCourseData.courses[rightClickedItem.Index_I].pointsJalonnement[rightClickedItem.Index_J].pointsHoraire.Count() };
                    CourseData.JsonCourseData.courses[rightClickedItem.Index_I].pointsJalonnement[rightClickedItem.Index_J].pointsHoraire.Add(PointHorairesItem.Values as PointsHoraire);
                    rightClickedItem.AddDirItem(PointHorairesItem);
                }
                else if (rightClickedItem.Name == "VoieCirculationPrevues")
                {
                    var VoiesItem = new TreeNodeItem { Name = "VoieCirculationPrevue", Values = new VoiesCirculationPrevue(), Index_I = rightClickedItem.Index_I, Index_J = rightClickedItem.Index_J, Index_K = CourseData.JsonCourseData.courses[rightClickedItem.Index_I].pointsJalonnement[rightClickedItem.Index_J].voiesCirculationPrevues.Count() };
                    CourseData.JsonCourseData.courses[rightClickedItem.Index_I].pointsJalonnement[rightClickedItem.Index_J].voiesCirculationPrevues.Add(VoiesItem.Values as VoiesCirculationPrevue);
                    rightClickedItem.AddDirItem(VoiesItem);
                }
                else
                {
                    MessageBox.Show("You cannot add child to this node", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            else if (LaunchUIViewModel._Select == "Roulement")
            {
                if (rightClickedItem.Name == "Roulements")
                {
                    var RoulementsItem = new TreeNodeItem { Name = "Roulement", Values = new Roulement(), Index_I = CourseData.JsonRoulementData.roulement.Count() };
                    rightClickedItem.AddDirItem(RoulementsItem);
                    RoulementsItem.AddDirItem(new TreeNodeItem { Name = "RoulementChild", Values = new Roulement_child(), Index_I = CourseData.JsonRoulementData.roulement.Count() });
                    RoulementsItem.AddDirItem(new TreeNodeItem { Name = "Courses", Index_I = CourseData.JsonRoulementData.roulement.Count() });
                    RoulementsItem.AddDirItem(new TreeNodeItem { Name = "Elements", Index_I = CourseData.JsonRoulementData.roulement.Count() });
                    CourseData.JsonRoulementData.roulement.Add(RoulementsItem.Values as Roulement);
                }
                else if (rightClickedItem.Name == "Courses")
                {
                    var CoursesItem = new TreeNodeItem { Name = "Course", Values = new Courses(), Index_I = rightClickedItem.Index_I, Index_J = CourseData.JsonRoulementData.roulement[rightClickedItem.Index_I].courses.Count() };
                    rightClickedItem.AddDirItem(CoursesItem);
                    CourseData.JsonRoulementData.roulement[rightClickedItem.Index_I].courses.Add(CoursesItem.Values as Courses);
                }
                else if (rightClickedItem.Name == "Elements")
                {
                    var ElementsItem = new TreeNodeItem { Name = "Element", Values = new Elements(), Index_I = rightClickedItem.Index_I, Index_J = CourseData.JsonRoulementData.roulement[rightClickedItem.Index_I].elements.Count() };
                    rightClickedItem.AddDirItem(ElementsItem);
                    var AffectationsItem = new TreeNodeItem { Name = "AffectationMateriel", Values = new AffectationMateriel(), Index_I = rightClickedItem.Index_I, Index_J = CourseData.JsonRoulementData.roulement[rightClickedItem.Index_I].elements.Count() };
                    ElementsItem.AddDirItem(AffectationsItem); AffectationsItem.AddDirItem(new TreeNodeItem { Name = "RefblocMateriel", Values = new AffectationMateriel(), Index_I = rightClickedItem.Index_I, Index_J = CourseData.JsonRoulementData.roulement[rightClickedItem.Index_I].elements.Count() });
                    var EtapesItem = new TreeNodeItem { Name = "Etape", Values = new Etape(), Index_I = rightClickedItem.Index_I, Index_J = CourseData.JsonRoulementData.roulement[rightClickedItem.Index_I].elements.Count() };
                    ElementsItem.AddDirItem(EtapesItem);
                    EtapesItem.AddDirItem(new TreeNodeItem { Name = "JalonsEtapes", Index_I = rightClickedItem.Index_I, Index_J = rightClickedItem.Index_J, Index_K = CourseData.JsonRoulementData.roulement[rightClickedItem.Index_I].elements.Count() });
                    CourseData.JsonRoulementData.roulement[rightClickedItem.Index_I].elements.Add(ElementsItem.Values as Elements);
                }
                else if (rightClickedItem.Name == "JalonsEtapes")
                {
                    var JalonsEtapesItems = new TreeNodeItem { Name = "JalonsEtape", Values = new JalonsEtapes(), Index_I = rightClickedItem.Index_I, Index_J = rightClickedItem.Index_J, Index_K = CourseData.JsonRoulementData.roulement[rightClickedItem.Index_I].elements[rightClickedItem.Index_J].etape.jalonsEtape.Count() };
                    rightClickedItem.AddDirItem(JalonsEtapesItems);
                    CourseData.JsonRoulementData.roulement[rightClickedItem.Index_I].elements[rightClickedItem.Index_J].etape.jalonsEtape.Add(JalonsEtapesItems.Values as JalonsEtapes);
                }
                else
                {
                    MessageBox.Show("You cannot add child to this node", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        /// <summary>
        /// This list is used to stop the delete method when there are no children of the items in this list
        /// </summary>
        private List<string> CheckList = new List<string> {"Courses", "Sillons", "BranchesStifs", "EtapesSupervisions",
            "PointsJalonnements","PointsHoraires", "VoieCirculationPrevues"};

        private List<string> ObjectNodes = new List<string> { "RoulementChild", "AffectationMateriel", "RefblocMateriel", "Etape" };

        private List<string> ListNodes = new List<string> { "Roulements", "Courses", "Elements", "JalonsEtapes" };

        /// <summary>
        /// This method will delete the child from the Items
        /// </summary>
        private void DeleteChildMethod()
        {
            var _rightClickedItem = MainView.RightClickedItem as TreeNodeItem;
            var parentItem = _rightClickedItem.Parent as TreeNodeItem;
            RemoveItemFromData(_rightClickedItem);
            if (LaunchUIViewModel._Select == "Courses")
            {
                if (parentItem != null || _rightClickedItem.Name == "Courses")
                {
                    if (_rightClickedItem.Items.Count > 0 && _rightClickedItem.Name != "Course" && _rightClickedItem.Name != "PointsJalonnement")
                    {
                        var count = _rightClickedItem.Items.Count;
                        while (count > 0)
                        {
                            var childItem = _rightClickedItem.Items[0] as TreeNodeItem;
                            if (childItem != null)
                            {
                                _rightClickedItem.Items.Remove(childItem);
                            }
                            count = count - 1;
                        }
                    }
                    else if (CheckList.Contains(_rightClickedItem.Name))
                    {
                        MessageBox.Show("The selected item is empty(doesn't have children to delete).");
                    }
                    else
                    {
                        parentItem.RemoveDirItem(_rightClickedItem);
                    }
                }
            }

            else if (LaunchUIViewModel._Select == "Roulement")
            {
                if (!ObjectNodes.Contains(_rightClickedItem.Name))
                {
                    if (parentItem != null || _rightClickedItem.Name == "Roulements")
                    {
                        if (_rightClickedItem.Items.Count > 0 && _rightClickedItem.Name != "Element" && _rightClickedItem.Name != "Roulement")
                        {
                            var count = _rightClickedItem.Items.Count;
                            while (count > 0)
                            {
                                var childItem = _rightClickedItem.Items[0] as TreeNodeItem;
                                if (childItem != null)
                                {
                                    _rightClickedItem.Items.Remove(childItem);
                                }
                                count = count - 1;
                            }
                        }
                        else if (ListNodes.Contains(_rightClickedItem.Name))
                        {
                            MessageBox.Show("The selected item is empty, doesn't have any children to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            parentItem.RemoveDirItem(_rightClickedItem);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You cannot delete this child", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// This method will delete the selected item from the Deserialized oject(JsonCourseData)
        /// </summary>
        private void RemoveItemFromData(TreeNodeItem _rightClickedItem)
        {
            if (_rightClickedItem != null && LaunchUIViewModel._Select == "Courses")
            {
                if (_rightClickedItem.Name == "Courses")
                {
                    CourseData.JsonCourseData.courses.Clear();
                }
                else if (_rightClickedItem.Name == "Course")
                {
                    //CourseData.JsonCourseData.courses.RemoveAt(_rightClickedItem.Index_I);
                    CourseData.JsonCourseData.courses[_rightClickedItem.Index_I] = null;
                }
                else if (_rightClickedItem.Name == "Sillons")
                {
                    CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].sillons.Clear();
                }
                else if (_rightClickedItem.Name == "Sillon")
                {
                    //CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].sillons.RemoveAt(_rightClickedItem.Index_J);
                    CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].sillons[_rightClickedItem.Index_J] = null;
                }
                else if (_rightClickedItem.Name == "BranchesStifs")
                {
                    CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].branchesStif.Clear();
                }
                else if (_rightClickedItem.Name == "BranchesStif")
                {
                    //CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].branchesStif.RemoveAt(_rightClickedItem.Index_J);
                    CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].branchesStif[_rightClickedItem.Index_J] = null;
                }
                else if (_rightClickedItem.Name == "EtapesSupervisions")
                {
                    CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].etapesSupervision.Clear();
                }
                else if (_rightClickedItem.Name == "EtapesSupervision")
                {
                    //CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].etapesSupervision.RemoveAt(_rightClickedItem.Index_J);
                    CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].etapesSupervision[_rightClickedItem.Index_J] = null;
                }
                else if (_rightClickedItem.Name == "PointsJalonnements")
                {
                    CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].pointsJalonnement.Clear();
                }
                else if (_rightClickedItem.Name == "PointsJalonnement")
                {
                    //CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].pointsJalonnement.RemoveAt(_rightClickedItem.Index_J); 
                    CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].pointsJalonnement[_rightClickedItem.Index_J] = null;  //Something is working
                }
                else if (_rightClickedItem.Name == "PointsHoraires")
                {
                    CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].pointsJalonnement[_rightClickedItem.Index_J].pointsHoraire.Clear();
                }
                else if (_rightClickedItem.Name == "PointsHoraire")
                {
                    //CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].pointsJalonnement[_rightClickedItem.Index_J].pointsHoraire.RemoveAt(_rightClickedItem.Index_K);
                    CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].pointsJalonnement[_rightClickedItem.Index_J].pointsHoraire[_rightClickedItem.Index_K] = null;
                }
                else if (_rightClickedItem.Name == "VoieCirculationPrevues")
                {
                    CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].pointsJalonnement[_rightClickedItem.Index_J].voiesCirculationPrevues.Clear();
                }
                else if (_rightClickedItem.Name == "VoieCirculationPrevue")
                {
                    //CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].pointsJalonnement[_rightClickedItem.Index_J].voiesCirculationPrevues.RemoveAt(_rightClickedItem.Index_K);
                    CourseData.JsonCourseData.courses[_rightClickedItem.Index_I].pointsJalonnement[_rightClickedItem.Index_J].voiesCirculationPrevues[_rightClickedItem.Index_K] = null;
                }
            }

            else if (_rightClickedItem != null && LaunchUIViewModel._Select == "Roulement")
            {
                if (_rightClickedItem.Name == "Roulements")
                {
                    CourseData.JsonRoulementData.roulement.Clear();
                }
                else if (_rightClickedItem.Name == "Roulement")
                {
                    //CourseData.JsonRoulementData.roulement.RemoveAt(_rightClickedItem.Index_I);
                    CourseData.JsonRoulementData.roulement[_rightClickedItem.Index_I] = null;
                }
                else if (_rightClickedItem.Name == "Courses")
                {
                    CourseData.JsonRoulementData.roulement[_rightClickedItem.Index_I].courses.Clear();
                }
                else if (_rightClickedItem.Name == "Course")
                {
                    //CourseData.JsonRoulementData.roulement[_rightClickedItem.Index_I].courses.RemoveAt(_rightClickedItem.Index_J);
                    CourseData.JsonRoulementData.roulement[_rightClickedItem.Index_I].courses[_rightClickedItem.Index_J] = null;
                }
                else if (_rightClickedItem.Name == "Elements")
                {
                    CourseData.JsonRoulementData.roulement[_rightClickedItem.Index_I].elements.Clear();
                }
                else if (_rightClickedItem.Name == "Element")
                {
                    //CourseData.JsonRoulementData.roulement[_rightClickedItem.Index_I].elements.RemoveAt(_rightClickedItem.Index_J);
                    CourseData.JsonRoulementData.roulement[_rightClickedItem.Index_I].elements[_rightClickedItem.Index_J] = null;
                }
                else if (_rightClickedItem.Name == "JalonsEtapes")
                {
                    CourseData.JsonRoulementData.roulement[_rightClickedItem.Index_I].elements[_rightClickedItem.Index_J].etape.jalonsEtape.Clear();
                }
                else if (_rightClickedItem.Name == "JalonsEtape")
                {
                    //CourseData.JsonRoulementData.roulement[_rightClickedItem.Index_I].elements[_rightClickedItem.Index_J].etape.jalonsEtape.RemoveAt(_rightClickedItem.Index_K);
                    CourseData.JsonRoulementData.roulement[_rightClickedItem.Index_I].elements[_rightClickedItem.Index_J].etape.jalonsEtape[_rightClickedItem.Index_K] = null;
                }
            }
        }

        /// <summary>
        /// This method will traverse the textboxes of the selected usercontrol for validation
        /// </summary>
        /// <typeparam name="T">TextBox</typeparam>
        /// <param name="parent">UserControl</param>
        /// <returns>returns the list of Textboxes of the selected usercontrol</returns>
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                {
                    yield return (T)child;
                }
                foreach (T descendant in FindVisualChildren<T>(child))
                {
                    yield return descendant;
                }
            }
        }

        /// <summary>
        /// This method will check that the selected usercontrol have null values or not
        /// </summary>
        private void ValidateMethod()
        {
            foreach (TextBox textBox in FindVisualChildren<TextBox>(UcContent))
            {
                textBox.ToolTip = null;
                if (textBox.Text == "")
                {
                    textBox.BorderBrush = Brushes.Red;
                    textBox.ToolTip = "Please enter the value";
                }
                else
                {
                    textBox.BorderBrush = Brushes.LightSlateGray;
                }
            }
        }

        //It's working
        private void FilterMethod()
        {
            if (LaunchUIViewModel._Select == "Courses")
            {
                for (int i = 0; i < CourseData.JsonCourseData.courses.Count(); i++)
                {
                    if (CourseData.JsonCourseData.courses[i] == null)
                    {
                        CourseData.JsonCourseData.courses.RemoveAt(i);
                    }

                    for (int j = 0; j < CourseData.JsonCourseData.courses[i].sillons.Count(); j++)
                    {
                        if (CourseData.JsonCourseData.courses[i].sillons[j] == null)
                        {
                            CourseData.JsonCourseData.courses[i].sillons.RemoveAt(j);
                        }
                    }

                    for (int j = 0; j < CourseData.JsonCourseData.courses[i].branchesStif.Count(); j++)
                    {
                        if (CourseData.JsonCourseData.courses[i].branchesStif[j] == null)
                        {
                            CourseData.JsonCourseData.courses[i].branchesStif.RemoveAt(j);
                        }
                    }

                    for (int j = 0; j < CourseData.JsonCourseData.courses[i].etapesSupervision.Count(); j++)
                    {
                        if (CourseData.JsonCourseData.courses[i].etapesSupervision[j] == null)
                        {
                            CourseData.JsonCourseData.courses[i].etapesSupervision.RemoveAt(j);
                        }
                    }

                    for (int j = 0; j < CourseData.JsonCourseData.courses[i].pointsJalonnement.Count(); j++)
                    {
                        if (CourseData.JsonCourseData.courses[i].pointsJalonnement[j] == null)
                        {
                            CourseData.JsonCourseData.courses[i].pointsJalonnement.RemoveAt(j);
                        }

                        for (int k = 0; k < CourseData.JsonCourseData.courses[i].pointsJalonnement[j].pointsHoraire.Count(); k++)
                        {
                            if (CourseData.JsonCourseData.courses[i].pointsJalonnement[j].pointsHoraire[k] == null)
                            {
                                CourseData.JsonCourseData.courses[i].pointsJalonnement[j].pointsHoraire.RemoveAt(k);
                            }
                        }

                        for (int k = 0; k < CourseData.JsonCourseData.courses[i].pointsJalonnement[j].voiesCirculationPrevues.Count(); k++)
                        {
                            if (CourseData.JsonCourseData.courses[i].pointsJalonnement[j].voiesCirculationPrevues[k] == null)
                            {
                                CourseData.JsonCourseData.courses[i].pointsJalonnement[j].voiesCirculationPrevues.RemoveAt(k);
                            }
                        }
                    }
                }
            }

            else if (LaunchUIViewModel._Select == "Roulement")
            {
                for (int i = 0; i < CourseData.JsonRoulementData.roulement.Count(); i++)
                {
                    if (CourseData.JsonRoulementData.roulement[i] == null)
                    {
                        CourseData.JsonRoulementData.roulement.RemoveAt(i);
                    }

                    for (int j = 0; j < CourseData.JsonRoulementData.roulement[i].courses.Count(); j++)
                    {
                        if (CourseData.JsonRoulementData.roulement[i].courses[j] == null)
                        {
                            CourseData.JsonRoulementData.roulement[i].courses.RemoveAt(j);
                        }
                    }

                    for (int j = 0; j < CourseData.JsonRoulementData.roulement[i].elements.Count(); j++)
                    {
                        if (CourseData.JsonRoulementData.roulement[i].elements[j] == null)
                        {
                            CourseData.JsonRoulementData.roulement[i].elements.RemoveAt(j);
                        }

                        for (int k = 0; k < CourseData.JsonRoulementData.roulement[i].elements[j].etape.jalonsEtape.Count(); k++)
                        {
                            if (CourseData.JsonRoulementData.roulement[i].elements[j].etape.jalonsEtape[k] == null)
                            {
                                CourseData.JsonRoulementData.roulement[i].elements[j].etape.jalonsEtape.RemoveAt(k);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method will open the save dialog box and save the data as json file
        /// </summary>
        private void GenerateMethod()
        {
            FilterMethod();
            if (LaunchUIViewModel._Select == "Courses")
            {

                var obj = CourseData.JsonCourseData;
                var updatedJsonString = JsonConvert.SerializeObject(obj, Formatting.Indented);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.RestoreDirectory = true;
                sfd.FileName = "*.json";
                sfd.DefaultExt = "json";
                sfd.Filter = "JSON Files|*.json;";
                if (sfd.ShowDialog() == true)
                {
                    Stream filestream = sfd.OpenFile();
                    StreamWriter sw = new StreamWriter(filestream);
                    sw.Write(updatedJsonString);
                    sw.Close();
                    filestream.Close();
                }
            }

            else if (LaunchUIViewModel._Select == "Roulement")
            {

                var obj = CourseData.JsonRoulementData;
                var updatedJsonString = JsonConvert.SerializeObject(obj, Formatting.Indented);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.RestoreDirectory = true;
                sfd.FileName = "*.json";
                sfd.DefaultExt = "json";
                sfd.Filter = "JSON Files|*.json;";
                if (sfd.ShowDialog() == true)
                {
                    Stream filestream = sfd.OpenFile();
                    StreamWriter sw = new StreamWriter(filestream);
                    sw.Write(updatedJsonString);
                    sw.Close();
                    filestream.Close();
                }
            }
        }

        /// <summary>
        /// This method will close the application with the warning message
        /// </summary>
        private void CancelMethod()
        {
            if (MessageBox.Show("Want to close this application?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
                // Close the Application  
            }
            else
            {
                // Do not close the Application  
            }
        }
    }
}
