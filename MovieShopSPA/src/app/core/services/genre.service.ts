import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GenreModel } from 'src/app/shared/models/genremodel';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GenreService {
  // private readonly HttpClient _http;
  constructor(private http: HttpClient) { }
  // https://localhost:44331/api/Genres/Genres

  // many methods that will be used by components

  // HomeComponent will call this method
  getAllGenres(): Observable<GenreModel[]>
  {
    // call our API, using HttpClient(XMLHttpRequest) to make GET request
    // HttpClient class comes from HttpClientModule (Angluar Team created for us)
    // import HttpClientModule inside Module

    return this.http.get<GenreModel[]>('https://localhost:44331/api/Genres/Genres');
  }
}
