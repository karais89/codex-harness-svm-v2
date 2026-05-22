namespace SafeVillage.Core
{
    public sealed class VillageGame
    {
        public VillageGame()
        {
            Restart();
        }

        public VillageState State { get; private set; }

        public void Restart()
        {
            State = VillageState.Initial;
        }
    }
}
