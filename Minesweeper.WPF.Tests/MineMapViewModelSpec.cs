using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Minesweeper.WPF.Tests
{
    public class MineMapViewModelSpec
    {
        [Fact]
        public void Shoud_Click()
        {
            // arrange
            MineItem[,] expect = new MineItem[5, 5]
            {
                {
                    new MineItem { IsBomb = false, NearBombsCount = 0 , IsCovered =false },
                    new MineItem { IsBomb = false, NearBombsCount = 1 , IsCovered =false },
                    new MineItem { IsBomb = false, NearBombsCount = 2 },
                    new MineItem { IsBomb = true },
                    new MineItem { IsBomb = false, NearBombsCount = 1 }
                },
                {
                    new MineItem { IsBomb = false, NearBombsCount = 0 , IsCovered =false},
                    new MineItem { IsBomb = false, NearBombsCount = 1 , IsCovered =false},
                    new MineItem { IsBomb = true },
                    new MineItem { IsBomb = false, NearBombsCount = 2 },
                    new MineItem { IsBomb = false, NearBombsCount = 1 }
                },
                {
                    new MineItem { IsBomb = false, NearBombsCount = 1 , IsCovered =false},
                    new MineItem { IsBomb = false, NearBombsCount = 3 , IsCovered =false},
                    new MineItem { IsBomb = false, NearBombsCount = 3 },
                    new MineItem { IsBomb = false, NearBombsCount = 2 },
                    new MineItem { IsBomb = false, NearBombsCount = 0 }
                },
                {
                    new MineItem { IsBomb = false, NearBombsCount = 1 },
                    new MineItem { IsBomb = true },
                    new MineItem { IsBomb = true },
                    new MineItem { IsBomb = false, NearBombsCount = 1 },
                    new MineItem { IsBomb = false, NearBombsCount = 0 }
                },
                {
                    new MineItem { IsBomb = false, NearBombsCount = 1 },
                    new MineItem { IsBomb = false, NearBombsCount = 2 },
                    new MineItem { IsBomb = false, NearBombsCount = 2 },
                    new MineItem { IsBomb = false, NearBombsCount = 1 },
                    new MineItem { IsBomb = false, NearBombsCount = 0 }
                },
            };

            var actual = new MineMapViewModel();

            actual.MineMap.MineItems[0, 3].IsBomb = true;
            actual.MineMap.MineItems[1, 2].IsBomb = true;
            actual.MineMap.MineItems[3, 1].IsBomb = true;
            actual.MineMap.MineItems[3, 2].IsBomb = true;
            actual.MineMap.GenerateCountNearBombs();

            // act
            actual.CreateMineItemViewModels();

            // assert
            actual.MineItemViewModels[0].ClickCommand.Execute(null);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    actual.MineItemViewModels[i * 5 + j].Content.Should().Be(expect[i, j].ToString(), $"[{i}, {j}]");
                }
            }
        }
    }
}
