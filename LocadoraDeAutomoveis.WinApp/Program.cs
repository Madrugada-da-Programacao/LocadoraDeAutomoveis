using FluentValidation;
using Serilog;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace LocadoraDeAutomoveis.WinApp
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.Seq("http://localhost:5341")
				.CreateLogger();

			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new TelaPrincipalForm());
		}
	}
}