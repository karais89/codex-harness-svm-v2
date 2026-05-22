using NUnit.Framework;

namespace SafeVillage.Core.Tests
{
    public sealed class VillageGameTests
    {
        [Test]
        public void NewGameStartsFromDocumentedInitialState()
        {
            var game = new VillageGame();

            Assert.That(game.State.Day, Is.EqualTo(1));
            Assert.That(game.State.Food, Is.EqualTo(3));
            Assert.That(game.State.Wall, Is.EqualTo(3));
            Assert.That(game.State.MaxWall, Is.EqualTo(5));
            Assert.That(game.State.Villagers, Is.EqualTo(3));
            Assert.That(game.State.Outcome, Is.EqualTo(VillageOutcome.InProgress));
            Assert.That(game.State.IsTerminal, Is.False);
        }

        [Test]
        public void RestartReturnsToDocumentedInitialState()
        {
            var game = new VillageGame();

            game.Restart();

            Assert.That(game.State, Is.EqualTo(VillageState.Initial));
        }
    }
}
