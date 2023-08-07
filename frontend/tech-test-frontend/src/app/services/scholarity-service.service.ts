import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Scholarity } from '../models/Scholarity';

@Injectable({
  providedIn: 'root'
})
export class ScholarityService {

  private urlBase = "https://localhost:7187/api/Scholarities";

  constructor(private _http : HttpClient) {}


  getAllScholarities(){
    return this._http.get<Scholarity[]>(this.urlBase);
    
  }
  
}
