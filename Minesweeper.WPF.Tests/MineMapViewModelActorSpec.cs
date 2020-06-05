using Akka.TestKit.Xunit2;
using FluentAssertions;
using System.Collections.ObjectModel;
using System.Linq;
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
            MineItemViewModel MineItemViewModels = new MineItemViewModel(1, 1);

            // act
            MineItemViewModels.Content = ".";
            
            //actor.Tell(, TestActor);


            // assert
            MineItemViewModels.Content.Should().Be(".");

        }
    }
}
