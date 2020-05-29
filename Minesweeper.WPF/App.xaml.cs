
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Minesweeper.WPF
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            _createMainWindow();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        private void _createMainWindow()
        {
            MineMapViewModel viewModel = new MineMapViewModel();
            MainWindowViewModel mainViewModel = new MainWindowViewModel(viewModel);
            MainWindow mainWindow = new MainWindow(mainViewModel);
            viewModel.PrepareGame();
            mainWindow.Show();
        }

    }
}
