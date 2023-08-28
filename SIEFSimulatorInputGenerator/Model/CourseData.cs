using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using SIEFSimulatorInputGenerator.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEFSimulatorInputGenerator.Model
{
    public class CourseData : ObservableObject
    {

        public static bool IsJsonCorrect = true;      //This Property is used to check if the JSON File is correct or not
        public static Root JsonCourseData { get; private set; }     //Deserialized Object
        public static RoulementRoot JsonRoulementData { get; private set; }
        /// <summary>
        /// Deserialization of JSON File
        /// </summary>
        public static void JsonDeserialization()
        {
            if (LaunchUIViewModel._Select == "Courses")
            {
                try
                {
                    string fileName = LaunchUIViewModel._Path;          //Getting selected filepath from the LaunchUIViewModel
                    if (fileName != null)
                    {
                        string jsonString = File.ReadAllText(fileName);
                        JsonCourseData = JsonConvert.DeserializeObject<Root>(jsonString);
                    }
                    else
                    {
                        JsonCourseData = new Root();
                    }
                }
                catch
                {
                    IsJsonCorrect = false;
                }
            }

            else if (LaunchUIViewModel._Select == "Roulement")
            {
                try
                {
                    string fileName = LaunchUIViewModel._Path;          //Getting selected filepath from the LaunchUIViewModel
                    if (fileName != null)
                    {
                        string jsonString = File.ReadAllText(fileName);
                        JsonRoulementData = JsonConvert.DeserializeObject<RoulementRoot>(jsonString);
                    }
                    else
                    {
                        JsonRoulementData = new RoulementRoot();
                    }
                }
                catch
                {
                    IsJsonCorrect = false;
                }
            }
        }
    }
}

