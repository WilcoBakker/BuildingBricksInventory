using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingBricksInventory.Data
{
    public class LegoSetBricks
    {
        public int SetId { get; set; }
        public int BrickId { get; set; }
        public uint Amount { get; set; }

        public LegoSet Set { get; set; }
        public Brick Brick { get; set; }
    }
}
