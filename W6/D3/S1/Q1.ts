================================================================================
PROJECT: ANGULAR BOOK LIST (CRUD WITH DYNAMIC STYLING)
================================================================================

--- 1. MODEL INTERFACE ---
--- FILE: models/book.model.ts ---
export interface Book {
  title: string;
  completed: boolean;
}

--- 2. COMPONENT LOGIC ---
--- FILE: book-list.component.ts ---
import { Component } from '@angular/core';
import { Book } from 'models/book.model';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent {
  books: Book[] = [];
  newBookTitle: string = '';

  addBook() {
    if (this.newBookTitle.trim() !== "") {
      let b: Book = {
        title: this.newBookTitle,
        completed: false
      };
      this.books.push(b);
      this.newBookTitle = "";
    }
  }

  completeBook(book: Book) {
    book.completed = !book.completed;
  }

  deleteBook(index: number) {
    this.books.splice(index, 1);
  }
}

--- 3. COMPONENT TEMPLATE ---
--- FILE: book-list.component.html ---
<div>
  <input type="text" [(ngModel)]="newBookTitle" placeholder="Enter book title">
  <button (click)="addBook()">Add Book</button>

  <ul>
    <li *ngFor="let b of books; let i = index">
      <span [class.comp]="b.completed">{{ b.title }}</span>
      <button (click)="completeBook(b)">
        {{ b.completed ? 'Undo' : 'Completed' }}
      </button>
      <button (click)="deleteBook(i)">Delete</button>
    </li>
  </ul>
</div>

--- 4. COMPONENT STYLES ---
--- FILE: book-list.component.css ---
.comp {
  text-decoration: line-through;
  color: darkgray;
}

--- 5. MODULE CONFIGURATION ---
--- FILE: app.module.ts ---
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookListComponent } from './book-list/book-list.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    BookListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
