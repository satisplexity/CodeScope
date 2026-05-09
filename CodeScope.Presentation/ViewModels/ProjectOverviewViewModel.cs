using System;
using System.Collections.Generic;
using System.Text;
using CodeScope.Domain.Projects;
using CodeScope.Presentation.ViewModels.Base;

namespace CodeScope.Presentation.ViewModels
{
    public class ProjectOverviewViewModel : ViewModelBase
    {
        public Project CurrentProject { get; }

        public ProjectOverviewViewModel(Project project)
        {
            CurrentProject = project;
        }
    }
}