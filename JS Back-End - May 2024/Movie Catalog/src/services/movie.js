const {Movie} = require('../models/Movie');

function getAllMovies() {
    const movies = Movie.find();

    return movies;
}

function getMovieById(movieId){
    const movie = Movie.findById(movieId);

    return movie;
}

function createMovie(movieData){
    const movie = Movie.create(movieData);
}

module.exports = {getAllMovies, getMovieById, createMovie}