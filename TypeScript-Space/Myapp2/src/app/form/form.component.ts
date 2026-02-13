import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { User } from 'src/app/models/user.model';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent {

  constructor(private dataService : DataService){}


  userForm = new FormGroup({
    id : new FormControl(''),
    name : new FormControl(''),
    email : new FormControl('')
  });


  onSubmit(){
    if(this.userForm){
      const newUser : User = {
        id: Number(this.userForm.value.id),
        name: this.userForm.value.name as string,
        email: this.userForm.value.email as string,
      };

      console.log(newUser);

      this.dataService.addUser(newUser);
      this.userForm.reset();
    }
  }
}
