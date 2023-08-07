import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Scholarity } from 'src/app/models/Scholarity';
import { UserModel } from 'src/app/models/UserModel';
import { ScholarityService } from 'src/app/services/scholarity-service.service';
import { UserServiceService } from 'src/app/services/user-service.service';

import {environment} from "../../../environments/environment"


@Component({
  selector: 'user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent {

  baseUrl = environment.baseUrl;
  @Output("onEditRegister") onEditRegister: EventEmitter<UserModel|null> = new EventEmitter();
  title = 'Novo cadastro';
  errors:string[] = [];
  fileName = "";
  fileType = "";
  fileBase64 = "";
  scholarities: Scholarity[] = [];
  uploadFile: File | null = null;
  hasUser: boolean = true;
  @Input('user') user!: UserModel;

  

  constructor(private _scholarityService: ScholarityService,
    private _userService: UserServiceService
    ) {
    this.user = this.init();
    this.loadScholarities();
    if(this.user.id>0)
    this.title = this.user.name;
  }
  init() {
    return { birthDate: '', name: '', id: 1, lastName: '', email: '', schoolHistoryId: 2, scholarityId: 3 };
  }

  goBackToList(){
    this.onEditRegister.emit(null);

  }
  handleUpload(event: any) {


    const file = event.target.files[0];    
    const { name, type, size } = file;
    const sizeLimit =  (size / (1024*1024)).toFixed(2)
    if(parseFloat(sizeLimit)> 2){
      alert('Tamanho do arquivo superior a 2 MB');
      return;
    }
    this.fileName = name;
    this.fileType = type;
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      let base64 = reader.result as string;
      if (base64) {
        this.fileBase64 = base64.split(',')[1];
      }

    };
  }

  

  saveRegister(event: any) {
    this.errors = [];
    event.preventDefault();
    const currentDate = new Date();
    const [y, m, d] = this.user.birthDate.split("-").map(v => parseInt(v));
    const birthDate = new Date(y, m - 1, d);

    //validar
    const errors = [];

    if(!this.user.name){
      errors.push('Informe o nome');
    }

    if(!this.validateEmail(this.user.email)){
      errors.push('E-mail inválido');
    }

    if((isNaN(birthDate.getMinutes())))
      errors.push('Data de nascimento inválida');
    else if(birthDate > currentDate){
      errors.push('Data de nascimento não pode ser maior que hoje.');
    }

    
    if(!this.user.scholarityId)
    errors.push('Informe uma escolaridade');

    if(this.fileName){
      const validDocs = ["doc", "docx","pdf"];
      const extension = this.fileName.split(".").pop()!;
      if(!validDocs.includes(extension)){
        errors.push('Informe apenas arquivos do tipo world ou pdf para o upload de histório escolar');
      }

    }


    this.errors = errors;

    if(!errors.length) {

      if( this.fileBase64) {
        this.user.schoolHistoryFile = this.fileBase64;
        this.user.schoolHistoryFormat = this.fileType;
        this.user.schoolHistoryName = this.fileName;
      }

      this._userService.saveUser(this.user)
        .subscribe({
          next: data => {
          
            console.log('oi')
            alert('Sucesso ao salvar registro')
            this.onEditRegister.emit(null);
          },
          error: result=> {
             const errors = [...result.error]
              if(errors && errors.length) {
                  const msg =  errors.map(err=>`${err}\n`)
                  alert(msg)
              }
          }
        });
    }

  }

  validateEmail(email:string):boolean {
    var regex = /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/;
    return regex.test(email);
  }


  loadScholarities() {
    this._scholarityService.getAllScholarities()
      .subscribe(response => {
        this.scholarities = response;
      })
  }
}
