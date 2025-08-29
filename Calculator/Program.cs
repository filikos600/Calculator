using Calculator.Presenter;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.View
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); //TODO leave or not ???
            ApplicationConfiguration.Initialize();

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            var services = new ServiceCollection();
            services.AddSingleton<IDatabaseManager, DatabaseManager>();

            services.AddSingleton<IMathEvaluator, MathEvaluator>();
            services.AddSingleton<IExchangeEvaluator, ExchangeEvaluator>();

            services.AddTransient<IExpressionBuilder, ExpressionBuilder>();

            services.AddTransient<MathView>();
            services.AddTransient<ExchangeView>();
            services.AddTransient<BestRateHistory>();

            services.AddSingleton<MainForm>();

            services.AddDbContext<SQLiteDbContext>();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"An unexpected error occurred:\n{e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                MessageBox.Show($"A fatal error occurred:\n{ex.Message}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}