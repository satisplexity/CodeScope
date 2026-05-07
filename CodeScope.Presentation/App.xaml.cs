using CodeScope.Application.Projects.Abstractions;
using CodeScope.Infrastructure.Persistence.Json;
using CodeScope.Presentation.ViewModels;
using CodeScope.Presentation.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CodeScope.Presentation
{
    public partial class App : System.Windows.Application
    {
        public IServiceProvider Services { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs startupArgs)
        {
            base.OnStartup(startupArgs);

            ServiceCollection services = new();

            ConfigureServices(services);

            Services = services.BuildServiceProvider();
            
            ShowWindow();
        }

        private void ShowWindow()
        {
            MainWindow window = Services.GetRequiredService<MainWindow>();

            window.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IProjectRepository, JsonProjectRepository>();
            
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<ProjectsViewModel>();

            services.AddSingleton<MainWindow>();
        }
    }
}