import { Component, OnInit } from '@angular/core';
import { CarService } from '../services/car.service';
import { Router } from '@angular/router';
import { Car } from '../models/car.model';

@Component({
  selector: 'app-show-car',
  templateUrl: './show-car.component.html',
  styleUrls: ['./show-car.component.css']
})
export class ShowCarComponent implements OnInit{

  carss: Car[] = [];

  constructor(public ser : CarService, public rt: Router){}

  ngOnInit(): void {
      this.loadCars();
  }

  loadCars(){
    this.ser.getCars().subscribe(
      data => {this.carss = data}
    )
  }

  confirmDelete(id : number){
    this.rt.navigate([`/confirm-delete`,id])
  }

  editCar(id : number){
   this.rt.navigate([`/editCar`,id])
  }

}
