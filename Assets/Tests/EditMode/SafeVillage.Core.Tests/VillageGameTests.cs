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

        [Test]
        public void RejectsAssignmentsWithNegativeCountsOrWrongTotal()
        {
            var game = new VillageGame();

            Assert.That(game.CanResolve(new VillageAssignment(-1, 2, 2), out _), Is.False);
            Assert.That(game.CanResolve(new VillageAssignment(1, 1, 0), out _), Is.False);
        }

        [Test]
        public void ResolveDayRejectsInvalidAssignmentWithoutChangingState()
        {
            var game = new VillageGame();

            Assert.Throws<System.InvalidOperationException>(() => game.ResolveDay(new VillageAssignment(1, 1, 0)));
            Assert.That(game.State, Is.EqualTo(VillageState.Initial));
            Assert.That(game.LastReport, Is.Null);
        }

        [Test]
        public void ResolveDayAppliesAssignmentAndReturnsReport()
        {
            var game = new VillageGame();

            var report = game.ResolveDay(new VillageAssignment(2, 1, 0));

            Assert.That(game.State.Day, Is.EqualTo(2));
            Assert.That(game.State.Food, Is.EqualTo(4));
            Assert.That(game.State.Wall, Is.EqualTo(3));
            Assert.That(game.State.Outcome, Is.EqualTo(VillageOutcome.InProgress));
            Assert.That(report.Day, Is.EqualTo(1));
            Assert.That(report.FoodGained, Is.EqualTo(4));
            Assert.That(report.Threat, Is.EqualTo(1));
            Assert.That(report.GuardReduction, Is.EqualTo(1));
            Assert.That(report.Damage, Is.EqualTo(0));
            Assert.That(report.FoodConsumed, Is.EqualTo(3));
            Assert.That(game.LastReport, Is.SameAs(report));
        }

        [Test]
        public void ThreeDaySuccessPathEndsInVictoryAndBlocksFurtherResolution()
        {
            var game = new VillageGame();

            game.ResolveDay(new VillageAssignment(2, 1, 0));
            game.ResolveDay(new VillageAssignment(1, 1, 1));
            var finalReport = game.ResolveDay(new VillageAssignment(0, 3, 0));

            Assert.That(game.State.Day, Is.EqualTo(3));
            Assert.That(game.State.Food, Is.EqualTo(0));
            Assert.That(game.State.Wall, Is.EqualTo(3));
            Assert.That(game.State.Outcome, Is.EqualTo(VillageOutcome.Victory));
            Assert.That(game.State.IsTerminal, Is.True);
            Assert.That(finalReport.Day, Is.EqualTo(3));
            Assert.That(finalReport.ResultingState, Is.EqualTo(game.State));
            Assert.That(game.CanResolve(new VillageAssignment(1, 1, 1), out var reason), Is.False);
            Assert.That(reason, Is.EqualTo("Game is already finished."));
            Assert.Throws<System.InvalidOperationException>(() => game.ResolveDay(new VillageAssignment(1, 1, 1)));
        }

        [Test]
        public void RepeatingAllForageEndsInWallCollapsedAndBlocksFurtherResolution()
        {
            var game = new VillageGame();

            game.ResolveDay(new VillageAssignment(3, 0, 0));
            var finalReport = game.ResolveDay(new VillageAssignment(3, 0, 0));

            Assert.That(game.State.Day, Is.EqualTo(2));
            Assert.That(game.State.Food, Is.EqualTo(9));
            Assert.That(game.State.Wall, Is.EqualTo(0));
            Assert.That(game.State.Outcome, Is.EqualTo(VillageOutcome.WallCollapsed));
            Assert.That(game.State.IsTerminal, Is.True);
            Assert.That(finalReport.Day, Is.EqualTo(2));
            Assert.That(finalReport.Damage, Is.EqualTo(2));
            Assert.That(finalReport.ResultingState, Is.EqualTo(game.State));
            Assert.That(game.CanResolve(new VillageAssignment(1, 1, 1), out var reason), Is.False);
            Assert.That(reason, Is.EqualTo("Game is already finished."));
            Assert.Throws<System.InvalidOperationException>(() => game.ResolveDay(new VillageAssignment(1, 1, 1)));
        }

        [Test]
        public void RepeatingAllGuardEndsInFoodDepletedAndBlocksFurtherResolution()
        {
            var game = new VillageGame();

            game.ResolveDay(new VillageAssignment(0, 3, 0));
            var finalReport = game.ResolveDay(new VillageAssignment(0, 3, 0));

            Assert.That(game.State.Day, Is.EqualTo(2));
            Assert.That(game.State.Food, Is.EqualTo(-3));
            Assert.That(game.State.Wall, Is.EqualTo(3));
            Assert.That(game.State.Outcome, Is.EqualTo(VillageOutcome.FoodDepleted));
            Assert.That(game.State.IsTerminal, Is.True);
            Assert.That(finalReport.Day, Is.EqualTo(2));
            Assert.That(finalReport.FoodConsumed, Is.EqualTo(3));
            Assert.That(finalReport.ResultingState, Is.EqualTo(game.State));
            Assert.That(game.CanResolve(new VillageAssignment(1, 1, 1), out var reason), Is.False);
            Assert.That(reason, Is.EqualTo("Game is already finished."));
            Assert.Throws<System.InvalidOperationException>(() => game.ResolveDay(new VillageAssignment(1, 1, 1)));
        }
    }
}
