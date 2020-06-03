using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.WPF
{
    public class MineMapCreateMessage
    {
        public int Width { get; }
        public int Height { get; }
        public int BombsCount { get; }
        public IReadOnlyCollection<IMineItemView> MineItemViews { get; }
        public MineMapCreateMessage(int width, int height, int bombsCount, List<IMineItemView> mineItemViews)
        {
            Width = width;
            Height = height;
            BombsCount = bombsCount;
            MineItemViews = mineItemViews.AsReadOnly();
        }
    }

    public class MineMapClickMessage
    {
        public MineMapClickMessage(int y, int x)
        {
            Y = y;
            X = x;
        }

        public int Y { get; }
        public int X { get; }
    }

    public class MineMapViewModelActor : ReceiveActor
    {
        public MineMap MineMap { get; set; }

        public IMineMapViewModel ViewModel { get; set; }

        public MineMapViewModelActor(IMineMapViewModel viewModel)
        {
            ViewModel = viewModel;
            Receive<string>(value => Handle(value));
            Receive<MineMapCreateMessage>(value => Handle(value));
            Receive<MineMapClickMessage>(value => Handle(value));
        }

        private void Handle(MineMapClickMessage value)
        {
            MineMap.Click(value.Y, value.X);
        }

        private void Handle(MineMapCreateMessage msg)
        {
            MineMap = new MineMap(msg.Width, msg.Height);
            MineMap.GenerateBombs(msg.BombsCount);
            MineMap.GenerateCountNearBombs();

            foreach(var child in Context.GetChildren())
            {
                child.Tell(PoisonPill.Instance);
            }

            foreach(var vm in msg.MineItemViews)
            {
                Context.ActorOf(MineItemViewModelActor.Props(vm));
            }
        }

        public static Props Props(IMineMapViewModel viewModel)
        {
            return Akka.Actor.Props.Create(
                () => new MineMapViewModelActor(viewModel));
        }
        public void Handle(string value)
        {
            if (value == "Hello")
                Sender.Tell("World");
        }
    }
}
