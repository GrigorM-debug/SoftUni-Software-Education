const { signToken } = require("../services/jwt");
const { register, login } = require("../services/user");
const { Router } = require('express');

const userRouter = Router();

userRouter.get('/register', (req, res) => {
    res.render('register');
});

userRouter.post('/register', async (req, res) => {
    const {email, password, repassword} = req.body;

    try{  
        if(!email || !password || !repassword) {
            throw new Error('All fields are required !');
        }

        if(password != repassword) {
            throw new Error("Passwords doesn't match !");
        }

        const user = await register(email, password);

        res.redirect('/login');
    } catch(err){
        res.render('register', { error: err, userEmail: email});
        return;
    }
});

userRouter.get('/login', (req, res) => {
    res.render('login');
});

userRouter.post('/login', async (req, res) => {
    const {email, password} = req.body;

    try{
        if(!email || !password) {
            throw new Error('All fields are required !');
        }

        const user = await login(email, password);

        const token = signToken(user);

        res.cookie('token', token, { httpOnly: true});
        res.redirect('/');
    } catch(err) {
        res.render('login', { userEmail: email, error: err.message});
        return;
    }
});

userRouter.get('/logout', (req, res) => {
    res.clearCookie('token');
    res.redirect('/');
});

module.exports = { userRouter };