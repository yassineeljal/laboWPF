using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using IdeaManager.UI.ViewModels;
using Moq;

namespace IdeaManager.Tests.ViewModels
{
    public class IdeaListViewModelTest
    {
        [Fact]
        public void LoadIdeasCommand_ShouldLoadIdeas()
        {
            var mockIdeaService = new Mock<IIdeaService>();
            var viewModel = new IdeaListViewModel(mockIdeaService.Object);
            var ideas = new List<Idea>
            {
                new Idea { Id = 1, Title = "Test Idea 1", Description = "Test Description 1" },
                new Idea { Id = 2, Title = "Test Idea 2", Description = "Test Description 2" }
            };
            mockIdeaService.Setup(x => x.GetAllAsync()).ReturnsAsync(ideas);
            viewModel.LoadIdeasCommand.Execute(null);
            Assert.Equal(2, viewModel.Ideas.Count);
            Assert.Equal("Test Idea 1", viewModel.Ideas[0].Title);
            Assert.Equal("Test Idea 2", viewModel.Ideas[1].Title);



        }
    }
}
