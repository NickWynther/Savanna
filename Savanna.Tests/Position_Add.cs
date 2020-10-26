using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Savanna.Tests
{
    public class Position_Add
    {
        [Theory]
        [InlineData(20, 30, 2, 2, 22, 32)]
        [InlineData(30, 11, -2, -1, 28, 10)]
        [InlineData(0, 0, 3, 3, 3, 3)]
        [InlineData(0, 0, 0, 0, 0, 0)]
        public void PositionAdd_Input_returnExpected(int x, int y, int dx, int dy, int resultX , int resultY)
        {
            var sut = new Position(x, y);
            var step = new Position(dx, dy);
            var expected = new Position(resultX, resultY);

            var result = sut.Add(step);

            result.Should().BeEquivalentTo(expected);
            result.Should().BeEquivalentTo(sut);
            result.Should().BeSameAs(sut);
        }
    }
}
