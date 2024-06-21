const {Stone} = require('../models/Stone');
const { User } = require('../models/User');

async function create(newStoneData) {
    const stoneExisting = await Stone.findOne({name: newStoneData.name});

    if(stoneExisting) {
        throw new Error('Stone alreay exist !');
    }


    const result = await Stone.create(newStoneData)

    await result.save();

    return result;
}

function getLast3Added() {
    const stones = Stone.find().sort({_id: -1}).limit(3);

    return stones;
}

function getAll() {
    const stones = Stone.find();

    return stones;
}

function getById(stoneId) {
    const stone = Stone.findById(stoneId);

    if(!stone) {
        throw new Error('Stone doesn\'t exist !');
    }

    return stone;
}

async function updateStone(stoneId, newData) {
    const stone = await getById(stoneId);

    if(!stone) {
        throw new Error('Stone doesn\'t exist !');
    }

    const result = await Stone.findByIdAndUpdate(stoneId, newData);

    await result.save();
}

async function deleteStone(stoneId) {
    const stone = await getById(stoneId);

    if(!stone) {
        throw new Error('Stone doesn\'t exist !');
    }

    await Stone.findByIdAndDelete(stoneId);
}

async function likeStone(stoneId, userId) {
    const stoneForLike = await getById(stoneId);

    if(!stoneForLike) {
        throw new Error('Stone doesn\'t exist');
    }

    if(stoneForLike.likedList.some(ls => ls._id == userId)) {
        throw new Error('Stone is already liked !');
    }

    stoneForLike.likedList.push(userId);

    await stoneForLike.save()
}

module.exports = {
    create,
    getAll,
    getById,
    getLast3Added,
    likeStone,
    updateStone,
    deleteStone
}