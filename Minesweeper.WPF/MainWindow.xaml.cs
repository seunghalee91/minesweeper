using System.Windows;

namespace Minesweeper.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel mainviewModel)
        {
            InitializeComponent();
            mainviewModel.MineMapViewModels.PrepareGame();
            DataContext = mainviewModel;
        }
    }
}
