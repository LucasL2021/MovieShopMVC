import { Component, OnInit } from '@angular/core';
import { GenreService } from '../core/services/genre.service';
import { MovieService } from '../core/services/movie.service';
import { MovieCard } from '../shared/models/moviecard';
import {GenreModel} from '../shared/models/genremodel';
import {Movie} from '../shared/models/movie';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  mypageTitle = "Movie Shop SPA";
  movieCards!: MovieCard[];
  movieDetailsModel!: Movie;
  genreModels!: GenreModel[];


  constructor(private movieService: MovieService, private genreService: GenreService) { }

  ngOnInit(): void {
    // ngOnInit is one of the most important life cycle hooks method in angular
    // It is recommended to use this method to call the API and initilize any data properties
    // Will be called automatically by your angular component after calling constructor
    // only when u subscribe to the observable you get the data
    // Observable<MovieCard[]>
    // https://localhost:44331/
    this.movieService.getTopRevenueMovies().subscribe(
      m => {
        this.movieCards = m;
        // console.log('inside the ngOnInit method of Home Component/revenue');
        // console.log(this.movieCards);
      }
    );

    this.movieService.getTopRatedMovies().subscribe(
      m => {
        this.movieCards = m;
        console.log('inside the ngOnInit method of Home Component/rated');
        console.log(this.movieCards);
      }
    );
    
    this.genreService.getAllGenres().subscribe(
      g => {
        this.genreModels = g;
        console.log('inside the ngOnInit method of Home Component/genres');
        console.log(this.genreModels);
      }
    );
  }

}