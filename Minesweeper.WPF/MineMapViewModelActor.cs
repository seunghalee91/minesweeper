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
        public IReadOnlyCollection<IMineItemViewModel> MineItemViews { get; }
        public MineMapCreateMessage(int width, int height, int bombsCount, List<IMineItemViewModel> mineItemViews)
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
        public List<IActorRef> Children { get; set; }

        public MineMapViewModelActor(IMineMapViewModel viewModel)
        {
            ViewModel = viewModel;
            Receive<string>(value => Handle(value));
            Receive<MineMapCreateMessage>(value => Handle(value));
            Receive<ClickMessage>(value => Handle(value));
        }

        private void Handle(ClickMessage value)
        {
            MineMap.Click(value.Y, value.X);

            var combined = Children.Zip(MineMap.MineItems.Cast<MineItem>(), (a, b) => (a, b));
            foreach (var (child, mineItem) in combined)
            {
                child?.Tell(mineItem.ToString());
            }
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

            Children = new List<IActorRef>();

            foreach (var vm in msg.MineItemViews)
            {
                vm.Actor = Context.ActorOf(MineItemViewModelActor.Props(vm));
                Children.Add(vm.Actor);
            }

            var x = MineMap.MineItems.Cast<MineItem>().ToList();
            for (int i =0; i < Children.Count; i++)
            {
                Children[i].Tell(x[i].ToString());
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
