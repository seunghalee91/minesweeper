
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Akka;
using Akka.Actor;

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
            ActorSystem system = ActorSystem.Create("minesweeper");

            MineMapViewModel viewModel = new MineMapViewModel(system, vm => MineMapViewModelActor.Props(vm));
            MainWindowViewModel mainViewModel = new MainWindowViewModel(viewModel);
            MainWindow mainWindow = new MainWindow(mainViewModel);
            mainWindow.Show();

        }

    }
}
