using Akka.Actor;

namespace Minesweeper.WPF
{
    public interface IMineItemViewModel
    {
        string Content { get; set; }
        IActorRef Actor { get; set; }
    }
}