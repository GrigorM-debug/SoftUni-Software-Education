const cookieParser = require('cookie-parser');
const express = require('express');
// const {auth} = require('../src/middlewares/auth');

const secret = 'Neshto si';

function configExpress(app){
    app.use(cookieParser(secret));
    // app.use(auth());
    app.use(express.urlencoded({extended: true}))
    app.use('/static', express.static('static'));
}

module.exports = {configExpress};