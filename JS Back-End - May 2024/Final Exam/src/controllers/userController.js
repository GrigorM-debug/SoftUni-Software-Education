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
    body('name').trim().notEmpty().withMessage('Name is required !').isLength({min: 2, max: 20}).withMessage('Name should be between 2 and 20 characters long !'),
    body('email').trim().notEmpty().withMessage('Email is required !').isEmail().withMessage('Invalid email address !').isLength({min: 10}).withMessage('Email should be at least 10 characters long !'),
    body('password').trim().notEmpty().withMessage('Password is required !').isLength({min: 4}).withMessage('Password should at least 4 characters long !'),
    body('repassword').trim().custom((value, {req}) => value == req.body.password).withMessage('Passwords don\'t match !'),
    async (req, res) => {

    try {
        const validation = validationResult(req);

        if(!validation.isEmpty()) {
            throw validation.errors;
        }

        await register(req.body.name, req.body.email, req.body.password);

        res.redirect('/login');
    } catch(err) {
        res.render('register', {userEmail: req.body.email, userName: req.body.name, errors: parseError(err).errors});
    }
});

userRouter.get('/login', isGuest(), (req, res) => {
    res.render('login');
});

userRouter.post('/login', 
    isGuest(),
    body('email').trim().notEmpty().withMessage('Email is required !').isEmail().withMessage('Invalid email address !').isLength({min: 10}).withMessage('Email should be at least 10 characters long !'),
    body('password').trim().notEmpty().withMessage('Password is required !').isLength({min: 4}).withMessage('Password should at least 4 characters long !'),
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
        res.render('login', {userEmail: req.body.email, errors: parseError(err).errors});
    } 
});

userRouter.get('/logout', (req, res) => {
    res.clearCookie('token');
    res.redirect('/')
});

module.exports = { userRouter };