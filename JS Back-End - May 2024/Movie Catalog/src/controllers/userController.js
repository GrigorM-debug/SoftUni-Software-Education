const { signToken } = require("../services/jwt");
const { register, login } = require("../services/user");
const { Router } = require('express');

const {userValidations} = require('../../validations/userValidations');
const { validationResult, body } = require("express-validator");
const { parseError } = require("../../utils/errorParser");

const {isGuest, isUser} = require('../middlewares/guards');

const userRouter = Router();

userRouter.get('/register', isGuest(), (req, res) => {
    res.render('register');
});

userRouter.post('/register', 
    isGuest(),
    userValidations, 
    body('repassword').custom(
        (value, {req}) => value == req.body.password).withMessage('Passwords don\'t match!'),
    async (req, res) => {
    const {email, password} = req.body;

    try{  
        const validation = validationResult(req);

        if(!validation.isEmpty()){
            throw validation.errors;
        }

        await register(email, password);

        res.redirect('/login');
    } catch(err){
        res.render('register', { errors: parseError(err).errors, userEmail: email});
        return;
    }
});

userRouter.get('/login', isGuest(), (req, res) => {
    res.render('login');
});

userRouter.post('/login', 
    isGuest(),
    userValidations,
    async (req, res) => {
    const {email, password} = req.body;

    try{
        const validation = validationResult(req);

        if(!validation.isEmpty()){
            throw validation.errors;
        }

        const user = await login(email, password);

        const token = signToken(user);

        res.cookie('token', token, { httpOnly: true});
        res.redirect('/');
    } catch(err) {
        res.render('login', { userEmail: email, errors: parseError(err).errors});
        return;
    }
});

userRouter.get('/logout', isGuest(), (req, res) => {
    res.clearCookie('token');
    res.redirect('/');
});

module.exports = { userRouter };