namespace SafeVillage.Core
{
    public sealed class DayReport
    {
        public DayReport(
            int day,
            VillageAssignment assignment,
            int foodGained,
            int wallRepaired,
            int threat,
            int guardReduction,
            int damage,
            int foodConsumed,
            VillageState resultingState)
        {
            Day = day;
            Assignment = assignment;
            FoodGained = foodGained;
            WallRepaired = wallRepaired;
            Threat = threat;
            GuardReduction = guardReduction;
            Damage = damage;
            FoodConsumed = foodConsumed;
            ResultingState = resultingState;
            Summary =
                $"Day {day}: Food +{foodGained}, Wall +{wallRepaired}, " +
                $"Threat {threat}, Guard -{guardReduction}, " +
                $"Wall damage {damage}, Food -{foodConsumed}.";
        }

        public int Day { get; }
        public VillageAssignment Assignment { get; }
        public int FoodGained { get; }
        public int WallRepaired { get; }
        public int Threat { get; }
        public int GuardReduction { get; }
        public int Damage { get; }
        public int FoodConsumed { get; }
        public VillageState ResultingState { get; }
        public string Summary { get; }
    }
}
