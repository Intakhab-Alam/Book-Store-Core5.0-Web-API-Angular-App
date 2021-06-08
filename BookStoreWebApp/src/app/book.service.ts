import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  //Web API url
  private basePath = 'https://localhost:44393/api/book';

  //json-server fake api generator path angular 10 project > db > db.json
  //private basePath = 'http://localhost:3000/book';


  constructor(private _http: HttpClient) { }

  public getAllBooks(): Observable<any> {
    return this._http.get(this.basePath);
  }
  
  public addBook(book: any): Observable<any> {
    return this._http.post(this.basePath, book);
  }

  public getBookById(id: number): Observable<any> {
    return this._http.get(`${this.basePath}/${id}`);
  }

  public editBook(id: number,book: any): Observable<any> {
    return this._http.put(`${this.basePath}/${id}`, book);
  }

  public deleteBook(id: number): Observable<any> {
    return this._http.delete(`${this.basePath}/${id}`);
  }
}
