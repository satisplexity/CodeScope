using CodeScope.Application.Projects.Abstractions;
using CodeScope.Infrastructure.Persistence.Json;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;

using CodeScope.Presentation.Features.Shell;

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
            //services.AddSingleton<StartViewModel>();
            //services.AddSingleton<CreateProjectViewModel>();
            //services.AddSingleton<ProjectOverviewViewModel>();

            services.AddSingleton<MainWindow>();
        }
    }
}