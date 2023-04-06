using IUP_BMI_Calculator.Repository;

namespace IUP_BMI_Calculator;

public partial class App : Application
{
    public BMIResultRepository BMIResultRepository { get; private set; }

    public App()
    {
        InitializeComponent();
        long studentID = 5999222007;
        string studentName = "HugoFRANGIAMONE";
        string dbPath = FileAccessHelper.GetLocalFilePath($"BMIResult_{studentID}_{studentName}.db3");
        BMIResultRepository = new BMIResultRepository(dbPath);

        MainPage = new AppShell();
    }
}
