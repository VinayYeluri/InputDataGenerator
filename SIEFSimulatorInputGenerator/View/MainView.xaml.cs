using SIEFSimulatorInputGenerator.Model;
using SIEFSimulatorInputGenerator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SIEFSimulatorInputGenerator.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        MainViewViewModel mainViewModel;
        public MainView()
        {
            InitializeComponent();
            mainViewModel = new MainViewViewModel();
            this.DataContext = mainViewModel;
        }

        public static object RightClickedItem;
        private void TreeView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);
            if (treeViewItem != null)
            {
                var TrItem = treeViewItem as TreeViewItem;
                RightClickedItem = TrItem.Header as TreeNodeItem;
            }
        }
        private TreeViewItem VisualUpwardSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
            {
                source = VisualTreeHelper.GetParent(source);
            }
            return source as TreeViewItem;
        }
    }
}
