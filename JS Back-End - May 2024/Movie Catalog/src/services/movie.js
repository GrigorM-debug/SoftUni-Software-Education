const {Movie} = require('../models/Movie');
const {Cast} = require('../models/Cast');

function getAllMovies() {
    const movies = Movie.find();

    return movies;
}

function getMovieById(movieId){
    const movie = Movie.findById(movieId).populate('casts');

    return movie;
}

function createMovie(movieData){
    const movie = Movie.create(movieData);
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

module.exports = {getAllMovies, getMovieById, createMovie, attachCast}