const { Volcano } = require("../models/Volcano");

async function create(newVolcano) {
    const volcanoExist = await Volcano.findOne({name: newVolcano.name});

    if(volcanoExist) {
        throw new Error('Volcano already exist !');
    }

    const volcano = await Volcano.create(newVolcano);

    return volcano;
}

async function getAllVolcanos(){
    return await Volcano.find();
}

async function getVolcanoById(volcanoId) {
    const volcano = await Volcano.findById(volcanoId);

    if(!volcano) {
        throw new Error('Volcano doesn\'t exist');
    }

    return volcano;
}


module.exports = {create, getAllVolcanos, getVolcanoById};