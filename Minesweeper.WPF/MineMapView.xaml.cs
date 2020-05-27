using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// MineMapView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MineMapView : UserControl
    {
        public MineMap minemap { get; private set; }
        public MineItemView[,] button { get; set; }

        public MineMapView()
        {
            InitializeComponent();
            DataContext = new MineMapViewModel();
            CreateMap();
            CreateButtons();
        }

        public void CreateMap()
        {
            minemap = new MineMap(5, 5);
            minemap.GenerateBombs(1);
            minemap.GenerateCountNearBombs();
        }

        public void CreateButtons()
        {
            button = new MineItemView[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    button[i, j] = new MineItemView(minemap.MineItems[i, j]);
                    button[i, j].Width = 70;
                    button[i, j].Height = 70;
                    Grid.SetColumn(button[i, j], i);
                    Grid.SetRow(button[i, j], j);
                    xmlgrid1.Children.Add(button[i, j]);
                }
            }
        }

    }       
}
