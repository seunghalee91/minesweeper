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
        //public ObservableCollection<MineMap> minemap { get; private set; }
        public MineMap MineMap { get; private set; }
        public MineItemView[,] Buttons { get; set; }


        public ObservableCollection<MineMap> minemap1 { get; set; }

        public MineMapView()
        {
            InitializeComponent();

            CreateMap();
            CreateButtons();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;           
      

            if (button != null)
            {
                int row = Grid.GetRow(button);
                int col = Grid.GetColumn(button);
                var Item = MineMap.MineItems[row, col];
               
                if (Item.IsBomb == false)
                {
                    if (Item.IsCovered == true)
                    {
                        Item.IsCovered = false;
                        button.Content = Item.NearBombsCount;
                        
                        if(Item.NearBombsCount == 0 )
                        {
                            MineMap.Click(row, col);
                        }
                    }
                    else
                    {
                        button.Content = Item.NearBombsCount;
                    }
                }
                else
                {
                    MessageBox.Show("Boom!");
                }
            }
            else
            {
                MessageBox.Show("Button is null");
            }
        }
        public void CreateMap ()
        {
            MineMap = new MineMap(5, 5);
            MineMap.GenerateBombs(1);
            MineMap.GenerateCountNearBombs();
            MineMap.ConvertMap();
        }

        public void CreateButtons()
        {
            Buttons = new MineItemView[5,5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Buttons[i,j] = new MineItemView(MineMap.MineItems[i,j]);
                    Buttons[i,j].Width = 70;
                    Buttons[i,j].Height = 70;
                    Grid.SetColumn(Buttons[i,j], i );
                    Grid.SetRow(Buttons[i,j], j);
                    xmlgrid1.Children.Add(Buttons[i,j]);
                }
            }
        }

    }       
}
