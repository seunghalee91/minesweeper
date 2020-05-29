using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.WPF
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public MineMapViewModel MineMapViewModel { get; set; }
        //public DelegateCommand ResetCommand { get; set; }
        public string Content { get; set; } = "Reset";
       
        public MainWindowViewModel(MineMapViewModel mineMapViewModel)
        {
            MineMapViewModel = mineMapViewModel;
            //ResetCommand = new DelegateCommand();
        }

        
        

    }
}
