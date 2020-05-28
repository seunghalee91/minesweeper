using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


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
        public MineItemViewModel[,] MineItemViewModels { get; set; }
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
            MineMap = new MineMap(ColCount, RowCount);
        }

        public MineMapViewModel()
        {
            ColCount = 5;
            RowCount = 5;
            CreateMap(RowCount, ColCount);
        }

        public void CreateMineItemViewModels()
        {
            MineItemViewModels = new MineItemViewModel[RowCount, ColCount];

            for (int i=0;i< RowCount;i++)
            {
                for(int j=0;j< ColCount;j++)
                {
                    int x = j;
                    int y = i;
                    MineItemViewModels[i, j] = new MineItemViewModel(MineMap.MineItems[i, j], () => 
                    {
                        Click(y, x);
                    });
                }
            }
        }

        private void Click(int y, int x)
        {
            MineMap.Click(y, x);
            CreateMineItemViewModels();
        }
    }
}