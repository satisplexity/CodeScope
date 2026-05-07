using System.Windows;
using CodeScope.Application.Projects.Abstractions;
using CodeScope.Infrastructure.Persistence.Json;
using Microsoft.Extensions.DependencyInjection;

namespace CodeScope.Presentation
{
    public partial class App : System.Windows.Application
    {
        public IServiceProvider Services { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs startupArgs)
        {
            ServiceCollection services = new ServiceCollection();

            ConfigureServices(services);

            Services = services.BuildServiceProvider();

            base.OnStartup(startupArgs);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IProjectRepository, JsonProjectRepository>();
        }
    }
}