using Akka.Actor;

namespace Minesweeper.Akka
{
    public interface IMineItemViewModel
    {
        string Content { get; set; }
        IActorRef Actor { get; set; }
    }
}