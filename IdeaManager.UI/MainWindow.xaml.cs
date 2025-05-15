using System.Text;
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
using IdeaManager.UI.Views;

namespace IdeaManager.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IUnitOfWork _unitOfWork;

    public MainWindow(IUnitOfWork unitOfWork)
    {
        InitializeComponent();
        _unitOfWork = unitOfWork;
    }

    private void Enter_Click(object sender, RoutedEventArgs e)
    {
        Main.Navigate(new DashboardView(_unitOfWork));
        button.Visibility = Visibility.Collapsed;
    }
}