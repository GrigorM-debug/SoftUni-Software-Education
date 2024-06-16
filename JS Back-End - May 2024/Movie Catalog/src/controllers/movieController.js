const { getAllCast } = require("../services/cast");
const { createMovie, getMovieById, attachCast, updateMovie} = require("../services/movie")

module.exports = {
    createGet: (req, res) =>{
        res.render('create')
    },
    createPost: async (req, res) =>{
        const errors = {
            title: !req.body.title,
            genre: !req.body.genre,
            director: !req.body.director,
            year: !req.body.year,
            imageURL: !req.body.imageURL,
            rating: !req.body.rating,
            description: !req.body.description
        };
        
        if(Object.values(errors).includes(true)){
            res.render('create', {movie: req.body, errors})
            return;
        }

        const createrId = res.locals.user._id;

        const movie = {
            title: req.body.title,
            genre: req.body.genre,
            director: req.body.director,
            year: req.body.year,
            imageURL: req.body.imageURL,
            rating: req.body.rating,
            description: req.body.description,
            creator: createrId
        }

        const result = await createMovie(movie);

        res.redirect('/')
        // res.redirect('/details/' + result._id);
    },
    attachCastGet: async (req, res) =>{
        const movieId = req.params._id;
        const movie = await getMovieById(movieId).lean();
        const casts = await getAllCast().lean();

        // Filter out the casts that are already attached to the movie
        const castsFiltered = casts.filter(cast => !cast.movies.some(m => m.toString() === movieId));

        if(!movie){
            res.render('404');
            return;
        }

        res.render('cast-attach', {movie, casts: castsFiltered})
    },
    attachCastPost: async (req, res) =>{
        const movieId = req.params._id;
        const castId = req.body.cast;

        await attachCast(movieId, castId);

        res.redirect(`/cast-attach/${movieId}`);
    },
    editGet: async (req, res) => {
        const movie = await getMovieById(req.params._id).lean();

        if(!movie) {
            return res.status(404).send('Movie not found');
        }

        const isCreator = movie.creator._id.toString() == req.user._id;

        if(!isCreator){
            res.redirect('/login');
            return;
        }


        res.render('edit', {movie});
    },
    editPost: async (req, res) => {
        const movieId = req.params._id;

        const errors = {
            title: !req.body.title,
            genre: !req.body.genre,
            director: !req.body.director,
            year: !req.body.year,
            imageURL: !req.body.imageURL,
            rating: !req.body.rating,
            description: !req.body.description
        };
        
        if(Object.values(errors).includes(true)){
            res.render('edit', {movie: req.body, errors})
            return;
        }

        const createrId = res.locals.user._id;

        const movie = {
            title: req.body.title,
            genre: req.body.genre,
            director: req.body.director,
            year: req.body.year,
            imageURL: req.body.imageURL,
            rating: req.body.rating,
            description: req.body.description,
            creator: createrId
        }

        const result = await updateMovie(movieId, movie);

        res.redirect('/')
        // res.redirect('/details/' + result._id);
    }
}