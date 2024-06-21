const {Router} = require('express');
const { isUser } = require('../middlewares/guards');
const {parseError} = require('../../util/errorParser');
const { create, getById, updateStone, deleteStone } = require('../services/stone');
const {body, validationResult} = require('express-validator');

const stoneRouter = Router();

stoneRouter.get('/create', isUser(), (req, res) => {
    res.render('create');
});

stoneRouter.post('/create', 
    isUser(),
    body('name').trim().notEmpty().withMessage('Name is required !').isLength({min: 2}).withMessage('Name must at least 2 characters long !'),
    body('category').trim().notEmpty().withMessage('Category  is required !').isLength({min: 3}).withMessage('Category must at least 3 charactars long !'),
    body('color').trim().notEmpty().withMessage('Color is required !').isLength({min: 2}).withMessage('Color must be at least 2 charactars long !'),
    body('image').trim().notEmpty().withMessage('Image is required !').isURL().withMessage('Invalid URL !'),
    body('location').trim().notEmpty().withMessage('Location is required !').isLength({min: 5, max:15}).withMessage('Location must be between 5 and 15 charactars !'),
    body('formula').trim().notEmpty().withMessage('Formula is required !').isLength({min: 3, max: 30}).withMessage('Location must be between 3 and 30 charactars !'),
    body('description').trim().notEmpty().withMessage('Description is required !').isLength({min: 10}).withMessage('Description must be at least 10 charactars long !'),
    async (req, res) => {
    
    const newStone = {
        name: req.body.name,
        category: req.body.category,
        color: req.body.color,
        image: req.body.image,
        location: req.body.location,
        formula: req.body.formula,
        description: req.body.description,
        owner: req.user._id 
    };

    try{
        const validation = validationResult(req);

        if(!validation.isEmpty()) {
            throw validation.errors;
        }

        const result = await create(newStone);

        res.redirect('/details/' + result._id);
    } catch(err) {
        res.render('create', {errors: parseError(err).errors, stone: newStone})
    } 
});

stoneRouter.get('/edit/:_id', isUser(), async (req, res) => {
    try{
        const stone = await getById(req.params._id).lean();

        if(stone.owner != req.user._id) {
             res.status(403).send('Acces denied!');
        }

        res.render('edit', {stone})

    } catch(err) {
        res.redirect('/404');
    }
}); 

stoneRouter.post('/edit/:_id', isUser(), 
body('name').trim().notEmpty().withMessage('Name is required !').isLength({min: 2}).withMessage('Name must at least 2 characters long !'),
body('category').trim().notEmpty().withMessage('Category  is required !').isLength({min: 3}).withMessage('Category must at least 3 charactars long !'),
body('color').trim().notEmpty().withMessage('Color is required !').isLength({min: 2}).withMessage('Color must be at least 2 charactars long !'),
body('image').trim().notEmpty().withMessage('Image is required !').isURL().withMessage('Invalid URL !'),
body('location').trim().notEmpty().withMessage('Location is required !').isLength({min: 5, max:15}).withMessage('Location must be between 5 and 15 charactars !'),
body('formula').trim().notEmpty().withMessage('Formula is required !').isLength({min: 3, max: 30}).withMessage('Location must be between 3 and 30 charactars !'),
body('description').trim().notEmpty().withMessage('Description is required !').isLength({min: 10}).withMessage('Description must be at least 10 charactars long !'),
    async (req, res) => {
    try {
        const validation = validationResult(req);

        if(!validation.isEmpty()) {
            throw validation.errors;
        }

        await updateStone(req.params._id, req.body);
        res.redirect('/details/' + req.params._id);
    } catch(err) {
        res.render('edit', {stone: req.body, errors: parseError(err).errors})
    }
});

stoneRouter.get('/delete/:_id', isUser(), async(req, res) => {
    try{
        const stone = await getById(req.params._id).lean();

        if(stone.owner != req.user._id) {
             res.status(403).send('Acces denied!');
        }

        res.render('delete', {stone})

    } catch(err) {
        res.redirect('/404');
    }
});

stoneRouter.post('/delete/:_id', isUser(), async (req, res) => {
    try {
        await deleteStone(req.params._id, req.body);
        res.redirect('/dashboard');
    } catch(err) {
        res.render('delete', {stone: req.body, errors: parseError(err).errors})
    }
});

module.exports = {stoneRouter};