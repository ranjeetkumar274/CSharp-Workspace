import { Component } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent {
  users : User[] = [];

  constructor(private dataService: DataService){
    this.users = this.dataService.getUsers();
  }
}
