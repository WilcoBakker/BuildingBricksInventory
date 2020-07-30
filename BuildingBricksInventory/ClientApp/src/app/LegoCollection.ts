import { LegoCollectionBricks } from "./legoCollectionBricks";
import { LegoCollectionSets } from "./LegoCollectionSets";
import { LegoSet } from "./legoSet";

export interface LegoCollection {
  bricks: LegoCollectionBricks;
  sets: LegoCollectionSets;
  buildableSets: LegoSet[];
  unbuildableSets: LegoSet[];
}