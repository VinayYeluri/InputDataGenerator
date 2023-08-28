using Microsoft.Toolkit.Mvvm.ComponentModel;
using SIEFSimulatorInputGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.ViewModel
{
    public class CoursesUCViewModel : ObservableObject
    {
        Courses _courseModel;
        public CoursesUCViewModel(Courses courseModel)
        {
            _courseModel = courseModel;
        }

        public string IdCourse
        {
            get { return _courseModel?.idCourse; }
            set { _courseModel.idCourse = value; OnPropertyChanged(nameof(IdCourse)); }
        }
    }
}
