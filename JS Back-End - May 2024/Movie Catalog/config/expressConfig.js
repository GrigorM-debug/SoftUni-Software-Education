const express = require('express');

function configExpress(app){
    app.use('/static', express.static('static'));
    app.use(express.urlencoded({extended: true}))
}

module.exports = {configExpress};