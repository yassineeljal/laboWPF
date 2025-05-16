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

        //https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/relaycommand
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
        private string title;

        [ObservableProperty]
        private string description;

        [RelayCommand(CanExecute = nameof(_canSubmit))]
        private async Task SubmitAsync()
        {
            try
            {
                var idea = new Idea
                {
                    Title = Title,
                    Description = Description
                };

                await _ideaService.SubmitIdeaAsync(idea);
                Confirmation = "Idée envoyée";

            }
            catch (Exception ex)
            {
                Confirmation = string.Empty;
                MessageBox.Show("Erreur");
            }
        }

        public bool _canSubmit()
        {
            if(string.IsNullOrWhiteSpace(Title))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
