const {Cast} = require('../models/Cast');

function getAllCast() {
    const casts = Cast.find();

    return casts;
}

function getCastById(castId){
    const cast = Cast.findById(castId);

    return cast;
}

function createCast(castData){
    Cast.create(castData);
}

module.exports = {getAllCast, getCastById, createCast}