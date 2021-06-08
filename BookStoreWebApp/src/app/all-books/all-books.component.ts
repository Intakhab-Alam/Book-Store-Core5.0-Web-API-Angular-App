import { Component, OnInit } from '@angular/core';
import { BookService } from '../book.service';

@Component({
  selector: 'app-all-books',
  templateUrl: './all-books.component.html',
  styleUrls: ['./all-books.component.scss']
})
export class AllBooksComponent implements OnInit {

  public listOfBooks: any;

  constructor(private service: BookService) { }

  ngOnInit(): void {
    this.getBooks();
  }

  private getBooks() {
    this.service.getAllBooks().subscribe(result => {
      this.listOfBooks = result;
    })
  }

  public deleteBook(id: number) {
    this.service.deleteBook(id).subscribe(result => {
      this.getBooks();
    })
  }

}
