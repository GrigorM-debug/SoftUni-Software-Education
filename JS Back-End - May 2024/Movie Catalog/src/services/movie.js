const {Movie} = require('../models/Movie');
const {Cast} = require('../models/Cast');

function getAllMovies() {
    const movies = Movie.find();

    return movies;
}

function getMovieById(movieId){
    const movie = Movie.findById(movieId).populate('casts').populate('creator');

    return movie;
}

function createMovie(movieData){
    const movie = Movie.create(movieData);
}

async function updateMovie(movieId, movie) {
    await Movie.findByIdAndUpdate(movieId, movie)
}

async function deleteMovie(movieId) {
    await Movie.findByIdAndDelete(movieId);
}

async function attachCast(movieId, castId){
    const movie = await getMovieById(movieId);
    const cast = await Cast.findById(castId);

    cast.movies.push(movie);
    movie.casts.push(cast);

    await cast.save();
    await movie.save();

    return movie;
}

module.exports = {getAllMovies, getMovieById, createMovie, attachCast, updateMovie, deleteMovie};