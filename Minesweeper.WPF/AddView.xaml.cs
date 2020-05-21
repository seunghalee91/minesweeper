using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using Minesweeper;
using System.Collections;

namespace Minesweeper.WPF
{
    /// <summary>
    /// AddView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddView : Window
    {
        public AddView()
        {
            Title = "MineSweeper";
            Width = 500;
            Height = 500;

            InitializeComponent();

            // Example.. 


            #region 11
            //List<List<int>> lsts = new List<List<int>>();

            //for (int i = 0; i < 5; i++)
            //{
            //    lsts.Add(new List<int>());

            //    for (int j = 0; j < 5; j++)
            //    {
            //        lsts[i].Add(i * 10 + j);
            //    }
            //}

            //itemcontrol1.ItemsSource = lsts;
            #endregion

            var mineMap = new MineMap(5, 5);
            mineMap.GenerateBombs(3);
            mineMap.GenerateCountNearBombs();






            Button[] btn = new Button[25];
            int cnt = 0;

            //btn[0] = new Button();
            //btn[0].Width = 50;
            //btn[0].Height = 50;

            //btn[0].Content = mineMap.MineItems[0,0];


            //Grid.SetRow(btn[0], 0);
            //Grid.SetColumn(btn[0], 0);

            //grid1.Children.Add(btn[0]);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    btn[cnt] = new Button();
                    
                    btn[cnt].Content = mineMap.MineItems[i, j];
                    btn[cnt].Click += btn_Click;
                    Grid.SetRow(btn[cnt], j);
                    Grid.SetColumn(btn[cnt], i);

                    grid1.Children.Add(btn[cnt]);

                    cnt++;
                }
            }
        }


        private void btn_Click(object sender,RoutedEventArgs e)
        {
            Button btn = sender as Button;
 
            btn.Content = "clicked";


        }
        #region TEST
        //private void MineMapSet(int v1,int v2)
        //{
        //    for(int i = 0; i < v1; i++)
        //    {
        //        for(int j = 0; j < v2; j++)
        //        {
        //            RowDefinition row = new RowDefinition();

        //        }
        //    }
        //}

        //public static DataView GetBindable2DArray<T>(T[,] array)
        //{
        //    var table = new DataTable();
        //    for (var i = 0; i < array.GetLength(1); i++)
        //    {
        //        table.Columns.Add(Convert.ToString(i+1), typeof(bool))
        //                     .ExtendedProperties.Add("idx", i); // Save original column index
        //    }
        //    for (var i = 0; i < array.GetLength(0); i++)
        //    {
        //        table.Rows.Add(table.NewRow());
        //    }

        //    var view = new DataView(table);
        //    for (var ri = 0; ri < array.GetLength(0); ri++)
        //    {
        //        for (var ci = 0; ci < array.GetLength(1); ci++)
        //        {
        //            view[ri][ci] = array[ri, ci];
        //        }
        //    }

        //    // Avoids writing an 'AutogeneratingColumn' handler
        //    table.ColumnChanged += (s, e) =>
        //    {
        //        var ci = (int)e.Column.ExtendedProperties["idx"]; // Retrieve original column index
        //        var ri = e.Row.Table.Rows.IndexOf(e.Row); // Retrieve row index

        //        array[ri, ci] = (T)view[ri][ci];
        //    };

        //    return view;
        //}
        #endregion 
    }
    //public class ListParser
    //{
    //    public int x;
    //    public int y;
    //    public string value;
    //    public bool IsValid = false;
    //    public ListParser(List<string> row)
    //    {
    //        if (row != null && row.Count >= 3 && int.TryParse(row[0], out x) && int.TryParse(row[1], out y))
    //        {
    //            IsValid = true;
    //            value = row[2];
    //        }
    //    }
    //}
}
