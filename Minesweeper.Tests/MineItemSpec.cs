using System;
using FluentAssertions;
using Xunit;

namespace Minesweeper.Tests
{
    public class MineItemSpec
    {
        [Fact]
        public void Should_Bomb()
        {
            // Arrange

            // Act
            var actual = new MineItem { IsBomb = true };

            // Assert
            actual.ToString().Should().Be("*");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void Should_NearBombsCount(int count)
        {
            // Arrange

            // Act
            var actual = new MineItem { IsBomb = false, NearBombsCount = count };

            // Assert
            actual.ToString().Should().Be(count.ToString());
        }
    }
}
