namespace DarkSpace.UniverseObjects
{
    class SpaceShip
    {
        // Informatic
        public string ShipName { get; set; } = Local.strDefaultShipName;

        // Physic
        public int Health { get; set; } = 0;
        public int MaxHealth { get; set; } = 0;

        public int Shield { get; set; } = 0;
        public int MaxShield { get; set; } = 0;

        public bool IsLive { get; set; } = true;
        public bool ShieldActive { get; set; } = true;

        public float Speed { get; set; } = 0f;

        // Economic
        public bool Wanted { get; set; } = false;

        //TODO: Move to player...
        //public int penalty;
    }
}
