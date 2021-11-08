import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MovieCard } from 'src/app/shared/models/moviecard';
import { HttpClient } from '@angular/common/http';
import { Movie } from 'src/app/shared/models/movie';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class MovieService {
  // private readonly HttpClient _http;
  constructor(private http: HttpClient) { }
  // https://localhost:44331/api/Movies/toprevenue
  // https://localhost:44331/api/Movies/toprated
  // https://localhost:44331/api/Movies/2



  // many methods that will be used by components

  // HomeComponent will call this method
  getTopRevenueMovies(): Observable<MovieCard[]>
  {
    // call our API, using HttpClient(XMLHttpRequest) to make GET request
    // HttpClient class comes from HttpClientModule (Angluar Team created for us)
    // import HttpClientModule inside Module

    return this.http.get<MovieCard[]>(`${environment.apiBaseUrl}movies/toprevenue`);
  }

  getTopRatedMovies(): Observable<MovieCard[]>
  {
    return this.http.get<MovieCard[]>(`${environment.apiBaseUrl}movies/toprated`);
  }
  
  getMovieDetails(id: number = 1): Observable<Movie>
  {
    return this.http.get<Movie>(`${environment.apiBaseUrl}movies/toprated`);
  }
}
