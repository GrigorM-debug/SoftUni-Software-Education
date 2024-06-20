const { User } = require("../models/User");
const { Volcano } = require("../models/Volcano");

async function create(newVolcano) {
    const volcanoExist = await Volcano.findOne({name: newVolcano.name});

    if(volcanoExist) {
        throw new Error('Volcano already exist !');
    }

    const volcano = await Volcano.create(newVolcano);

    return volcano;
}

function getAllVolcanos(){
    return Volcano.find();
}

function getVolcanoById(volcanoId) {
    const volcano = Volcano.findById(volcanoId);

    if(!volcano) {
        throw new Error('Volcano doesn\'t exist');
    }

    return volcano;
}

async function updateVolcano(volcanoId, newData) {
    const volcanoExist = await getVolcanoById(volcanoId);

    if(!volcanoExist) {
        throw new Error('Volcano doesn\'t exist');
    }

    const volcano = await Volcano.findByIdAndUpdate(volcanoId, newData);

    await volcano.save();

    return volcano;
}

async function deleteVolcano(volcanoId) {
    const volcanoExist = await getVolcanoById(volcanoId);

    if(!volcanoExist) {
        throw new Error('Volcano doesn\'t exist');
    }
    const volcano = await Volcano.findByIdAndDelete(volcanoId);

    await volcano.save();
}

async function voteForVolcano(userId, volcanoId) {
    const volcano = await getVolcanoById(volcanoId);
    const user = await User.findById(userId);

    if(!volcano) {
        throw new Error('Volcano doesn\'t exist !');
    }
    
    // //before fix
    // volcano.voteList.add(user);

    //after almost 2 hours trying to find the bugS
    volcano.voteList.push(user);
    await volcano.save();
}

module.exports = {create, getAllVolcanos, getVolcanoById, updateVolcano, voteForVolcano, deleteVolcano};