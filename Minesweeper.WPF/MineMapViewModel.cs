using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Minesweeper.WPF
{
    public class MineMapViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
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
        public int BombCount { get; private set; }
        public string ResetContent { get; set; } = "map Reset";
        public MineMap MineMap { get; set; }    
        public ObservableCollection<MineItemViewModel> MineItemViewModels { get; set; } = new ObservableCollection<MineItemViewModel>();
        public MineMapViewModel()
        {
            RowCount = 5;
            ColCount = 5;
            BombCount = 3;
            MineMap = new MineMap(RowCount, ColCount);   //For TEST pass
        }
        public void PrepareGame()
        {
            //MineMap = new MineMap(ColCount, RowCount);
            MineMap.GenerateBombs(BombCount);
            MineMap.GenerateCountNearBombs();
            CreateMineItemViewModels();
        }
        public void CreateMineItemViewModels()
        {
            MineItemViewModels.Clear();
            CheckEndGame();
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColCount; j++)
                {
                    int x = j;
                    int y = i;
                    MineItemViewModels.Add(new MineItemViewModel(MineMap.MineItems[i, j], () =>
                    {
                        Click(y, x);
                    }));
                }
            }
        }
        private void Click(int y, int x)
        {
            MineMap.Click(y, x);
            CreateMineItemViewModels();
        }

        private void CheckEndGame()
        {
            if (MineMap.CheckEndGame())
            {
                MessageBox.Show("Boomb");
                for (int i = 0; i < RowCount; i++)
                {
                    for (int j = 0; j < ColCount; j++)
                    {
                        this.MineMap.MineItems[i, j].IsCovered = false;
                    }
                }
            }
        }
    }
}