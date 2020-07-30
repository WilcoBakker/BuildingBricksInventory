using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBricksInventory.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuildingBricksInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private BBIContext _context;

        public CollectionController(BBIContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ActionResult GetCollection()
        {
            var collectionBricks = _context.LegoCollectionBricks.Include(x => x.Brick).ToArray();
            var collectionSets = _context.LegoCollectionSets.Include(x => x.Set).ToArray();
            var (buildableSets, unbuildableSets) = DetermineLegoSetBuildability();

            var result = new
            {
                Bricks = collectionBricks,
                Sets = collectionSets,
                BuildableSets = buildableSets,
                UnbuildableSets = unbuildableSets,
            };

            return new OkObjectResult(result);
        }

        private (IEnumerable<LegoSet> BuildableSets, IEnumerable<LegoSet> UnbuildableSets) DetermineLegoSetBuildability()
        {
            var buildableLegoSets = new List<LegoSet>();
            var unbuildableLegoSets = new List<LegoSet>();

            var collectionSets = _context.LegoCollectionSets.Include(x => x.Set).Include(x => x.Set).ThenInclude(x => x.SetBricks).ThenInclude(x => x.Brick).ToList();
            var legoSets = _context.LegoSets.Include(x => x.SetBricks).ToList();

            // A list posing as the total sum of all the bricks in the collection.
            List<BrickCount> bricksInCollection = new List<BrickCount>();

            foreach (var legoSet in legoSets)
            {
                // Check if we already own the set at hand, if so, we can definitely build it.
                if (collectionSets.Any(x => x.SetId == legoSet.Id && x.Amount > 0))
                {
                    // Get rid of looping references as the client doesn't need
                    // the details for the overview page.
                    legoSet.SetBricks = null;
                    buildableLegoSets.Add(legoSet);
                    continue;
                }

                // If we haven't made a total sum yet, lets do that
                // as we don't have this set in our collection.
                // Of course it could occur someone owns all the sets
                // while that would be unlikely of course
                // so it questionable to do this conditionally
                // as it is quite certain it will happen.
                // At least I have thought about it.
                if (bricksInCollection.Count == 0)
                {
                    var collectionBricks = _context.LegoCollectionBricks.Include(x => x.Brick);
                    foreach (var collectionBrick in collectionBricks)
                    {
                        // We can just add these directly to the list as there are no double entries at this point.
                        bricksInCollection.Add(new BrickCount
                        {
                            Brick = collectionBrick.Brick,
                            Amount = collectionBrick.Amount,
                        });
                    }
                    foreach (var collectionSet in collectionSets)
                    {
                        foreach (var setBricks in collectionSet.Set.SetBricks)
                        {
                            var brickInCollection = bricksInCollection.SingleOrDefault(x => x.Brick.Id == setBricks.BrickId);
                            if (brickInCollection != null)
                            {
                                brickInCollection.Amount += setBricks.Amount;
                                continue;
                            }
                            bricksInCollection.Add(new BrickCount
                            {
                                Brick = setBricks.Brick,
                                Amount = setBricks.Amount,
                            });
                        }
                    }
                }

                // let's keep a check alive for the next part
                var buildable = true;
                
                // So we haven't got the collection, bummer!
                // Let's see if we got the bricks necessary though.
                foreach (var setBricks in legoSet.SetBricks)
                {
                    var brickInCollection = bricksInCollection.SingleOrDefault(x => x.Brick.Id == setBricks.BrickId);
                    if (brickInCollection == null || brickInCollection.Amount < setBricks.Amount)
                    {
                        // Remove details to get rid of looping references
                        legoSet.SetBricks = null;
                        // So we don't meet the x amount required of this particular brick!
                        // So then it is hopeless, I am afraid...
                        // I deem it unbuildable!
                        unbuildableLegoSets.Add(legoSet);
                        buildable = false;
                        break;
                    }
                }

                if (buildable)
                {
                    // Remove details to get rid of looping references
                    legoSet.SetBricks = null;
                    buildableLegoSets.Add(legoSet);
                }
            }

            return (buildableLegoSets, unbuildableLegoSets);
        }
    }
}