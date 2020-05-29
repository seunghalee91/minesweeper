using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Minesweeper.WPF
{
    public class MineItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _content;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }
        public MineItem MineItem;
        public DelegateCommand ClickCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }
        public MineItemViewModel(MineItem mineItem, Action clickAction)
        {
            MineItem = mineItem;
            Content = MineItem.ToString();
            ClickCommand = new DelegateCommand(_ => clickAction());
        }
    }
}
