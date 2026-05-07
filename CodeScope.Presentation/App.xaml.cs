using System.Windows;

using CodeScope.Presentation.Views.Windows;
using CodeScope.Infrastructure.Persistence.Json;
using CodeScope.Application.Projects.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace CodeScope.Presentation
{
    public partial class App : System.Windows.Application
    {
        public IServiceProvider Services { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs startupArgs)
        {
            ShowWindow();

            ServiceCollection services = new ServiceCollection();

            ConfigureServices(services);

            Services = services.BuildServiceProvider();

            base.OnStartup(startupArgs);
        }

        private void ShowWindow()
        {
            Window window = new MainWindow();
            window.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IProjectRepository, JsonProjectRepository>();
        }
    }
}