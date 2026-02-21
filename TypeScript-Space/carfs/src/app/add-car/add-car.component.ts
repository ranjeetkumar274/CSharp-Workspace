import { Component, OnInit } from '@angular/core';
import { Car } from '../models/car.model';
import { CarService } from '../services/car.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css']
})
export class AddCarComponent implements OnInit{

  obj: Car = {
    id: 0,
    model: '',
    carNumber: '',
    serviceDate: ''
  }

  objid!: number;
  isEditMode: boolean = false;

  constructor(public ser: CarService, public rt: Router, public ar: ActivatedRoute){}

  ngOnInit(): void {
      this.ar.params.subscribe(res =>{
        if(res['id']){
          this.isEditMode = true;
          this.objid = +res['id'];
          this.ser.getCarById(this.objid).subscribe(
            data => {this.obj = data}
          );
        }
      }
      );
  }

  addCar(){
    if(this.isEditMode){
      this.ser.updateCar(this.objid, this.obj).subscribe(
        () => setTimeout( () => this.rt.navigate([`/showCars`]),3000)
      );
    }else{
    this.ser.addCar(this.obj).subscribe(
      () => {this.rt.navigate([`/showCars`]);}
    );
    }
  }
}
