import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Scholarity } from '../models/Scholarity';

import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ScholarityService {

  constructor(private _http : HttpClient) {}
  getAllScholarities(){
    return this._http.get<Scholarity[]>(`${environment.baseUrl}scholarities`);
    
  }
  
}
