import { Injectable } from '@angular/core';
import { HttpClient, } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LegoCollection } from './LegoCollection';

@Injectable({
  providedIn: 'root'
})
export class CollectionService {

  constructor(private http: HttpClient) { }

  public getCollection(): Observable<LegoCollection> {
    return this.http.get<LegoCollection>('/api/collection');
  }

}
