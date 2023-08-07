import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserModel } from '../models/UserModel';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  private urlBase = "https://localhost:7187/Users";

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
    return this._http.delete(`https://localhost:7187/Users/${userId}`);
  }

  private saveNewUser(user:UserModel) {
    return this._http.post(`https://localhost:7187/Users/`,user)
    
    ;
  } 

  private updateUser(user:UserModel){
    return this._http.put(`https://localhost:7187/Users/${user.id}`,user);
  }
  

}
