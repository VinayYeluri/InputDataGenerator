using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.Model
{
    public class TreeNodeItem : ObservableObject
    {
        public string Name { get; set; }
        public int Index_I { get; set; }
        public int Index_J { get; set; }
        public int Index_K { get; set; }
        public object Values { get; set; }
        public TreeNodeItem Parent { get; set; }
        public TreeNodeItem()
        {
            _items = new ObservableCollection<TreeNodeItem>();
        }

        private ObservableCollection<TreeNodeItem> _items;
        public ObservableCollection<TreeNodeItem> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged(nameof(Items)); }
        }

        public ObservableCollection<TreeNodeItem> Traverse(TreeNodeItem it)
        {
            var items = new ObservableCollection<TreeNodeItem>();
            foreach (var itm in it.Items)
            {
                Traverse(itm);
                items.Add(itm);
            }
            return items;
        }

        /// <summary>
        /// This Method adds treeNodeItem to Items Collection
        /// </summary>
        /// <param name="treeNodeItem"></param>
        public void AddDirItem(TreeNodeItem treeNodeItem)
        {
            treeNodeItem.Parent = this;
            Items.Add(treeNodeItem);
        }

        /// <summary>
        /// This Method removes treeNodeItem from Items Collection
        /// </summary>
        /// <param name="treeNodeItem"></param>
        public void RemoveDirItem(TreeNodeItem treeNodeItem)
        {
            treeNodeItem.Parent = null;
            Items.Remove(treeNodeItem);
        }
    }
}
