﻿using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.WPF
{
    public class MineMapViewModelActor : ReceiveActor
    {
        public IMineMapViewModel ViewModel { get; set; }

        public MineMapViewModelActor(IMineMapViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public static Props Props(IMineMapViewModel viewModel)
        {
            return Akka.Actor.Props.Create(() => new MineMapViewModelActor(viewModel));
        }
    }
}
