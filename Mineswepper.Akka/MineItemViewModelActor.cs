using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Akka.Actor.Props;

namespace Minesweeper.Akka
{
    public class MineItemViewModelActor : ReceiveActor
    {
        public MineItemViewModelActor(IMineItemViewModel vm)
        {
            MineItemViewModel = vm;
            Receive<string>(value => Handle(value));
            Receive<ClickMessage>(value => Handle(value));
        }

        private void Handle(ClickMessage value)
        {
            Context.Parent.Tell(value);
        }
        private void Handle(string value)
        {
            MineItemViewModel.Content = value;
        }
        public IMineItemViewModel MineItemViewModel { get; }

        public static Props Props(IMineItemViewModel vm)
        {
            return Create(() => new MineItemViewModelActor(vm));
        }
    }
}
