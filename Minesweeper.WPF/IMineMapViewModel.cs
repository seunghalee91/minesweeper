using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.WPF
{
    public interface IMineMapViewModel
    {
        string BoombStatue { get; set; }
        string SuccessStatue { get; set; }
        string EnableButton { get; set; }
    }
}