import { Component } from '@angular/core';

interface Book{
  title: string;
  rating: number;
  read: boolean;
}

@Component({
  selector: 'app-book-collection',
  templateUrl: './book-collection.component.html',
  styleUrls: ['./book-collection.component.css']
})



export class BookCollectionComponent {

  books: Book[] = [];

  rawBookTitle = '';
  rawRating = 1;

  addBook(): void{
    if(this.rawBookTitle !== '' && this.rawRating >= 1 && this.rawRating <= 5){
      const book: Book = {
        title: this.rawBookTitle,
        rating: this.rawRating,
        read: false
      };

      this.books.push(book);

      this.rawBookTitle = '';
      this.rawRating = 1;
    }
  }

  toggleRead(index: number): void{
    this.books[index].read = !this.books[index].read;
  }

  removeBook(index: number): void{
    this.books.splice(index,1);
  }
}
