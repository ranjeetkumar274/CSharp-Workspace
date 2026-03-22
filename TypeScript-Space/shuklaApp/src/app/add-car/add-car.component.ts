import { Component, OnInit } from '@angular/core';
import { CarService } from '../services/car.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from '../models/car.model';

@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css']
})
export class AddCarComponent implements OnInit{

  carr: Car = {
    id: 0,
    brand: '',
    model: '',
    year: ''
  }

  objid? : number;
  isEdit: boolean = false;

  constructor(public ser: CarService, public rt : Router, public ar: ActivatedRoute){}

  ngOnInit(): void {
      this.ar.params.subscribe(
        res => {this.objid = +res['id']
        if(this.objid){
          this.isEdit = true
        }
        this.ser.getCarById(this.objid).subscribe(
          data => {this.carr = data}
        )
        }
      )
  }

  addCar(){
    if(this.isEdit){
      this.ser.updateCarById(this.carr.id, this.carr).subscribe(
        () => {this.rt.navigate([`/viewCars`])}
      )
    }else{
      this.ser.addCar(this.carr).subscribe(
      () => this.rt.navigate([`/viewCars`])
    )
    }

  }

}
