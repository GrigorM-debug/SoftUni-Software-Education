const fs = require('fs/promises');
const {Movie} = require('../models/Movie');
const filePath = './data/moviesData.json';

async function readFile(){
    const data = await fs.readFile(filePath);
    return JSON.parse(data);
}

async function writeFile(data) {
    await fs.writeFile(filePath, JSON.stringify(data, null, 2));
}

async function getAllMovies() {
    const movies = await readFile();

    return movies.map(createMovieClass);
}

async function getMovieById(movieId){
    const movies = await readFile();

    const movie = movies.find(m => m.id === movieId);

    return movie ? createMovieClass(movie) : movie; //If we have the movie in the DB it make it to class. Otherwise it returns undefined
}

function createMovieClass(movieData){
    const movie = new Movie();

    movie.setDetails(movieData);
    
    return movie;
}

async function createMovie(movieData){
    const movies = await readFile();
    const id = movies.length > 0 ? Number(movies[movies.length - 1].id) + 1 : 1;

    const newMovie = {
        id: id.toString(),
        title: movieData.title,
        genre: movieData.genre,
        director: movieData.director,
        year: Number(movieData.year),
        imageURL: movieData.imageURL,
        rating: Number(movieData.rating),
        description: movieData.description
    }

    movies.push(newMovie);
    await writeFile(movies);
}

module.exports = {getAllMovies, getMovieById, createMovie}