using Akka.TestKit.Xunit2;
using FluentAssertions;
using Xunit;

namespace Minesweeper.WPF.Tests
{
    public class MineMapViewModelActorSpec : TestKit
    {
        [Fact]
        public void Should_Be_Create()
        {
            // arrange
            var actor = Sys.ActorOf(MineMapViewModelActor.Props(null));
            // act
            actor.Tell("Hello", TestActor);

            // assert
            ExpectMsg("World");

        }
    }
}
