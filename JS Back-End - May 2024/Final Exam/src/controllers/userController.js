const {Router} = require('express');
const { isGuest } = require('../middlewares/guards');
const {body, validationResult} = require('express-validator');
const {parseError} = require('../../utils/errorParser');
const { register, login } = require('../services/user');
const { signToken } = require('../services/jwt');

const userRouter = Router();

userRouter.get('/register', isGuest(), (req, res) => {
    res.render('register');
});

userRouter.post('/register', 
    isGuest(),
    body('username').trim().notEmpty().withMessage('Username is required !').isLength({min: 2, max: 20}).withMessage('Username must be between 2 and 20 charactars long !'),
    body('email').trim().notEmpty().withMessage('Email is required !').isEmail().withMessage('Invalid email address !').isLength({min: 10}).withMessage('Email must be at least 10 charactars long !'),
    body('password').trim().notEmpty().withMessage('Password is required !').isLength({min: 4}).withMessage('Password must at least 4 chractars long !'),
    body('repassword').trim().custom((value, {req}) => value == req.body.password).withMessage('Passwords don\'t match !'),
    async (req, res) => {

    try {
        const validation = validationResult(req);

        if(!validation.isEmpty()) {
            throw validation.errors;
        }

        await register(req.body.username, req.body.email, req.body.password);

        res.redirect('/login');
    } catch(err) {
        res.render('register', {userEmail: req.body.email, userName: req.body.username, errors: parseError(err).errors});
    }
});

userRouter.get('/login', isGuest(), (req, res) => {
    res.render('login');
});

userRouter.post('/login', 
    isGuest(),
    body('email').trim().notEmpty().withMessage('Email is required !').isEmail().withMessage('Invalid email address !').isLength({min: 10}).withMessage('Email must be at least 10 charactars long !'),
    body('password').trim().notEmpty().withMessage('Password is required !').isLength({min: 4}).withMessage('Password must at least 4 chractars long !'),
    async (req, res) => {

    try {
        const validation = validationResult(req);

        if(!validation.isEmpty()) {
            throw validation.errors;
        }

        const user = await login(req.body.email, req.body.password);

        const token = signToken(user);

        res.cookie('token', token, {httpOnly: true});
        res.redirect('/');
    } catch(err) {
        console.error(err)
        res.render('login', {userEmail: req.body.email, errors: parseError(err).errors});
    } 
});

userRouter.get('/logout', (req, res) => {
    res.clearCookie('token');
    res.redirect('/')
});

module.exports = { userRouter };