	using Microsoft.Extensions.Logging;
	using IUP_BMI_Calculator.Repository;

	namespace IUP_BMI_Calculator;


	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

			long studentID = 5999222007;
			string studentName = "HugoFRANGIAMONE";
			string dbPath = FileAccessHelper.GetLocalFilePath($"BMIResult_{studentID}_{studentName}.db3");
			builder.Services.AddSingleton<BMIResultRepository>(s => ActivatorUtilities.CreateInstance<BMIResultRepository>(s, dbPath));

	#if DEBUG
			builder.Logging.AddDebug();
	#endif

			return builder.Build();
		}
	}
