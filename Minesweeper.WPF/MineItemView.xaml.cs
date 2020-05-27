using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    /// <summary>
    /// MineItemView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MineItemView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        virtual public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _context = default(string);

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

        public MineItemView()
        {
            InitializeComponent();
        }

        public MineItemView(MineItem mineItem) 
        {
            InitializeComponent();
            DataContext = this;
            MineItem = mineItem;
            ButtonText = MineItem.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
