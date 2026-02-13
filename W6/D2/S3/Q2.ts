================================================================================
PROJECT: STATIONARY MANAGEMENT SYSTEM (PARENT-CHILD COMMUNICATION)
================================================================================

--- 1. CHILD COMPONENT: PRODUCT LIST ---
--- FILE: product-list.component.ts ---
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products = [
    {
      id: 1,
      name: 'Pencil',
      description: 'A pencil is an object that you write or draw with.',
      price: 10.99,
      imageUrl: 'assets/pencil.jpg'
    },
    {
      id: 2,
      name: 'Scale',
      description: 'A scale is a set of levels or numbers which are used in a particular system of measuring things.',
      price: 19.99,
      imageUrl: 'assets/scale.jpg'
    },
    {
      id: 3,
      name: 'Eraser',
      description: 'An eraser, piece of rubber or other material used to rub out marks made by ink, pencil, or chalk.',
      price: 29.99,
      imageUrl: 'assets/eraser.jpg'
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }

  @Output() productSelected: EventEmitter<any> = new EventEmitter<any>();

  viewDetails(product: any) {
    this.productSelected.emit(product);
  }
}

--- FILE: product-list.component.html ---
<div class="product-list">
  <div *ngFor="let p of products" class="product-item">
    <h3>{{ p.name }}</h3>
    <button (click)="viewDetails(p)">View Details</button>
  </div>
</div>


--- 2. CHILD COMPONENT: PRODUCT DETAILS ---
--- FILE: product-details.component.ts ---
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  @Input() selectedProduct: any;

  constructor() { }

  ngOnInit(): void {
  }
}

--- FILE: product-details.component.html ---
<h1>Product Details</h1>
<div class="product-details-box" *ngIf="selectedProduct != null">
  <img src="{{selectedProduct.imageUrl}}" alt="{{selectedProduct.name}}">
  <p>{{selectedProduct.name}}</p>
  <p>{{selectedProduct.description}}</p>
  <p>{{selectedProduct.price | currency}}</p>
</div>


--- 3. PARENT COMPONENT: APP COMPONENT ---
--- FILE: app.component.ts ---
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angularapp';
  selectedProduct = null;

  onProductSelected(product: any) {
    this.selectedProduct = product;
  }
}

--- FILE: app.component.html ---
<h1>Stationary Management System</h1>
<div class="container">
  <div>
    <app-product-list (productSelected)="onProductSelected($event)"></app-product-list>
  </div>
  <div>
    <app-product-details [selectedProduct]="selectedProduct"></app-product-details>
  </div>
</div>
