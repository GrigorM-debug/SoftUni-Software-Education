const { getAllMovies, getMovieById, getMovieByTitle, getMovieByGenre, getMovieByYear, getMovieByTitleByGenreAndYear } = require("../services/movie")

module.exports = {
    homeController: async (req, res) =>{
        const movies = await getAllMovies().lean();

        res.render('home', {movies})
    },
    detailsController: async (req, res) => {
        const movieId = req.params._id;
        const movie = await getMovieById(movieId).lean();

        if(!movie){
            res.render('404');
            return;
        }
        
        movie.ratingStars = '★'.repeat(movie.rating);

        res.render('details', {movie});
    },
    search: async (req, res) => {
        const movies = await getAllMovies().lean();
        let moviesFiltered = [];
        const movieTitle = req.query.title;
        const movieGenre = req.query.genre;
        const movieYear = Number(req.query.year);

        if(movieTitle && !movieGenre && !movieYear){
            moviesFiltered = movies.filter(m => m.title === movieTitle);

            console.log(moviesFiltered)
            // res.render('search', {movies});
        } else if (!movieTitle && movieGenre && !movieYear){
            moviesFiltered = movies.filter(m => m.genre === movieGenre);

            console.log(moviesFiltered)
            // res.render('search', {movies});
        } else if (!movieTitle && !movieGenre && movieYear){
            moviesFiltered = movies.filter(m => m.year === movieYear);

            console.log(moviesFiltered)
            // res.render('search', {movies});
        } else{
            moviesFiltered = movies.filter(m => m.title === movieTitle && m.genre === movieGenre && m.year === movieYear);

            console.log(moviesFiltered)
        }

        res.render('search', {movies: moviesFiltered});
    }
}