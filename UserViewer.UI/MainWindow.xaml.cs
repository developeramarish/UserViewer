using System.Windows;
using UserViewer.Presentation;

namespace UserViewer.UI
{
  public partial class MainWindow : Window
  {
    private UserViewModel viewModel;
    public MainWindow(UserViewModel viewModel)
    {
      InitializeComponent();
      this.viewModel = viewModel;
      DataContext = viewModel;      
    }

    private async void FetchButton_Click(object sender, RoutedEventArgs e)
    {
      await viewModel.RefreshUsers();
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
      viewModel.ClearUsers();
    }
  }
}
