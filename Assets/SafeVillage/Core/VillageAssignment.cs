namespace SafeVillage.Core
{
    public readonly struct VillageAssignment
    {
        public VillageAssignment(int forage, int guard, int repair)
        {
            Forage = forage;
            Guard = guard;
            Repair = repair;
        }

        public int Forage { get; }
        public int Guard { get; }
        public int Repair { get; }
        public int Total => Forage + Guard + Repair;

        public bool IsValidFor(int villagers)
        {
            return Forage >= 0 &&
                Guard >= 0 &&
                Repair >= 0 &&
                Total == villagers;
        }
    }
}
