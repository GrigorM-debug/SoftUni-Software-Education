const {Movie} = require('../models/Movie');

async function getAllMovies() {
    const movies = Movie.find();

    return movies;
}

async function getMovieById(movieId){
    const movie = Movie.findById(movieId);

    return movie;
}


async function createMovie(movieData){
    const movie = Movie.create(movieData);
}

module.exports = {getAllMovies, getMovieById, createMovie}