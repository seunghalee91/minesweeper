using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.WPF
{
    public class MainWindowViewModel
    {
        public MineMapViewModel MineMapViewModel { get; set; }
        
        public MainWindowViewModel(MineMapViewModel mineMapViewModel)
        {
            MineMapViewModel = mineMapViewModel;
        }
    }
}
