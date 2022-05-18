using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using DipaulTestTask.ViewModels;
using DipaulTestTask.Service;
using DipaulTestTask.Interfaces;


namespace DipaulTestTask
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        private static IHost _Hosting;

        public static IHost Hosting
        {
            get
            {
                if (_Hosting != null) return _Hosting;
                var host_builder = Host
                                    .CreateDefaultBuilder(Environment.GetCommandLineArgs());

                host_builder.ConfigureServices(ConfigureServices);

                return _Hosting = host_builder.Build();

            }
        }

        public static IServiceProvider Services => Hosting.Services;

        public static void ConfigureServices(
            HostBuilderContext host,
            IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();

            /*const string dataFileName = "Companies.xml";
            var fileStorage = new DataStorageInXmlFile(dataFileName);*/
            var companyStorage = new DataStorageInXmlFile();
            services.AddSingleton<ICompanyStorage>(companyStorage);
        }
    }
}
