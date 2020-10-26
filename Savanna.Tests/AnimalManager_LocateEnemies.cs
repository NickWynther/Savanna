using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Savanna.Tests
{
    public class AnimalManager_LocateEnemies
    {
        [Fact]
        public void LocateEnemies_forLionAndAntelope_worksAsExpected()
        {
            var field = new Field();
            var lion = new Lion();
            var antelope = new Antelope();
            field.Animals.Add(lion);
            field.Animals.Add(antelope);
            var smallDistance = 1.0;
            var calculations = new Mock<ICalculations>();
            calculations.Setup(c => c.Distance(It.IsAny<Animal>(), It.IsAny<Animal>())).Returns(smallDistance);
            var sut = new AnimalManager(calculations.Object);

            sut.LocateEnemies(field);

            lion.ClosestEnemy.Should().Be(antelope);
            antelope.ClosestEnemy.Should().Be(lion);
        }
    }
}
