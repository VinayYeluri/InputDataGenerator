using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace SIEFSimulatorInputGenerator.Model
{
    public static class TreeViewSelectedItemChangedBehavior
    {
        public static readonly DependencyProperty CommandProperty =
          DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(TreeViewSelectedItemChangedBehavior), new PropertyMetadata(null, OnCommandChanged));

        public static void SetCommand(DependencyObject dp, ICommand value)
        {
            dp.SetValue(CommandProperty, value);
        }

        public static ICommand GetCommand(DependencyObject dp)
        {
            return (ICommand)dp.GetValue(CommandProperty);
        }

        private static void OnCommandChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            var treeView = dp as TreeView;
            if (treeView == null)
            {
                return;
            }

            treeView.SelectedItemChanged -= TreeView_SelectedItemChanged;
            if (e.NewValue != null)
            {
                treeView.SelectedItemChanged += TreeView_SelectedItemChanged;
            }
        }

        private static void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var treeView = sender as TreeView;
            if (treeView == null)
            {
                return;
            }

            var command = GetCommand(treeView);
            if (command != null && command.CanExecute(e.NewValue))
            {
                command.Execute(e.NewValue);
            }
        }
    }
}
