import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserModel } from '../models/UserModel';
import {environment} from "../../environments/environment";


@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  private urlBase = `${environment.baseUrl}Users`;

  constructor(private _http : HttpClient) {}


  getAllUsers(){
    return this._http.get<UserModel[]>(this.urlBase);
    
  }

  saveUser(user:UserModel) {

    if(user.id > 0)
      return this.updateUser(user);

    return this.saveNewUser(user);
  }

  removeUser(userId:number) {
    return this._http.delete(`${this.urlBase}/${userId}`);
  }

  private saveNewUser(user:UserModel) {
    return this._http.post(`${this.urlBase}/`,user)
    
    ;
  } 

  private updateUser(user:UserModel){
    return this._http.put(`${this.urlBase}/${user.id}`,user);
  }
  

}
