import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Item } from '../Models/Item';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  private apiUrl = `${environment.ApiUrl}v1/item`
  constructor(private http: HttpClient) { }

  GetItem(): Observable<Item[]>{
    
    return this.http.get<Item[]>(this.apiUrl); 
  }
}
