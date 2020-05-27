using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Minesweeper.WPF
{
    public class MineItemViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ClickedCommand { get; set; }

        virtual public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _context = default(string);

        public MineItemViewModel(MineItem mineItem)
        {
            MineItem = mineItem;
            ButtonText = MineItem.ToString();
            ClickedCommand = new DelegateCommand(_ => { ButtonText = "test"; });
        }

        public string ButtonText
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
                OnPropertyChanged(nameof(ButtonText));
            }
        }

        public MineItem MineItem { get; set; }



    }
}
