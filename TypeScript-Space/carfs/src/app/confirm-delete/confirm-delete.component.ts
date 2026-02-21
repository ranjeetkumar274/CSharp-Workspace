import { Component, OnInit } from '@angular/core';
import { CarService } from '../services/car.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from '../models/car.model';

@Component({
  selector: 'app-confirm-delete',
  templateUrl: './confirm-delete.component.html',
  styleUrls: ['./confirm-delete.component.css']
})
export class ConfirmDeleteComponent implements OnInit{

  obj: Car = {
    id: 0,
    model: '',
    carNumber: '',
    serviceDate: ''
  }

  objid:number=0;

  constructor(public ser: CarService, public rt: Router, public ar: ActivatedRoute){}

  ngOnInit(){
      this.ar.params.subscribe(
        res => {
        this.objid =  +res['id'];
        this.ser.getCarById(this.objid).subscribe(
          data => {
            this.obj = data;
        }
        )
        }
      );
  }

  finaldeleteCar(id:number){
    this.ser.deleteCar(id).subscribe(

      () => {this.rt.navigate([`/viewCars`])}
    );
  }


  cancel(){
    this.rt.navigate([`/viewCars`]);
  }
}
