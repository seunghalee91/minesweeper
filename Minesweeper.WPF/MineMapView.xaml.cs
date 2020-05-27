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
        public MineMap minemap { get; private set; }
        public Button[,] button { get; set; }


        public ObservableCollection<MineMap> minemap1 { get; set; }

        public MineMapView()
        {
            InitializeComponent();

            CreateMap();
            CreateButtons();

            minemap1 = new ObservableCollection<MineMap>();


            minemap1.Add(minemap);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;           
      

            if (button != null)
            {
                int row = Grid.GetRow(button);
                int col = Grid.GetColumn(button);
                var Item = minemap.MineItems[row, col];
               
                if (Item.IsBomb == false)
                {
                    if (Item.IsCovered == true)
                    {
                        Item.IsCovered = false;
                        button.Content = Item.NearBombsCount;
                        
                        if(Item.NearBombsCount == 0 )
                        {
                            minemap.Click(row, col);
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
            //minemap = new ObservableCollection<MineMap>() { };
            //minemap.Add(new MineMap(5, 5).);

            minemap = new MineMap(5, 5);
            minemap.GenerateBombs(1);
            minemap.GenerateCountNearBombs();
            minemap.ConvertMap();
        }

        public void CreateButtons()
        {
            button = new Button[5,5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    button[i,j] = new Button();
                    button[i,j].Width = 70;
                    button[i,j].Height = 70;
                    //button[i].Content = minemap.MineItems2[i].NearBombsCount;
                    button[i,j].Content = ".";
                    //button[i, j].SetBinding()
                    button[i,j].Click += Button_Click;
                    Grid.SetColumn(button[i,j], i );
                    Grid.SetRow(button[i,j], j);
                    xmlgrid1.Children.Add(button[i,j]);
                }
            }
        }

    }       
}
