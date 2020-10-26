using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Savanna.Tests
{
    public class Validator_PositionIsTaken
    {
        [Fact]
        public void PositionIsTaken_NotEmptyField_returnTrue()
        {
            var field = new Field();
            var position = new Position(5, 5);
            var animal = new Lion() { Position = position };
            field.Animals.Add(animal);
            var sut = new Validator();

            var result = sut.PositionIsTaken(field, position);

            result.Should().BeTrue();
        }

        [Fact]
        public void PositionIsTaken_EmptyField_returnFalse()
        {
            var field = new Field();
            var position = new Position(5, 5);
            var sut = new Validator();

            var result = sut.PositionIsTaken(field, position);

            result.Should().BeFalse();
        }

        [Fact]
        public void PositionIsTaken_NotEmptyField_returnFalse()
        {
            var field = new Field();
            var animalPosition = new Position(5, 5);
            var positionForTest = new Position(0, 0);
            var animal = new Lion() { Position = animalPosition };
            field.Animals.Add(animal);
            var sut = new Validator();

            var result = sut.PositionIsTaken(field, positionForTest);

            result.Should().BeFalse();
        }
    }
}
