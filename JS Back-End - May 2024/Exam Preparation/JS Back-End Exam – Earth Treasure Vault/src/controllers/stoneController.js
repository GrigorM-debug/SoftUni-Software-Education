const {Router} = require('express');
const { isUser } = require('../middlewares/guards');

const stoneRouter = Router();

stoneRouter.get('/create', isUser(), (req, res) => {

});

stoneRouter.post('/create', isUser(), (req, res) => {

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