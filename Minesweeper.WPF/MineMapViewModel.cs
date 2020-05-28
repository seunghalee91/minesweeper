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
            MineMap = new MineMap(RowCount, ColCount);
        }
        public void CreateButtons()
        {
            
        }

        public MineMapViewModel()
        {
            ColCount = 5;
            RowCount = 5;
            CreateMap(ColCount, RowCount);
        }

        public void CreateMineItemViewModels()
        {
            throw new NotImplementedException();
        }
    }
}