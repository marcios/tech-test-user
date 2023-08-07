import { Component, EventEmitter, Output } from '@angular/core';
import { UserModel } from 'src/app/models/UserModel';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'user-list',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent {

  @Output("onEditRegister") onEditRegister: EventEmitter<UserModel | null> = new EventEmitter();
  users: UserModel[] = [];
  constructor(private _userService: UserServiceService) {

    this.loadUsers();
  }

  loadUsers() {
    this._userService.getAllUsers()
      .subscribe(response => {
        this.users = response;
        console.log(this.users);
      });
  }


  editRegister(user: UserModel) {
    this.onEditRegister.emit(user);
  }

  openNewRegister() {
    const newRegister = {
      birthDate: '',
      name: '',
      id: 0,
      lastName: '',
      email: '',
      schoolHistoryId: 0,
      scholarityId: 0
    };
    this.onEditRegister.emit(newRegister);
  }

  confirmRemoveUser(user: UserModel): void {
    const result = confirm(`Deseja realmente excluir o usuário  ${user.name}?`)
    if (result) {
      this._userService.removeUser(user.id)
        .subscribe({
          next: (data) => {
            alert('Sucesso na operação');
            this.loadUsers();
          },
          error: (error: any) => {
            const [errors] = [error.error];
            const msg = errors.map((err: string) => `${err}\n`);
            alert(msg);
          }
        })
    }
  }
}
