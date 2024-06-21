const {Stone} = require('../models/Stone');

async function create(newStoneData) {
    const stoneExisting = await Stone.findOne({name: newStoneData.name});

    if(stoneExisting) {
        throw new Error('Stone alreay exist !');
    }


    const result = await Stone.create(newStoneData)

    await result.save();

    return result;
}

function getAll() {
    const stones = Stone.find().sort({_id: -1}).limit(3);

    return stones;
}

async function getById(stoneId) {
    const stone = await Stone.findById(stoneId);

    if(!stone) {
        throw new Error('Stone doesn\'t exist !');
    }

    return stone;
}



module.exports = {
    create,
    getAll,
    getById
}