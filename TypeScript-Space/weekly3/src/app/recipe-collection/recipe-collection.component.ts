import { Component } from '@angular/core';

interface Recipe{
  name: string;
  difficulty: number;
  tried: boolean;
}

@Component({
  selector: 'app-recipe-collection',
  templateUrl: './recipe-collection.component.html',
  styleUrls: ['./recipe-collection.component.css']
})
export class RecipeCollectionComponent {

  recipies: Recipe[] = [];

  rawName: string = '';
  rawDifficulty: number = 1;


  addRecipe(): void{
    if(this.rawName.trim() !== '' && this.rawDifficulty >= 1 && this.rawDifficulty <= 5){
      this.recipies.push({
        name: this.rawName,
        difficulty: this.rawDifficulty,
        tried: false
      });

    this.rawName = '';
    this.rawDifficulty = 1;
    }
  }

  toggleTried(index: number){
    this.recipies[index].tried = !this.recipies[index].tried;
  }

  removeRecipe(index: number){
    this.recipies.splice(index,1);
  }
  
}
