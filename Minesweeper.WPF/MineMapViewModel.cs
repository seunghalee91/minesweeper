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
        public MineMap MineMap { get; private set; }
        public MineItemView[,] Buttons { get; set; }
        public int _colCount { get; set; }
        public int _rowCount { get; set; }

        public int ColCount
        {
            get
            {
                return _colCount;
            }
            set
            {
                _colCount = value;
                OnPropertyChanged();
            }
        }
        public int RowCount
        {
            get
            {
                return _rowCount;
            }
            set
            {
                _rowCount = value;
                OnPropertyChanged();
            }
        }


        public void CreateMap(int width,int height)
        {
            MineMap = new MineMap(RowCount, ColCount);
            MineMap.GenerateBombs(3);
            MineMap.GenerateCountNearBombs();
        }
        public void CreateButtons()
        {
            Buttons = new MineItemView[5, 5];
            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Buttons[i, j] = new MineItemView(MineMap.MineItems[i, j]);
                    Buttons[i, j].Width = 70;
                    Buttons[i, j].Height = 70;
                    Grid.SetColumn(Buttons[i, j], i);
                    Grid.SetRow(Buttons[i, j], j);
                    //xmlgrid1.Children.Add(button[i, j]);
                }
            }
        }

        public MineMapViewModel()
        {
            ColCount = 5;
            RowCount = 5;
            CreateMap(ColCount, RowCount);
        }
    }
}