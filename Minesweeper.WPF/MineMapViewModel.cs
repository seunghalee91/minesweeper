using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Timers;

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
        public int BombCount { get; private set; }
        public string ResetContent { get; set; } = "map Reset";
        public string _boombStatue { get; set; } = "Collapsed";
        public DelegateCommand ResetCommand { get; set; }
        private string _enableButton { get; set; }
        public MineMap MineMap { get; set; }    
        public ObservableCollection<MineItemViewModel> MineItemViewModels { get; set; } = new ObservableCollection<MineItemViewModel>();
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
        public string BoombStatue
        {
            get
            {
                return _boombStatue;
            }
            set
            {
                _boombStatue = value;
                OnPropertyChanged(nameof(BoombStatue));
            }
        }

        public string EnableButton
        {
            get
            {
                return _enableButton;
            }
            set
            {
                _enableButton = value;
                OnPropertyChanged(nameof(EnableButton));
            }
        }
        public MineMapViewModel()
        {
            RowCount = 5;
            ColCount = 5;
            BombCount = 3;
            MineMap = new MineMap(RowCount, ColCount);  
            ResetCommand = new DelegateCommand(_ => ResetAction());
        }
        public void PrepareGame()
        {
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
                EnableButton = "false";
                BoombStatue = "Visible";
                for (int i = 0; i < RowCount; i++)
                {
                    for (int j = 0; j < ColCount; j++)
                    {
                        this.MineMap.MineItems[i, j].IsCovered = false;
                    }
                }
            }
        }
        private void ResetAction()
        {
            int row = RowCount;
            int col = ColCount;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    MineMap.MineItems[i, j] = null;
                    MineMap = new MineMap(row, col);
                }
            }

            PrepareGame();
            EnableButton = "true";
            BoombStatue = "Hidden";
        }
    }
}