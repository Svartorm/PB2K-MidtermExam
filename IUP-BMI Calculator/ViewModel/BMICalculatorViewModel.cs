using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IUP_BMI_Calculator.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUP_BMI_Calculator.ViewModel
{
    internal partial class BMICalculatorViewModel : ObservableObject
    {
        [ObservableProperty]
        public String name;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(BMIScore))]
        [NotifyPropertyChangedFor(nameof(BMIResult))]
        public double height;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(BMIScore))]
        [NotifyPropertyChangedFor(nameof(BMIResult))]
        public double weight;

        public double BMIScore
            => Math.Round(Weight / Math.Pow(Height / 100, 2), 2);

        public String BMIResult
        {
            get
            {
                if (BMIScore < 18.5)
                    return "Underweight";
                else if (BMIScore < 25)
                    return "Healthy";
                else if (BMIScore < 30)
                    return "Overweight";
                else
                    return "Obese";
            }
        }
        
        [RelayCommand]
        public void Save()
        {
            if (string.IsNullOrEmpty(Name) || Height <= 0 || Weight <= 0)
            {
                // Handle the case where the input values are invalid
                return;
            }

            long studentID = 5999222007;
            string studentName = "HugoFRANGIAMONE";
            string dbPath = FileAccessHelper.GetLocalFilePath($"BMIResult_{studentID}_{studentName}.db3");
            var bmiResultRepository = new Repository.BMIResultRepository(dbPath);
            bmiResultRepository.AddNewBMIResult(Name, Height, Weight, BMIScore, BMIResult);

            // Handle the case where the BMI result was successfully saved
            Clear();

        }

        [RelayCommand]
        public void Clear()
        {
            Name = "";
            Height = 0;
            Weight = 0;
        }

    }
}
