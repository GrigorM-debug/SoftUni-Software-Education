const { getAllMovies, getMovieById } = require("../services/movie")

module.exports = {
    homeController: async (req, res) =>{
        const movies = await getAllMovies();

        res.render('home', {movies})
    },
    detailsController: async (req, res) => {
        const movieId = req.params.id;
        const movie = await getMovieById(movieId)

        if(!movie){
            res.render('404');
            return;
        }
        
        movie.ratingStars = '★'.repeat(movie.rating);

        res.render('details', {movie});
    },
    search: async (req, res) => {
        //TODO: do the search
        res.render('search');
    }
}