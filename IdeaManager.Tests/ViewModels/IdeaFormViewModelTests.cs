using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using IdeaManager.UI.ViewModels;
using Moq;

namespace IdeaManager.Tests.ViewModels
{
    public class IdeaFormViewModelTests
    {
        [Fact]
        public void SubmitCommand()
        {
            var mockIdeaService = new Mock<IIdeaService>();
            var viewModel = new IdeaFormViewModel(mockIdeaService.Object);
            viewModel.Title = "Test Idea";
            viewModel.Description = "Test Description";

            viewModel.SubmitCommand.Execute(null);

            mockIdeaService.Verify(x => x.SubmitIdeaAsync(It.IsAny<Idea>()), Times.Once);
            Assert.Equal("Idée envoyée", viewModel.Confirmation);


        }
    }
}
