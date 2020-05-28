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

        public DelegateCommand ClickCommand { get; set; }
        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public MineItem MineItem;

        public string _content { get; set; }

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
        public MineItemViewModel(MineItem mineItem)
        {
            MineItem = mineItem;
            Content = MineItem.ToString();
            ClickCommand = new DelegateCommand(_=> {
                    mineItem.IsCovered = false;
                    Content = mineItem.ToString();
                });
        }
    }
}
