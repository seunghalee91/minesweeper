using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minesweeper.WPF
{
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void _StartCommand(object obj)
        {
            AddView add = new AddView();

            if(add.ShowDialog() == true)
            {
                if (Level_listbox.SelectedIndex == 0)
                {
                    //begginer
                }
                else if (Level_listbox.SelectedIndex == 1)
                {
                    //advanced
                }
                add.ShowDialog();
            }
        }
        private void _CancelCommand(object obj)
        {
            this.Close();
        }

        public DelegateCommand StartCommandAction { get; set; }
        public DelegateCommand CancelCommandAction { get; set; }

        public MainWindow()
        {
            Title = "Mine Sweeper";
            Width = 400;
            Height = 400;
            InitializeComponent();
            DataContext = this;


            string[] selectLevel = new string[] { "Begginer", "Advanced" };
            Level_listbox.ItemsSource = selectLevel;



            StartCommandAction = new DelegateCommand(_StartCommand);
            CancelCommandAction = new DelegateCommand(_CancelCommand);


        }

    }
}
