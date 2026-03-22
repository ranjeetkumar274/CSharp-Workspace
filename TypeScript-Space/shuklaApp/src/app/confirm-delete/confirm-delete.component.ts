import { Component, OnInit } from '@angular/core';
import { Car } from '../models/car.model';
import { CarService } from '../services/car.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-confirm-delete',
  templateUrl: './confirm-delete.component.html',
  styleUrls: ['./confirm-delete.component.css']
})
export class ConfirmDeleteComponent implements OnInit{

  carr: Car = {
    id: 0,
    brand: '',
    model: '',
    year: ''
  }

  objid? : number;

  constructor(public ser: CarService, public rt: Router, public ar: ActivatedRoute){}

  ngOnInit(): void {
      this.ar.params.subscribe(
        res => {this.objid = +res['id']
          console.log(this.objid);
        this.ser.getCarById(this.objid).subscribe(
          data => {this.carr = data}
        )
        })
      }

    delete(id: number){
      this.ser.deleteById(id).subscribe(
        () => this.rt.navigate([`/viewCars`])
      )
  }

  cancelDelete(){
    this.rt.navigate([`/viewCars`])
  }

  }



