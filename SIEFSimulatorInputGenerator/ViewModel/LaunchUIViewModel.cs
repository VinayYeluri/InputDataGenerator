using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Win32;
using SIEFSimulatorInputGenerator.Model;
using SIEFSimulatorInputGenerator.View;
using System.IO;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class LaunchUIViewModel : ObservableObject
    {
        public static string _Path;   //Stores the selected Filepath which is used for deserialization
        public static string _Select;  //Stores the selected Item from combobox which is used for deserialization
        public LaunchUIViewModel()
        {
            browseCommand = new RelayCommand(Browse);
            startCommand = new RelayCommand(Start);
        }

        /// <summary>
        /// This property is used to set the filePath to the textbox in the Launch UI.
        /// </summary>
        private string filePath;
        public string FilePath
        {
            get => filePath;
            set
            {
                SetProperty(ref filePath, value);
                OnPropertyChanged(nameof(FilePath));
            }
        }

        /// <summary>
        /// This property is binded to the combobox to get the selected item of combobox
        /// </summary>
        private string select;
        public string Select
        {
            get => select;
            set
            {
                SetProperty(ref select, value);
                OnPropertyChanged(nameof(IsEnable));
            }
        }

        /// <summary>
        /// This Command is binded to Browse button
        /// </summary>
        private RelayCommand browseCommand;
        public RelayCommand BrowseCommand
        {
            get => browseCommand;
            private set => SetProperty(ref browseCommand, value);
        }

        /// <summary>
        /// This Command is binded to Start button
        /// </summary>
        private RelayCommand startCommand;
        public RelayCommand StartCommand
        {
            get => startCommand;
            private set => SetProperty(ref startCommand, value);
        }

        /// <summary>
        /// This property is used to enable the buttons(browse, start) when the item in the comboBox is selected.
        /// </summary>
        private bool isEnable;
        public bool IsEnable
        {
            get => isEnable = (Select != null);
            set => SetProperty(ref isEnable, value);
        }

        /// <summary>
        /// This Method opens the dialog box to select JSON file from the local system.
        /// </summary>
        private void Browse()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JSON Files|*.json;";
            if (ofd.ShowDialog() == true)
            {
                FilePath = ofd.FileName;
                _Path = ofd.FileName.ToString();
            }
        }

        /// <summary>
        /// This method navigate to the MainView Window.
        /// </summary>
        private void Start()
        {
            _Select = Select;
            CourseData.JsonDeserialization();
            //if (Select == "Courses")
            //{
            if (Path.GetFileName(_Path) != null)
            {
                if (CourseData.IsJsonCorrect == false)
                {
                    MessageBox.Show("The selected json file is incorrect, it has errors.");
                    CourseData.IsJsonCorrect = true;
                }
                else
                {
                    MainView mv = new MainView();
                    mv.Show();
                    App.Current.MainWindow.Close();
                }
            }
            else
            {
                MainView mv = new MainView();
                mv.Show();
                App.Current.MainWindow.Close();
            }
            //}
        }
    }
}
