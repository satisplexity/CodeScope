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

            //CountLines();
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

        private void CountLines()
        {
            string projectPath = @"P:\CodeScope";

            string[] ignoredDirectories =
            [
            "bin",
"obj",
".git",
".vs"
            ];

            string[] allowedExtensions =
            [
            ".cs",
".xaml"
            ];

            int totalLines = 0;

            IEnumerable<string> files = Directory
            .EnumerateFiles(
            projectPath,
            "*.*",
            SearchOption.AllDirectories)
            .Where(file =>
            {
                string extension = Path.GetExtension(file);

                if (!allowedExtensions.Contains(extension))
                {
                    return false;
                }

                string path = file.ToLower();

                return !ignoredDirectories.Any(dir =>
    path.Contains($@"\{dir.ToLower()}\"));
            });

            foreach (string file in files)
            {
                int lineCount = File.ReadAllLines(file).Length;

                totalLines += lineCount;

                Console.WriteLine($"{lineCount} | {file}");
            }

            MessageBox.Show($"Total lines: {totalLines}");
        }
    }
}