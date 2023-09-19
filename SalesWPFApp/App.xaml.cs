using BusinessObject.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServieces(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServieces(ServiceCollection services)
        {
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailsRepository>();
            services.AddScoped<IProductReposity, ProductRepository>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartUp(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            if(mainWindow != null )
            {
                mainWindow.Show();
            }
        }
    }
}
