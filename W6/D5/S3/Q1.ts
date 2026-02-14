import { Injectable } from '@angular/core';
import { Product } from '../model/product.model';
import{HttpClient}from'@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
   public baseUrl='https://ide-cecbbcfdb342769067ebdcbdfcddcfbone.premiumproject.examly.io/proxy/3001/';
  constructor(public ser:HttpClient) { }

getAllProducts(){
  return this.ser.get<Product[]>(this.baseUrl);
}

addProduct(obj:Product){
  return this.ser.post<Product>(this.baseUrl,obj);
}

getProductById(id:number)
{
  return this.ser.get<Product>(`${this.baseUrl}/${id}`);
}

deleteProductById(id:number)
{
  return this.ser.delete<Product>(`${this.baseUrl}/${id}`);
}

}





import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ProductListComponent} from './product-list/product-list.component';
import { AddProductComponent } from './add-product/add-product.component';
import { ViewProductComponent } from './view-product/view-product.component';
import { DeleteProductComponent } from './delete-product/delete-product.component';

// @Component({
//   selector: 'selector-name',
//   templateUrl: 'name.component.html'
// })

// export class NameComponent implements OnInit {
//   constructor() { }

//   ngOnInit() { }
// }

const routes: Routes = [
  {path:'products',component:ProductListComponent},
  {path:'product/add',component:AddProductComponent},
  {path:'product/view/:id',component:ViewProductComponent},
  {path:'products/delete/:id',component:DeleteProductComponent},
  {path:'',component:ProductListComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }




import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Router } from '@angular/router';
import { Product } from '../model/product.model';
@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  product:Product={id:0,name:'',category:'',price:0,description:''}
  
  constructor(public ser:ProductService,public rt:Router) { }

  ngOnInit(): void {
  }

  addProduct(){
    this.ser.addProduct(this.product).subscribe(res=>this.rt.navigate(['/products']))
  }

}






<h2>View Product</h2>
<h3>ID: {{product?.id}}</h3>
<h3>Name:{{product?.name}}</h3>
<h3>Category:{{product?.category}}</h3>
<h3>Price: {{product?.price}}</h3>
<h3>Description:{{product?.description}}</h3>





  import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../model/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {
  productId:number;
  product:Product;


  constructor(public ser:ProductService,public ac:ActivatedRoute) { }

  ngOnInit(): void {
    this.ac.params.subscribe(p=>this.productId=+p['id'])
    this.ser.getProductById(this.productId).subscribe(res=>this.product=res)
  }

}





