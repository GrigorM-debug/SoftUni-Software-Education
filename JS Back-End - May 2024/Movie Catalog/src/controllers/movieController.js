const { getAllCast } = require("../services/cast");
const { createMovie, getMovieById, attachCast} = require("../services/movie")

module.exports = {
    createGet: async (req, res) =>{
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

        const result = await createMovie(req.body)

        res.redirect('/')
        // res.redirect('/details/' + result._id);
    },
    attachCastGet: async (req, res) =>{
        const movieId = req.params._id;
        const movie = await getMovieById(movieId).lean();
        const casts = await getAllCast().lean();

        // Filter out the casts that are already attached to the movie
        const castsFiltered = casts.filter(cast => !cast.movies.some(m => m.toString() === movieId));

        console.log(castsFiltered)

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
    }
}