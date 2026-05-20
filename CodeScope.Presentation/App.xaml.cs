using CodeScope.Presentation.Features.ProjectWorkspace.Features.ProjectSettings;
using CodeScope.Presentation.Features.ProjectWorkspace.Features.ProjectAnalysis;
using CodeScope.Presentation.Features.ProjectWorkspace.Features.Snapshots;
using CodeScope.Presentation.Framework.Navigation.ProjectWorkspace;
using CodeScope.Presentation.Framework.Navigation.Abstractions;
using CodeScope.Presentation.Framework.Navigation.Root;
using CodeScope.Presentation.Features.ProjectWorkspace;
using CodeScope.Presentation.Features.CreateProject;
using CodeScope.Application.Snapshots.Abstractions;
using CodeScope.Presentation.Features.ProjectsHub;
using CodeScope.Application.Projects.Abstractions;
using CodeScope.Infrastructure.Persistence.Json;
using CodeScope.Presentation.Framework.Services;
using CodeScope.Presentation.Features.Settings;
using Microsoft.Extensions.DependencyInjection;
using CodeScope.Presentation.Features.Archive;
using CodeScope.Presentation.Features.Shell;
using System.Windows;

namespace CodeScope.Presentation
{
    public partial class App : System.Windows.Application
    {
        private IServiceProvider _serviceProvider = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

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
            services.AddSingleton<ISnapshotRepository, JsonSnapshotRepository>();

            services.AddScoped<CreateProjectService>();

            // Navigation stores
            services.AddSingleton<RootNavigationStore>();
            services.AddSingleton<ProjectWorkspaceNavigationStore>();
            
            // Navigation services
            services.AddSingleton<IRootNavigationService, RootNavigationService>();
            services.AddSingleton<IProjectWorkspaceNavigationService, ProjectWorkspaceNavigationService>();
            
            // Main window
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>(serviceProvider => new MainWindow
            {
                DataContext = serviceProvider.GetRequiredService<MainViewModel>()
            });

            // Root-level ViewModels
            services.AddTransient<ArchiveViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<ProjectsHubViewModel>();
            services.AddTransient<CreateProjectViewModel>();
            services.AddTransient<ProjectWorkspaceViewModel>();

            // Workspace-level ViewModels
            services.AddTransient<SnapshotsViewModel>();
            services.AddTransient<ProjectAnalysisViewModel>();
            services.AddTransient<ProjectSettingsViewModel>();
        }
    }
}