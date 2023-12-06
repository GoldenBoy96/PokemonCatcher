using AutoMapper;
using BusinessLogic.AutoMappers;
using DataAccessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokemonCatcherWPF.AdminPage;
using Repository.IRepository;
using Repository.Repository;
using Repository.UnitOfWork;
using Service.Abstraction;
using Service.Implement;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PokemonCatcherWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        public static ServiceProvider ServiceProvider { get; internal set; }

        private void ConfigureServices(ServiceCollection services)
        {
            IConfigurationRoot configuration = (new ConfigurationBuilder())
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();


            services.AddSingleton<MainWindow>();

            //Repository
            services.AddSingleton<IPokemonMoveRepository, PokemonMoveRepository>();
            services.AddSingleton<IPokemonRepository, PokemonRepository>();
            services.AddSingleton<IPokemonSpecieRepository, PokemonSpecieRepository>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            //Service
            services.AddTransient<IPokemonService, PokemonService>();

            //Mapper
            //services.AddAutoMapper(typeof(AutoMapperProfile));
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
