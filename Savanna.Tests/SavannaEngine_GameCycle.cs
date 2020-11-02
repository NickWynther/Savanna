using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Savanna.Tests
{
    public class SavannaEngine_GameCycle
    {
        [Fact]
        public void GameCycle_AddTwoAnimalsAndRun_WorksAsExpected()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<IConsole>().SetupSequence(c => c.KeyAvailable()).Returns(true).Returns(true).Returns(false);
            mock.Mock<IConsole>().SetupSequence(c => c.ConsoleKey()).Returns(ConsoleKey.A).Returns(ConsoleKey.L);
            var sut = mock.Create<SavannaEngine>();

            sut.GameCycle(0);

            mock.Mock<IAnimalManager>().Verify(am => am.LocateEnemies(It.IsAny<Field>()), Times.Once);
            mock.Mock<IAnimalManager>().Verify(am => am.DecreaseHealth(It.IsAny<Field>(), 0.5f), Times.Once);
            mock.Mock<IAnimalManager>().Verify(am => am.RemoveCorpses(It.IsAny<Field>()), Times.Once);
            mock.Mock<IAnimalManager>().Verify(am => am.FindPartners(It.IsAny<Field>()), Times.Once);
            mock.Mock<IAnimalManager>().Verify(am => am.GiveBirthToAnimal(It.IsAny<Field>(), It.IsAny<IAnimalFactory>()), Times.Once);
            mock.Mock<IHerbivoreManager>().Verify(hm => hm.Move(It.IsAny<Field>()), Times.Once);
            mock.Mock<ICarnivoreManager>().Verify(cm => cm.Move(It.IsAny<Field>()), Times.Once);
            mock.Mock<IView>().Verify(v => v.Display(It.IsAny<Field>()), Times.Once);
            mock.Mock<IConsole>().Verify(c => c.ConsoleKey(), Times.Exactly(2));
            mock.Mock<IConsole>().Verify(c => c.KeyAvailable(), Times.Exactly(3));
        }

        [Theory]
        [InlineData(ConsoleKey.F20)]
        [InlineData(ConsoleKey.BrowserBack)]
        public void GameCycle_IncorrectUserInput_NotThrowException(ConsoleKey incorrectKey)
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<IConsole>().Setup(c => c.KeyAvailable()).Returns(true);
            mock.Mock<IConsole>().Setup(c => c.ConsoleKey()).Returns(incorrectKey);
            var sut = mock.Create<SavannaEngine>();

            Action act = () => sut.GameCycle(0);

            act.Should().NotThrow();
        }
    }
}
