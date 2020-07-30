import { LegoBrick } from "./legoBrick";
import { LegoSet } from './legoSet'

export interface LegoSetBricks {
  brickId: number;
  setId: number;
  amount: number;
  
  brick: LegoBrick;
  set: LegoSet;
}