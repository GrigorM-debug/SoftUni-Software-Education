const {Router} = require('express');
const { isUser } = require('../middlewares/guards');
const {body, validationResult} = require('express-validator');
const {parseError} = require('../../utils/errorParser');
const {create, updateRecipe, getById, deleteRecipe, recommendRecipe} = require('../services/recipe')


const recipeRouter = Router();

recipeRouter.get('/create', isUser(), (req, res) => {
    res.render('create');
});


recipeRouter.post('/create', 
    isUser(),
     body('title').trim().notEmpty().withMessage('Title is required !').isLength({min: 2}).withMessage('Title should at least 2 characters long !'),
     body('ingredients').trim().notEmpty().withMessage('Ingredients are required !').isLength({min: 10, max: 200}).withMessage('Ingredients should between 10 and 200 characters long !'),
     body('instructions').trim().notEmpty().withMessage('Instructions are required !').isLength({min: 10}).withMessage('Instructions should be at least 10 characters long !'),
     body('description').trim().notEmpty().withMessage('Description is required !').isLength({min: 10, max: 100}).withMessage('Description should between 10 and 100 characters long !'),
     body('image').trim().notEmpty().withMessage('Image URL is required !').isURL().withMessage('Invalid URL !'),
    async (req, res) => {
    
    try{
        const validation = validationResult(req);

        if(!validation.isEmpty()) {
            throw validation.errors;
        }

        const result = await create(req);

        res.redirect('/catalog');
    } catch(err) {
        res.render('create', {errors: parseError(err).errors, recipe: req.body})
    } 
});

recipeRouter.get('/edit/:_id', isUser(), async (req, res) => {
    try{
        const recipe = await getById(req.params._id).lean();

        if(recipe.owner != req.user._id) {
            res.status(403).send('Acces denied!');
        }

        res.render('edit', {recipe})

    } catch(err) {
        res.redirect('/404');
    }
});

recipeRouter.post('/edit/:_id', 
    isUser(),
    body('title').trim().notEmpty().withMessage('Title is required !').isLength({min: 2}).withMessage('Title should at least 2 characters long !'),
    body('ingredients').trim().notEmpty().withMessage('Ingredients are required !').isLength({min: 10, max: 200}).withMessage('Ingredients should between 10 and 200 characters long !'),
    body('instructions').trim().notEmpty().withMessage('Instructions are required !').isLength({min: 10}).withMessage('Instructions should be at least 10 characters long !'),
    body('description').trim().notEmpty().withMessage('Description is required !').isLength({min: 10, max: 100}).withMessage('Description should between 10 and 100 characters long !'),
    body('image').trim().notEmpty().withMessage('Image URL is required !').isURL().withMessage('Invalid URL !'),
    async (req, res) => {
    
    try {
        const validation = validationResult(req);

        if(!validation.isEmpty()) {
            throw validation.errors;
        }

        await updateRecipe(req.params._id, req.body);
        res.redirect('/details/' + req.params._id);
    } catch(err) {
        res.render('edit', {recipe: req.body, errors: parseError(err).errors})
    }
});

recipeRouter.get('/delete/:_id', isUser(), async (req, res) => {
    try{
        const recipe = await getById(req.params._id).lean();

        if(recipe.owner != req.user._id) {
            res.status(403).send('Acces denied!');
        }

        res.render('delete', {recipe})

    } catch(err) {
        res.redirect('/404');
    }
});

recipeRouter.post('/delete/:_id', isUser(), async (req, res) => {
    try {
        await deleteRecipe(req.params._id);
        res.redirect('/catalog');
    } catch(err) {
        res.redirect('/404');
    }
});

recipeRouter.get('/recommend/:_id', isUser(), async (req, res) => {
    const recipeId = req.params._id;
    const userId = req.user._id;

    try {
       await recommendRecipe(recipeId, userId);

        res.redirect('/details/' + recipeId);
    } catch(err) {
        res.redirect('/404');
    }
});

module.exports = {
    recipeRouter
}