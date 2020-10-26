using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Savanna.Tests
{
    public class Position_Clone
    {
        [Fact]
        public void PositionClone_works()
        {
            var x = 5;
            var y = 20;
            var sut = new Position(x, y);

            var result = sut.Clone();

            result.Should().NotBeSameAs(sut);
            result.Should().NotBeNull();
            result.Should().BeOfType(sut.GetType());
            result.Should().Be(sut);
        }
    }
}
