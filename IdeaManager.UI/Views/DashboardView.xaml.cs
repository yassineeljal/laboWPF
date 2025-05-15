using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IdeaManager.Core.Interfaces;
using IdeaManager.UI.ViewModels;

namespace IdeaManager.UI.Views
{
    /// <summary>
    /// Logique d'interaction pour DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Page
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardView(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        private void NavigateToIdeaList(object sender, RoutedEventArgs e)
        {
            DashFrame.Navigate(new IdeaListView());
        }

        private void NavigateToIdeaForm(object sender, RoutedEventArgs e)
        {
            var ideaService = new IdeaService(_unitOfWork);
            var viewModel = new IdeaFormViewModel(ideaService);
            DashFrame.Navigate(new IdeaFormView(viewModel));
        }
    }
}
