import { Component } from '@angular/core';
import { UserModel } from './models/UserModel';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'tech-test-frontend';

   currentUser?:UserModel;
   isEditUser:boolean = false;

   constructor(){}

   setCurrentUser(user:UserModel){
    this.isEditUser =  user!=null;
    this.currentUser = user;
   }

}
