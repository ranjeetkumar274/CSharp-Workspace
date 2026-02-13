import { Injectable } from '@angular/core';
import { User } from 'src/app/models/user.model';

@Injectable({
    providedIn: 'root'
})
export class DataService{
    users : User[] = [];

    constructor(){}

    addUser(user : User){
        this.users.push(user);
    }

    getUsers(): User[]{
        return this.users;
    }
}