const {Router} = require('express');
const { parseError } = require('../../utils/errorParser');
const { register, login } = require('../services/user');
const { signToken } = require('../services/jwt');

const userRouter = Router();

userRouter.get('/register', (req, res) => {
    res.render('register');
});

userRouter.post('/register', async (req, res) => {

    const username = req.body.username;
    const email = req.body.email;
    const password = req.body.password

    try {
        await register(username, email, password);

        res.redirect('/login');

    } catch(err) {
        res.render('register', {errors: parseError(err).errors, userEmail: email});
        return;
    }
});

userRouter.get('/login', (req, res) => {
    res.render('login');
});

userRouter.post('/login', async (req, res) => {
    const email = req.body.email;
    const password = req.body.password;

    try {
        const user = await login(email, password);

        const token = signToken(user);

        res.cookie('token', token);
        res.redirect('/');
    } catch(err) {
        res.render('login', {errors: parseError(err).errors, userEmail: email});
        return;
    }
});

userRouter.get('/logout', (req, res) => {
    res.clearCookie('token');
    res.redirect('/');
});

module.exports = {userRouter};