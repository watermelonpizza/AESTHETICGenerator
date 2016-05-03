using System.Windows;

namespace TextBoxGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainPageViewModel viewModel = new MainPageViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
