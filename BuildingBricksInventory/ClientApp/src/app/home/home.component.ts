import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { CollectionService } from '../collection.service';
import { LegoCollectionBricks } from '../legoCollectionBricks';
import { LegoCollectionSets } from '../LegoCollectionSets';
import { LegoSet } from '../legoSet';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  collectionSets: Observable<LegoCollectionSets>;
  collectionBricks: Observable<LegoCollectionBricks>;
  buildableSets: Observable<LegoSet[]>;
  unbuildableSets: Observable<LegoSet[]>;

  constructor(private collectionService: CollectionService) {
    const collection = this.collectionService.getCollection();
    this.collectionSets = collection.pipe(map(x => x.sets));
    this.collectionBricks = collection.pipe(map(x => x.bricks));
    this.buildableSets = collection.pipe(map(x => x.buildableSets));
    this.unbuildableSets = collection.pipe(map(x => x.unbuildableSets));
  }

  ngOnInit() {
  }

}
