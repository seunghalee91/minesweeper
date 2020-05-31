using System.ComponentModel;

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
        public MineMapViewModel MineMapViewModels { get; set; }

        public MainWindowViewModel(MineMapViewModel mineMapViewModel)
        {
            MineMapViewModels = mineMapViewModel;
        }
<<<<<<< HEAD
=======
        
>>>>>>> 9136e4238fb14ec7c4b1d9f060ad60ca725bbeb2
    }
}
