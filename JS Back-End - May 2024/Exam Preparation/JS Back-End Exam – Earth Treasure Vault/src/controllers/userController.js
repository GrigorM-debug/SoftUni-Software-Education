const {Router} = require('express');
const { isGuest, isUser } = require('../middlewares/guards');

const userRouter = Router();

userRouter.get('/register', isGuest(), (req, res) => {

});

userRouter.post('/register', isGuest(), (req, res) => {

});

userRouter.get('/login', isGuest(), (req, res) => {

});

userRouter.post('/login', isGuest(), (req, res) => {

});

userRouter.get('/logout', isUser(), (req, res) => {

})

module.exports = {userRouter};