using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingBricksInventory.Data
{
    public class LegoSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public List<LegoSetBricks> SetBricks { get; set; }
    }
}
