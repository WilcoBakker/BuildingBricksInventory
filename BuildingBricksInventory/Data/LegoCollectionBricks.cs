
namespace BuildingBricksInventory.Data
{
    public class LegoCollectionBricks
    {
        public int BrickId { get; set; }
        public uint Amount { get; set; }

        public Brick Brick { get; set; }
    }
}
