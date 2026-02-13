================================================================================
PROJECT: ANGULAR RECIPE MANAGER
================================================================================

--- FILE: recipe-list.component.ts ---
import { Component, OnInit } from '@angular/core';

// Note: Ensure you have a Recipe interface defined as used in the array
export interface Recipe {
  id: number;
  name: string;
  type: string;
  ingredients: string[];
  instructions: string;
}

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css']
})
export class RecipeListComponent implements OnInit {
  recipes: Recipe[] = [
    {
      id: 1,
      name: 'Pancakes',
      type: 'breakfast',
      ingredients: ['Flour', 'Milk', 'Eggs', 'Butter'],
      instructions: 'Mix flour, milk, and eggs. Cook in a pan with butter.'
    }
  ];

  selectedRecipe: Recipe | null = null;

  constructor() { }

  ngOnInit(): void {
  }

  showDetails(recipe: Recipe) {
    this.selectedRecipe = recipe;
  }

  hideDetails() {
    this.selectedRecipe = null;
  }

  deleteRecipe(recipe: Recipe) {
    this.recipes = this.recipes.filter(r => r.id !== recipe.id);
    if (this.selectedRecipe?.id === recipe.id) {
      this.hideDetails();
    }
  }
}

--- FILE: recipe-list.component.html ---
<div>
  <h1 class="heading">Recipe Manager</h1>
  
  <div class="recipe-list" *ngFor="let r of recipes">
    <ul>
      <li class="recipe">
        <h3>{{ r.name }}</h3>
        <p>{{ r.type }}</p>
        <p>{{ r.ingredients.join(", ") }}</p>
        <button (click)="showDetails(r)">View Details</button>
      </li>
    </ul>
  </div>

  <div class="recipe-details-container" *ngIf="selectedRecipe != null">
    <h2>Recipe Details</h2>
    <h3>{{ selectedRecipe.name }}</h3>
    <p>{{ selectedRecipe.type }}</p>
    <p>{{ selectedRecipe.ingredients.join(", ") }}</p>
    <p>{{ selectedRecipe.instructions }}</p>
    
    <button (click)="hideDetails()">Hide Details</button>
    <button (click)="deleteRecipe(selectedRecipe)">Delete</button>
  </div>
</div>
