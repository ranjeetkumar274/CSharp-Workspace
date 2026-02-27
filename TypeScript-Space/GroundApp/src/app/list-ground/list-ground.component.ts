import { Component, OnInit } from '@angular/core';
import { GroundService } from '../services/ground.service';
import { Router } from '@angular/router';
import { Ground } from '../models/ground.model';

@Component({
  selector: 'app-list-ground',
  templateUrl: './list-ground.component.html',
  styleUrls: ['./list-ground.component.css']
})
export class ListGroundComponent implements OnInit{

  grounds: Ground[] = [];

  constructor(public ser: GroundService, public rt: Router){}

  ngOnInit(): void {
      this.loadGrounds();
  }


  loadGrounds(){
    this.ser.getAllGrounds().subscribe(
      res => {this.grounds = res}
    )
  }

}
