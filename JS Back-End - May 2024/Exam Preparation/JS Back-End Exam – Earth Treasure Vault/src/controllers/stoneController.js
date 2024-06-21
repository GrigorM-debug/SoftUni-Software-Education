const {Router} = require('express');
const { isUser } = require('../middlewares/guards');
const {parseError} = require('../../util/errorParser');
const { create } = require('../services/stone');

const stoneRouter = Router();

stoneRouter.get('/create', isUser(), (req, res) => {
    res.render('create');
});

stoneRouter.post('/create', 
    isUser(),
     
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
        const result = await create(newStone);

        res.redirect('/details/' + result._id);
    } catch(err) {
        res.render('create', {errors: parseError(err).errors, stone: newStone})
    } 
});

stoneRouter.get('/edit/:_id', isUser(), (req, res) => {

});

stoneRouter.post('/edit/:_id', isUser(), (req, res) => {

});

stoneRouter.get('/delete/:_id', isUser(), (req, res) => {

});

stoneRouter.post('/delete/:_id', isUser(), (req, res) => {

});

module.exports = {stoneRouter};