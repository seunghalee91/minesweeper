using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.WPF
{
    public class MineCellViewModel
    {
        string _contents { get; set; }
        bool _isOpened { get; set; } = false;       //true == clicked button

        public string Contents
        {
            get
            {
                return _contents;
            }
            set
            {
                if(_isOpened)
                {
                    _contents = value;
                }
            }
        }

        public MineCellViewModel()
        {
        }
        public MineCellViewModel(MineMap minemap )
        {



        }

        //public int GetConvertPoint()
        //{
        //               string strPoint;
        //double dvalue;
        //    for (int i = 0; i<minemap.MineItems2.Length; i++)
        //    {
        //        dvalue = i / 5;
        //        strPoint=dvalue.ToString();
        //        strPoint.Split('.');
        //    }
        //}


        public void ClickCommandAction(object obj)
        {
            _isOpened = true;
        }
    }
}
