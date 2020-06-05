using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.Xunit2;
using FluentAssertions;
using FluentAssertions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Minesweeper.Akka.Tests
{
    public class MockMineItemViewModel : IMineItemViewModel
    {
        public string Content { get ; set ; }
        public IActorRef Actor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class MineItemViewModelActorSpec : TestKit
    {

        [Fact]
        public void Should_Be_Create()
        {
            // arrange
            var actor = Sys.ActorOf(MineItemViewModelActor.Props(new MockMineItemViewModel()));
            
            // act
                        
            // assert
            
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(3, 4)]
        public void Should_Be_Click(int y, int x)
        {
            // arrange
            var parent = CreateTestProbe();
            var child = parent.ChildActorOf(MineItemViewModelActor.Props(null));
            var msg = new ClickMessage(y, x);

            // act
            child.Tell(msg);

            // assert
            parent.ExpectMsg(msg);
        }

        [Fact]
        public void Should_Be_String_Sync()
        {
            // arrange
            var mivm = new MockMineItemViewModel();
            var actor = ActorOfAsTestActorRef<MineItemViewModelActor>(MineItemViewModelActor.Props(mivm));

            // act
            actor.Tell("1");

            // assert
            mivm.Content.Should().Be("1");
        }
    }
}
