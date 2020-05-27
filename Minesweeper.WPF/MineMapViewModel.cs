using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Minesweeper.WPF
{
    public class MineMapViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public string Contents { get; set; }
        public MineMap minemap { get; set; }
        public int _width;
        public int _height;
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                OnPropertyChanged();
            }
        }
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                OnPropertyChanged();
            }
        }


        //public DelegateCommand ClickCommand { get; set; }
        //public ObservableCollection<MineMap> mineitem { get; set; }


        public MineMapViewModel()
        {
            MineMap minemap = new MineMap(5, 5);
            minemap.GenerateBombs(2);
            minemap.GenerateCountNearBombs();


            //mineitem = new ObservableCollection<MineMap>();


            //mineitem.Add(minemap);

            //CreateMap(5, 5);
            //CreateGrid();

        }

        public void CreateGrid()
        {
            #region
            //grid 
            //Grid DynamicGrid = new Grid();
            //DynamicGrid.Width = 500;
            //DynamicGrid.ShowGridLines = true;

            ////col
            //ColumnDefinition gridcol1 = new ColumnDefinition();
            //ColumnDefinition gridcol2 = new ColumnDefinition();
            //ColumnDefinition gridcol3 = new ColumnDefinition();
            //ColumnDefinition gridcol4 = new ColumnDefinition();
            //ColumnDefinition gridcol5 = new ColumnDefinition();
            //RowDefinition gridrow1 = new RowDefinition();
            //RowDefinition gridrow2 = new RowDefinition();
            //RowDefinition gridrow3 = new RowDefinition();
            //RowDefinition gridrow4 = new RowDefinition();
            //RowDefinition gridrow5 = new RowDefinition();

            ////set
            //DynamicGrid.ColumnDefinitions.Add(gridcol1);
            //DynamicGrid.ColumnDefinitions.Add(gridcol2);
            //DynamicGrid.ColumnDefinitions.Add(gridcol3);
            //DynamicGrid.ColumnDefinitions.Add(gridcol4);
            //DynamicGrid.ColumnDefinitions.Add(gridcol5);

            //DynamicGrid.RowDefinitions.Add(gridrow1);
            //DynamicGrid.RowDefinitions.Add(gridrow2);
            //DynamicGrid.RowDefinitions.Add(gridrow3);
            //DynamicGrid.RowDefinitions.Add(gridrow4);
            //DynamicGrid.RowDefinitions.Add(gridrow5);

            //Button[] button = new Button[25];

            //Button set
            //for(int i=0;i< 25; i++)
            //{
            //    button[i] = new Button();
            //    button[i].Content = "button" + $"{i}";
            //    Grid.SetRow(button[i], i/5);
            //    Grid.SetColumn(button[i], i % 5);
            //    DynamicGrid.Children.Add(button[i]);
            //}
        #endregion

            Canvas canvas1 = new Canvas();
            Button[] button = new Button[25];
            
            for(int i=0;i<25;i++)
            {
                button[i] = new Button();
                button[i].Width = 50;
                button[i].Height = 50;
                //button[i].Content = minemap.MineItems2[i].NearBombsCount;
                Canvas.SetLeft(button[i], 100);
                Canvas.SetTop(button[i],100);
                canvas1.Children.Add(button[i]);
            }
        }

        public void _clickbutton(object obj)
        {
            var button = obj as Button;

            MessageBox.Show(Convert.ToString(button.Content));
        }


        public void CreateMap(int height,int width)
        {
            Width = width;
            Height = height;

            minemap = new MineMap(Height, Width);
            minemap.GenerateBombs(4);
            minemap.GenerateCountNearBombs();
            minemap.ConvertMap();
        }

        public void GetContents()
        {
            Contents = "TEST";
        }
    }
}