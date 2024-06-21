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

}

function getById() {

}



module.exports = {
    create,
    getAll,
    getById
}