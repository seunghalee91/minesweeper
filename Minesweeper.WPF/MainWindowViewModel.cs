using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Minesweeper.WPF
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public MineMapViewModel MineMapViewModels { get; set; }

        public string Content { get; set; } = "Reset";
        public DelegateCommand ResetCommand { get; set; }       
        public MainWindowViewModel(MineMapViewModel mineMapViewModel)
        {
            MineMapViewModels = mineMapViewModel;
            ResetCommand = new DelegateCommand(_ => ResetAction());
        }

        private void ResetAction()
        {
            #region  For Pass TEST
            /*
            int row = MineMapViewModels.RowCount;
            int col = MineMapViewModels.ColCount;
            for (int i=0;i<row;i++)
            {
                for(int j=0;j<col;j++)
                {
                    MineMapViewModels.MineMap.MineItems[i,j] = null;
                    MineMapViewModels.MineMap = new MineMap(row, col); 
                }
            }
            */
            #endregion

            MineMapViewModels.PrepareGame();
        }
    }
}
