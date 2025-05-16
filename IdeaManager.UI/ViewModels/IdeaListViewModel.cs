using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;

namespace IdeaManager.UI.ViewModels
{
    public class IdeaListViewModel: ObservableObject
    {
        private readonly IIdeaService _ideaService;
        public ObservableCollection<Idea> Ideas { get; set; } = new ObservableCollection<Idea>();

        public IdeaListViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
            LoadIdeas();
        }
        private async void LoadIdeas()
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
