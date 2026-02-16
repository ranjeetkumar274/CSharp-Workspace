import { Component, OnInit } from '@angular/core';

interface Travel{
  place: string;
  country: string;
  priority: number;
  visited: boolean;
}

@Component({
  selector: 'app-travel-bucketlist',
  templateUrl: './travel-bucketlist.component.html',
  styleUrls: ['./travel-bucketlist.component.css']
})
export class TravelBucketlistComponent implements OnInit{

  ngOnInit(): void {
      
  }

  constructor(){}

  travels: Travel[] = [];
  currPlace: string = '';
  currCountry: string = '';
  currPriority: number = 3;

  addTravel(){
    if(this.currPlace.trim() !== '' && this.currCountry.trim() !== '' && this.currPriority >= 3 && this.currPriority <= 10){
      this.travels.push({
        place: this.currPlace,
        country: this.currCountry,
        priority: this.currPriority,
        visited: false
      });

      this.currPlace = '';
      this.currCountry = '';
      this.currPriority = 3;
    }
  }

  toggleVisited(index: number){
    this.travels[index].visited = !this.travels[index].visited;
  }

  removeTravel(index: number){
    this.travels.splice(index,1);
  }
}
