const cookieParser = require('cookie-parser');
const express = require('express');
const {auth, isAuth} = require('../src/middlewares/auth');

function configExpress(app){
    app.use('/static', express.static('static'));
    app.use(cookieParser());
    app.use(auth());
    app.use(isAuth());
    app.use(express.urlencoded({extended: true}))
}

module.exports = {configExpress};