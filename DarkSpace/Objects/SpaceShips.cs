using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSpace.Objects
{
    public class SpaceShips
    {
        // Informatic
        public string ShipName = null;

        // Psychic
        public int Health = 0;
        public int maxHealth = 0;

        public int Shield = 0;
        public int maxShield = 0;

        public bool isLive = true;
        public bool shieldActive = true;

        public float Speed = 0f;

        // Economic
        public bool Wanted = false;

        //TODO: Move to player...
        //public int penalty;
    }
}
