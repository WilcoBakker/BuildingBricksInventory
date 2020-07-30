import { LegoSetBricks } from "./legoSetBricks";

export interface LegoSet {
  id: number;
  name: string;
  imageUrl: string;
  setBricks: LegoSetBricks;
}