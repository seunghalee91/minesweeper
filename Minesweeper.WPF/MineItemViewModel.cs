using Akka.Actor;
using Minesweeper.Akka;
using System;
using System.ComponentModel;

namespace Minesweeper.WPF
{
    public class MineItemViewModel : INotifyPropertyChanged, IMineItemViewModel
    {
        #region  PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string _content;
        private string _clickEnable { get; set; } = "true";
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
        public string ClickEnable
        {
            get
            {
                return _clickEnable;
            }
            set
            {
                if(Content == "*")
                {
                    _clickEnable = "false";
                }
            }
        }
        public MineItem MineItem;
        public DelegateCommand ClickCommand { get; set; }
        public IActorRef Actor { get; set; }
        public MineItemViewModel(int y, int x)
        {
            int Y = y;
            int X = x;
            ClickCommand = new DelegateCommand(_ => Actor?.Tell(new ClickMessage(Y, X)));
        }
    }
}
