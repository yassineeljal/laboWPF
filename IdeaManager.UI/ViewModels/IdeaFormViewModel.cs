using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaFormViewModel: ObservableObject
    {
        private readonly IIdeaService _ideaService;

        public IdeaFormViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        [ObservableProperty]
        private string confirmation;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [RelayCommand(CanExecute = nameof(_canSubmit))]
        private async Task SubmitAsync()
        {
            MessageBox.Show("Soumission de l'idée");
            try
            {
                var idea = new Idea
                {
                    Title = Title,
                    Description = Description
                };

                await _ideaService.SubmitIdeaAsync(idea);
                confirmation = "Idée envoyée";
            }
            catch (Exception ex)
            {
                confirmation = string.Empty;
                MessageBox.Show("dada");
            }
        }

        private bool _canSubmit()
        {
            return !string.IsNullOrWhiteSpace(Title);
        }
    }
}
