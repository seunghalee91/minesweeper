using System;
using Xunit;
using FluentAssertions;

namespace Minesweeper.Tests
{
    public class MineMapSpec
    {
        [Fact]
        public void Should_GenerateCountNearBombs()
        {
            // arrange
            MineItem[,] expect = new MineItem[5, 5]
            {
                { new MineItem { IsBomb = false, NearBombsCount = 0 }, new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 0 } },
                { new MineItem { IsBomb = false, NearBombsCount = 0 }, new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = true, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 0 } },
                { new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 3 }, new MineItem { IsBomb = false, NearBombsCount = 3 }, new MineItem { IsBomb = false, NearBombsCount = 2 }, new MineItem { IsBomb = false, NearBombsCount = 0 } },
                { new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = true, NearBombsCount = 1 }, new MineItem { IsBomb = true, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 0 } },
                { new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 2 }, new MineItem { IsBomb = false, NearBombsCount = 2 }, new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 0 } },
            };

            // act
            var mineMap = new MineMap(5, 5);
            mineMap.MineItems[1, 2].IsBomb = true;
            mineMap.MineItems[3, 1].IsBomb = true;
            mineMap.MineItems[3, 2].IsBomb = true;
            mineMap.GenerateCountNearBombs();

            // assert
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mineMap.MineItems[i,j].ToString().Should().Be(expect[i, j].ToString(), $"[{i}, {j}]");
                }
            }
        }

        [Fact]
        public void Should_GenerateCountNearBombs2()
        {
            // arrange
            MineItem[,] expect = new MineItem[5, 5]
            {
                {
                    new MineItem { IsBomb = false, NearBombsCount = 0 },
                    new MineItem { IsBomb = false, NearBombsCount = 1 },
                    new MineItem { IsBomb = false, NearBombsCount = 2 },
                    new MineItem { IsBomb = true },
                    new MineItem { IsBomb = false, NearBombsCount = 1 }
                },
                {
                    new MineItem { IsBomb = false, NearBombsCount = 0 },
                    new MineItem { IsBomb = false, NearBombsCount = 1 },
                    new MineItem { IsBomb = true },
                    new MineItem { IsBomb = false, NearBombsCount = 2 },
                    new MineItem { IsBomb = false, NearBombsCount = 1 }
                },
                {
                    new MineItem { IsBomb = false, NearBombsCount = 1 },
                    new MineItem { IsBomb = false, NearBombsCount = 3 },
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

            // act
            var mineMap = new MineMap(5, 5);
            mineMap.MineItems[0, 3].IsBomb = true;
            mineMap.MineItems[1, 2].IsBomb = true;
            mineMap.MineItems[3, 1].IsBomb = true;
            mineMap.MineItems[3, 2].IsBomb = true;

            mineMap.GenerateCountNearBombs();

            // assert
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mineMap.MineItems[i, j].ToString().Should().Be(expect[i, j].ToString(), $"[{i}, {j}]");
                }
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Should_GenerateBombs(int expectBombCount)
        {
            // arrange

            // act
            var mineMap = new MineMap(5, 5);
            mineMap.GenerateBombs(expectBombCount);

            // assert
            int countBombs = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if(mineMap.MineItems[i, j].IsBomb)
                    {
                        countBombs++;
                    }
                }
            }
            countBombs.Should().Be(expectBombCount);
        }

        [Fact]
        public void Should_Click()
        {
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

            // Act
            var mineMap = new MineMap(5, 5);
            mineMap.MineItems[0, 3].IsBomb = true;
            mineMap.MineItems[1, 2].IsBomb = true;
            mineMap.MineItems[3, 1].IsBomb = true;
            mineMap.MineItems[3, 2].IsBomb = true;

            mineMap.GenerateCountNearBombs();

            mineMap.Click(0, 0);
            //mineMap.MineItems[0, 0].ToString().Should().Be(expect[0, 0].ToString(), $"[{0}, {0}]");
            
            // assert
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mineMap.MineItems[i, j].ToString().Should().Be(expect[i, j].ToString(), $"[{i}, {j}]");
                }
            }
        }

        [Fact]
        public void Should_Click2()
        {
            MineItem[,] expect = new MineItem[5, 5]
            {
                {
                    new MineItem { IsBomb = false, NearBombsCount = 0  },
                    new MineItem { IsBomb = false, NearBombsCount = 1 , IsCovered =false },
                    new MineItem { IsBomb = false, NearBombsCount = 2 },
                    new MineItem { IsBomb = true },
                    new MineItem { IsBomb = false, NearBombsCount = 1 }
                },
                {
                    new MineItem { IsBomb = false, NearBombsCount = 0 },
                    new MineItem { IsBomb = false, NearBombsCount = 1 },
                    new MineItem { IsBomb = true },
                    new MineItem { IsBomb = false, NearBombsCount = 2 },
                    new MineItem { IsBomb = false, NearBombsCount = 1 }
                },
                {
                    new MineItem { IsBomb = false, NearBombsCount = 1 },
                    new MineItem { IsBomb = false, NearBombsCount = 3 },
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

            // Act
            var mineMap = new MineMap(5, 5);
            mineMap.MineItems[0, 3].IsBomb = true;
            mineMap.MineItems[1, 2].IsBomb = true;
            mineMap.MineItems[3, 1].IsBomb = true;
            mineMap.MineItems[3, 2].IsBomb = true;

            mineMap.GenerateCountNearBombs();

            int y = 0;
            int x = 1;
            
            mineMap.Click(y, x);
            //mineMap.MineItems[y,x].ToString().Should().Be(expect[y, x].ToString(), $"[{y}, {x}]");

            // assert
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mineMap.MineItems[i, j].ToString().Should().Be(expect[i, j].ToString(), $"[{i}, {j}]");
                }
            }
        }
    }
}
