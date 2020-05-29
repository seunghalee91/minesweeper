﻿using System;
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
        public MineMapView()
        {
            InitializeComponent();
            //var mineMapViewModel = new MineMapViewModel();
            //mineMapViewModel.PrepareGame();
            DataContext =new MineMapViewModel();
        }
    }       
}
