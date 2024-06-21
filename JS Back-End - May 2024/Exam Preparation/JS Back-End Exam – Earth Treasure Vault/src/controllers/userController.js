const {Router} = require('express');
const { isGuest, isUser } = require('../middlewares/guards');
const {parseError} = require('../../util/errorParser');
const { register, login } = require('../services/user');
const { body, validationResult } = require('express-validator');
const { signToken } = require('../services/jwt');

const userRouter = Router();

userRouter.get('/register', isGuest(), (req, res) => {
    res.render('register');
});

userRouter.post('/register', 
    isGuest(), 
    body('email').trim(),
    body('password').trim().notEmpty().withMessage('Password is required !').isLength({min: 4}).withMessage('Password must at least 4 character long!'),
    body('repassword').trim(),
    body('repassword').custom((value, {req}) => value == req.body.password).withMessage('Passwords don\'t match !'),
    async (req, res) => {

    try{
        const validation = validationResult(req);

        if(!validation.isEmpty()) {
            throw validation.errors;
        }

        // console.log(req.body.password)
        await register(req.body.email, req.body.password);

        res.redirect('/login');

    } catch(err){
        res.render('register', {errors: parseError(err).errors, userEmail: req.body.email})
    }
});

userRouter.get('/login', isGuest(), (req, res) => {
    res.render('login');
});

userRouter.post('/login', 
    isGuest(), 
    body('email').trim(),
    body('password').trim().notEmpty().withMessage('Password is required !').isLength({min: 4}).withMessage('Password must at least 4 character long!'),
    async (req, res) => {
    try{
        const validation = validationResult(req);

        if(!validation.isEmpty()) {
            throw validation.errors;
        }

        // console.log(req.body.password)
        const user = await login(req.body.email, req.body.password);

        const token = signToken(user);

        res.cookie('token', token, {httpOnly: true})
        res.redirect('/');

    } catch(err){
        res.render('login', {errors: parseError(err).errors, userEmail: req.body.email})
    }
});

userRouter.get('/logout', isUser(), (req, res) => {
    res.clearCookie('token');
    res.render('/');
})

module.exports = {userRouter};