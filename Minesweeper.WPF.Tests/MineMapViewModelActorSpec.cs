using Akka.TestKit.Xunit2;
using FluentAssertions;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace Minesweeper.Akka.Tests
{


    public class MineMapViewModelActorSpec : TestKit
    {
        [Fact]
        public void Should_Be_Create()
        {
            // arrange
            var actor = Sys.ActorOf(MineMapViewModelActor.Props(null));
            
            // act
            
            // assert
        }

        [Fact]
        public void Should_Be_Click_Sync()
        {
            // arrange
            var actor = ActorOfAsTestActorRef< MineMapViewModelActor>(MineMapViewModelActor.Props(null));
            var child = 

            // act
            actor.Tell(new ClickMessage(0, 0));

            // assert

        }
    }
}
