import { Component, OnInit } from '@angular/core';
import { CarService } from '../services/car.service';
import { Router } from '@angular/router';
import { Car } from 'src/app/models/car.model';

@Component({
  selector: 'app-list-car',
  templateUrl: './list-car.component.html',
  styleUrls: ['./list-car.component.css']
})
export class ListCarComponent implements OnInit{

  cars: Car[] = [];

  constructor(public ser: CarService, public rt: Router){}

  ngOnInit(): void {
      this.loadCars();
  }

  loadCars(){
    this.ser.getCars().subscribe(
      res => {this.cars = res}
    );
  }

  confirmDelete(id: number){
    this.rt.navigate([`/confirmDelete`,id]);
  }

  updateCar(id: number){
    this.rt.navigate([`/updateCar`,id]);
  }

}
