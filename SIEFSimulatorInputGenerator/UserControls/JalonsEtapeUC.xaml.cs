﻿using SIEFSimulatorInputGenerator.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIEFSimulatorInputGenerator.UserControls
{
    /// <summary>
    /// Interaction logic for JalonsEtapeUC.xaml
    /// </summary> 
    public partial class JalonsEtapeUC : UserControl
    {
        public JalonsEtapeUC(JalonsEtapeUCViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}