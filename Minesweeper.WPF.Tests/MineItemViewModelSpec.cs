using System;
using Xunit;
using FluentAssertions;

namespace Minesweeper.WPF.Tests
{
    public class MineItemViewModelSpec
    {
        [Fact]
        public void Should_Before_Click()
        {
            // arrange
            var mineItem = new MineItem();
            var actual = new MineItemViewModel(mineItem, () => { });
            // act
            // assert
            actual.Content.Should().Be(".");
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
        public void Should_Click(int nearBombsCount)
        {
            // arrange
            var mineItem = new MineItem()
            {
                NearBombsCount = nearBombsCount
            };

            var actual = new MineItemViewModel(mineItem, () =>
            {
                mineItem.IsCovered = false;
            });
            // act
            actual.ClickCommand.Execute(null);
            actual.Content = actual.MineItem.ToString();
            // assert
            actual.Content.Should().Be(nearBombsCount.ToString());
        }

        [Fact]
        public void Should_Click_Bombs()
        {
            // arrange
            var actual = new MineItemViewModel(new MineItem()
            {
                IsBomb = true
            }, null);
            // act
            actual.ClickCommand.Execute(null);
            // assert
            actual.Content.Should().Be("*");
        }
    }
}
