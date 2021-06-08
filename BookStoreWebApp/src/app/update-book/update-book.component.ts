import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from '../book.service';

@Component({
  selector: 'app-update-book',
  templateUrl: './update-book.component.html',
  styleUrls: ['./update-book.component.scss']
})
export class UpdateBookComponent implements OnInit {

  editBookForm = this.formBuilder.group({
    title: [],
    description: []
  })

  constructor(private service: BookService,
    private activatedRoute: ActivatedRoute, 
    private formBuilder: FormBuilder,
    private router: Router) { }


  ngOnInit(): void {
    this.service.getBookById(this.activatedRoute.snapshot.params.id).subscribe(data => {
      this.editBookForm = this.formBuilder.group({
        title: [data.title],
        description: [data.description]
      });
    });
  }
  
  public updateBook() {
    this.service.editBook(this.activatedRoute.snapshot.params.id,this.editBookForm.value).subscribe(result => {
      this.editBookForm.reset();
      this.router.navigate(['books'])
    })
  }
}
