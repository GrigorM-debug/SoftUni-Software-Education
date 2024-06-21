const {Schema, SchemaTypes, model} = require('mongoose');

const stoneSchema = new Schema({
    name: {
        type: String,
        required: [true, 'Name is required !'],
        minlength: [2, 'Name must at least 2 characters long !']
    },
    category : {
        type: String,
        required: [true, 'Category  is required !'],
        minlength: [3, 'Category must at least 3 charactars long !']
    },
    color: {
        type: String,
        required: [true, 'Color is required !'],
        minlength: [2, 'Color must be at least 2 charactars long !']
    },
    image: {
        type: String,
        required: [true, 'Image is required !'],
        match: [/^(http:\/\/|https:\/\/)/, 'Invalid URL !']
    },
    location: {
        type: String,
        required: [true, 'Location is required !'],
        min: [5, 'Location must be between 5 and 15 charactars !'],
        max: [15, 'Location must be between 5 and 15 charactars !']

    },
    formula: {
        type: String,
        required: [true, 'Formula is required !'],
        min: [3, 'Location must be between 3 and 30 charactars !'],
        max: [30, 'Location must be between 3 and 30 charactars !']
    },
    description: {
        type: String,
        required: [true, 'Description is required !'],
        min: [10, 'Description must be at least 10 charactars long !'],
    },
    likedList: [{
        type: SchemaTypes.ObjectId,
        ref: 'User',
        default: []
    }],
    owner: {
        type: SchemaTypes.ObjectId,
        ref: 'User'
    }
});

const Stone = model('Stone', stoneSchema);

module.exports = {Stone};