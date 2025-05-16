using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaListViewModel: ObservableObject
    {
        private readonly IIdeaService _ideaService;
        public ObservableCollection<Idea> Ideas { get; set; } = new ObservableCollection<Idea>();

        public IdeaListViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        [RelayCommand]
        private async Task LoadIdeas()
        {
            var ideas = await _ideaService.GetAllAsync();
            Ideas.Clear();
            foreach (var idea in ideas)
            {
                Ideas.Add(idea);
            }
        }


    }
}
