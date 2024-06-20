const {Router} = require('express');
const { parseError } = require('../../utils/errorParser');
const { register, login } = require('../services/user');
const { signToken } = require('../services/jwt');
const { userValidations } = require('../../validations/userValidations');
const { body, validationResult } = require('express-validator');

const userRouter = Router();

userRouter.get('/register', (req, res) => {
    res.render('register');
});

userRouter.post('/register', 
    userValidations,
    body('username')
        .trim()
        .notEmpty()
        .withMessage('Username is required !'),
    
    body('username')
        .trim()
        .isLength({min: 2})
        .withMessage('Username must at least 2 characters long !'),

    body('repassword').custom(
        (value, {req}) => value == req.body.password).withMessage('Passwords don\'t match!'),
    async (req, res) => {

    const username = req.body.username;
    const email = req.body.email;
    const password = req.body.password

    try {
        const validation = validationResult(req);

        if(!validation.isEmpty()){
            throw validation.errors;
        }

        await register(username, email, password);

        res.redirect('/login');

    } catch(err) {
        res.render('register', {errors: parseError(err).errors, userEmail: email, userUsername: username});
        return;
    }
});

userRouter.get('/login', (req, res) => {
    res.render('login');
});

userRouter.post('/login',
    userValidations,    
    async (req, res) => {
    
    const email = req.body.email;
    const password = req.body.password;

    try {
        const validation = validationResult(req);

        if(!validation.isEmpty()) {
            throw validation.errors;
        }

        const user = await login(email, password);

        const token = signToken(user);

        res.cookie('token', token, { httpOnly: true});
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