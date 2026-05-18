using CodeScope.Application.Projects.Abstractions;
using CodeScope.Infrastructure.Persistence.Json;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

using CodeScope.Presentation.Features.Shell;

namespace CodeScope.Presentation
{
    public partial class App : System.Windows.Application
    {
        private IServiceProvider _serviceProvider = null!;

        protected override void OnStartup(StartupEventArgs startupArgs)
        {
            base.OnStartup(startupArgs);

            ServiceCollection services = new();

            ConfigureServices(services);

            _serviceProvider = services.BuildServiceProvider();

            ShowWindow();
        }

        protected override void OnExit(ExitEventArgs exitArgs)
        {
            if (_serviceProvider is IDisposable disposable)
                disposable.Dispose();

            base.OnExit(exitArgs);
        }

        private void ShowWindow()
        {
            MainWindow window = _serviceProvider.GetRequiredService<MainWindow>();

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