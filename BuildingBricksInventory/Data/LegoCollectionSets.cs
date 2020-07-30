
namespace BuildingBricksInventory.Data
{
    public class LegoCollectionSets
    {
        public int SetId { get; set; }
        public uint Amount { get; set; }

        public LegoSet Set { get; set; }
    }
}
