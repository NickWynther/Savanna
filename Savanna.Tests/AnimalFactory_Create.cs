using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Savanna.Tests
{
    public class AnimalFactory_Create
    {
        [Fact]
        public void Create_Lion_WorksAsExpected()
        {
            var field = new Field();
            var lionPosition = new Position(10, 5);
            using var mock = AutoMock.GetLoose();
            mock.Mock<IRandom>().Setup(r => r.Get(field.Width)).Returns(lionPosition.X);
            mock.Mock<IRandom>().Setup(r => r.Get(field.Height)).Returns(lionPosition.Y);
            mock.Mock<IPositionValidator>().Setup(v => v.PositionIsTaken(field, It.IsAny<Position>())).Returns(false);
            var sut = mock.Create<AnimalFactory>();

            var result = sut.Create(field, AnimalType.Lion);

            result.Should().NotBeNull();
            result.Should().BeOfType<Lion>();
            result.Alive.Should().BeTrue();
            result.AnimalType.Should().Be(AnimalType.Lion);
            result.Position.Should().NotBeNull();
            result.Position.Should().BeEquivalentTo(lionPosition);
            result.ClosestEnemy.Should().BeNull();
            result.ClosestPartner.Should().BeNull();
            field.Animals.Count.Should().Be(1);
            mock.Mock<IRandom>().Verify(r => r.Get(field.Width) , Times.Once);
            mock.Mock<IRandom>().Verify(r => r.Get(field.Height) , Times.Once);
            mock.Mock<IPositionValidator>().Verify(v => v.PositionIsTaken(field, It.IsAny<Position>()) , Times.Once);
        }
    }
}
