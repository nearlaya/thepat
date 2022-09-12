using thepat.Models;
using thepat.ViewModels;
using System.Windows;
namespace thepat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
            Unloaded += MainWindow_Unloaded;

            _viewModel = AppConfigurator.Default.Container.GetInstance<MainViewModel>();

            DataContext = _viewModel;
            Show();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel?.OnNavigatedTo();
        }

        private void MainWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            _viewModel?.OnNavigatedFrom();
        }

        private void InfoPanel_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
