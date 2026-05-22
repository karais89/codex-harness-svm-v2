namespace SafeVillage.Core
{
    public readonly struct VillageState
    {
        public VillageState(int day, int food, int wall, int maxWall, int villagers, VillageOutcome outcome)
        {
            Day = day;
            Food = food;
            Wall = wall;
            MaxWall = maxWall;
            Villagers = villagers;
            Outcome = outcome;
        }

        public int Day { get; }
        public int Food { get; }
        public int Wall { get; }
        public int MaxWall { get; }
        public int Villagers { get; }
        public VillageOutcome Outcome { get; }
        public bool IsTerminal => Outcome != VillageOutcome.InProgress;

        public static VillageState Initial => new VillageState(
            day: 1,
            food: 3,
            wall: 3,
            maxWall: 5,
            villagers: 3,
            outcome: VillageOutcome.InProgress);
    }
}
