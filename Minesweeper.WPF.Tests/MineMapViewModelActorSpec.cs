using Akka.TestKit.Xunit2;
using FluentAssertions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace Minesweeper.Akka.Tests
{
    class MockMineMap : IMineMap
    {
        public MockMineMap(int w, int h)
        {
            MineItems = new MineItem[1, 1]
            {
                {
                    new MineItem()
                    {
                         IsCovered = false,
                         NearBombsCount = 1,
                    }
                }
            };
        }
        public int Height { get;  }
        public MineItem[,] MineItems { get; set; }
        public int Width { get; }
        public void Click(int y, int x)
        {
        }
        public void GenerateBombs(int value)
        {
        }
        public void GenerateCountNearBombs()
        {
        }
        public int CountBombs => throw new System.NotImplementedException();
        public bool CheckEndGame()
        {
            throw new System.NotImplementedException();
        }
    }

    public class MineMapViewModelActorSpec : TestKit
    {
        [Fact]
        public void Should_Be_Click_Sync()
        {
            // arrange
            var child = CreateTestProbe();
            var actor = ActorOfAsTestActorRef<MineMapViewModelActor>(MineMapViewModelActor.Props(null, (ctx, vm) => child.Ref ));
            //UnderlyingActor : MineMapViewModelActor의 속성들을 가져올수 있음
            actor.UnderlyingActor.MineMapMaker = (w, h) => new MockMineMap(w, h);
            

            // act
            actor.Tell(new MineMapCreateMessage(1, 1, 1, new List<IMineItemViewModel>{ new MockMineItemViewModel(), } ));
            actor.Tell(new ClickMessage(0, 0));

            // assert
            child.ExpectMsg("1");
        }
    }
}
