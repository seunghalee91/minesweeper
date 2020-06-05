using Akka.Actor;
using System.Collections.Generic;
using System.Linq;

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

    public class MineMapViewModelActor : ReceiveActor
    {
        public MineMap MineMap { get; set; }
        public IMineMapViewModel ViewModel { get; set; }
        public List<IActorRef> Children { get; set; }
        public MineMapViewModelActor(IMineMapViewModel viewModel)
        {
            ViewModel = viewModel;
            Receive<MineMapCreateMessage>(value => Handle(value));
            Receive<ClickMessage>(value => Handle(value));
            Receive<bool>(value => Handle(value));
        }

        public void ShowMap()
        {
            var x = MineMap.MineItems.Cast<MineItem>().ToList();

            for (int i = 0; i < Children.Count; i++)
            {
                x[i].IsCovered = false;
                Children[i].Tell(x[i].ToString());
            }
        }
        private void Handle(bool EndFlag)
        {
            var x = MineMap.MineItems.Cast<MineItem>().ToList();
            int ItemCount = x.Count - MineMap.CountBombs;

            if (EndFlag)
            {
                for (int i = 0; i < Children.Count; i++)
                {
                    if(x[i].IsCovered == false)
                    {
                        ItemCount--;
                        if(x[i].IsBomb)
                        {
                            ViewModel.BoombStatue = "Visible";
                            ViewModel.EnableButton = "false";
                            ShowMap();
                            return;
                        }
                    }

                    if(ItemCount == 0)
                    {
                        ViewModel.SuccessStatue = "Visible";
                        ViewModel.EnableButton = "false";
                        ShowMap();
                        return;
                    }
                }
            }
        }
        private void Handle(ClickMessage value)
        {
            MineMap.Click(value.Y, value.X);

            Self.Tell(MineMap.CheckEndGame());

            var x = MineMap.MineItems.Cast<MineItem>().ToList();
            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].Tell(x[i].ToString());
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
    }
}
