import { Component, OnInit } from '@angular/core';
import { GroundService } from '../services/ground.service';
import { Router } from '@angular/router';
import { Ground } from '../models/ground.model';

@Component({
  selector: 'app-add-ground',
  templateUrl: './add-ground.component.html',
  styleUrls: ['./add-ground.component.css']
})
export class AddGroundComponent implements OnInit{

  g: Ground = {
    id: 0,
    groundName: '',
    location: '',
    capacity: 0,
    status: '',
    establishedOn: '',
    managerName: ''
  }

  formSubmitted: boolean = false;

  constructor(public ser: GroundService, public rt: Router){}

  ngOnInit(): void {
      
  }

  addGround(){
    this.formSubmitted = true;
    this.ser.createGround(this.g).subscribe(
      () => {this.rt.navigate([`/viewGrounds`])}
    )
  }
}
