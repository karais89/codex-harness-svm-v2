using System;

namespace SafeVillage.Core
{
    public sealed class VillageGame
    {
        public VillageGame()
        {
            Restart();
        }

        public VillageState State { get; private set; }
        public DayReport LastReport { get; private set; }

        public void Restart()
        {
            State = VillageState.Initial;
            LastReport = null;
        }

        public bool CanResolve(VillageAssignment assignment, out string reason)
        {
            if (State.IsTerminal)
            {
                reason = "Game is already finished.";
                return false;
            }

            if (!assignment.IsValidFor(State.Villagers))
            {
                reason = $"Assign exactly {State.Villagers} villagers.";
                return false;
            }

            reason = string.Empty;
            return true;
        }

        public DayReport ResolveDay(VillageAssignment assignment)
        {
            if (!CanResolve(assignment, out var reason))
            {
                throw new InvalidOperationException(reason);
            }

            var current = State;
            var foodGained = assignment.Forage * 2;
            var repairedWall = Math.Min(assignment.Repair, current.MaxWall - current.Wall);
            var threat = current.Day;
            var guardReduction = Math.Min(threat, assignment.Guard);
            var damage = Math.Max(0, threat - guardReduction);
            var foodConsumed = current.Villagers;
            var nextFood = current.Food + foodGained - foodConsumed;
            var nextWall = current.Wall + repairedWall - damage;
            var outcome = ResolveOutcome(current.Day, nextFood, nextWall);
            var nextDay = outcome == VillageOutcome.InProgress ? current.Day + 1 : current.Day;

            State = new VillageState(
                day: nextDay,
                food: nextFood,
                wall: nextWall,
                maxWall: current.MaxWall,
                villagers: current.Villagers,
                outcome: outcome);

            LastReport = new DayReport(
                current.Day,
                assignment,
                foodGained,
                repairedWall,
                threat,
                guardReduction,
                damage,
                foodConsumed,
                State);

            return LastReport;
        }

        private static VillageOutcome ResolveOutcome(int day, int food, int wall)
        {
            if (wall <= 0)
            {
                return VillageOutcome.WallCollapsed;
            }

            if (food < 0)
            {
                return VillageOutcome.FoodDepleted;
            }

            return day >= 3 ? VillageOutcome.Victory : VillageOutcome.InProgress;
        }
    }
}
