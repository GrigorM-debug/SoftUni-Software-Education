const { isUser } = require("../middlewares/guards");
const { getAllCast } = require("../services/cast");
const {parseError} = require("../../utils/errorParser");
const { createMovie, getMovieById, attachCast, updateMovie, deleteMovie} = require("../services/movie")
const {Router} = require('express');
const { validationResult} = require("express-validator");
const {movieValidation} = require("../../validations/movieValidation");
const movieRouter = Router();

movieRouter.get('/create', isUser(), (req, res) =>{
    res.render('create')
});

movieRouter.post('/create', 
    isUser(), 
    movieValidation,
    async (req, res) => {
    

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

    try{
        const validation = validationResult(req);

        if(!validation.isEmpty()){
            throw validation.errors;
        }

        const result = await createMovie(movie);

        res.redirect('/')
    } catch(err){
        res.render('create', {movie: req.body, errors: parseError(err).errors});
    }
});

movieRouter.get('/edit/:_id', isUser(), async (req, res) =>{    
    try {
        console.log(req.params._id)
        const movie = await getMovieById(req.params._id).lean();
        const isCreator = movie.creator._id.toString() == req.user._id;

        if(!isCreator){
            res.redirect('/login');
            return;
        }

        res.render('edit', {movie});
    } catch(err){
        res.render('edit', {movie, errors: parseError(err).errors});
    }
});

movieRouter.post('/edit/:_id', 
    isUser(),
    movieValidation,
    async (req, res) =>{
    const movieId = req.params._id;

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

    try {
        const validation = validationResult(req);

        if(!validation.isEmpty()){
            throw validation.errors;
        }

        const result = await updateMovie(movieId, movie);
        res.redirect('/details/' + movieId);
    } catch(err){
        res.render('edit', {movie, errors: parseError(err).errors});
    }
});

movieRouter.get('/delete/:_id', isUser(), async (req, res) =>{

    try{
        const movie = await getMovieById(req.params._id).lean();

        const isCreator = movie.creator._id.toString() == req.user._id;

        if(!isCreator){
            res.redirect('/login');
            return;
        }

        res.render('delete', {movie});
    } catch(err){
        res.redirect('/404');
    }
});

movieRouter.post('/delete/:_id', isUser(), async (req, res) =>{
    const movieId = req.params._id;

    await deleteMovie(movieId);

    res.redirect('/');
});

movieRouter.get('/cast-attach/:_id', isUser(), async (req, res) =>{
    const movieId = req.params._id;
    const casts = await getAllCast().lean();
    const castsFiltered = casts.filter(cast => !cast.movies.some(m => m.toString() === movieId));   

    try {
        const movie = await getMovieById(movieId).lean();
        res.render('cast-attach', {movie, casts: castsFiltered})
    } catch (err){
        res.redirect('/404');
        return;
    }
});

movieRouter.post('/cast-attach/:_id', isUser(), async (req, res) =>{
    const movieId = req.params._id;
    const castId = req.body.cast;

    await attachCast(movieId, castId);
    res.redirect(`/details/${movieId}`);
});

module.exports = { movieRouter };