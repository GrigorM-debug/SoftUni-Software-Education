const {Schema, SchemaTypes, model} = require('mongoose');

const recipeSchema = new Schema({
    title: {
        type: String, 
        required: [true, 'Title is required !'],
        min: [2, 'Title must at least 2 characters long !']
    },
    ingredients: {
        type: String,
        required: [true, 'Ingredients are required !'],
        min: [10, 'Ingredients must between 10 and 200 characters long !'],
        max: [200, 'Ingredients must between 10 and 200 characters long !']
    },
    instructions: {
        type: String,
        required: [true, 'Instructions are required !'],
        min: [10, 'Instructions must be at least 10 characters long !']
    },
    description: {
        type: String,
        required: [true, 'Description is required !'],
        min: [10, 'Description must between 10 and 100 characters long !'],
        max: [100, 'Description must between 10 and 100 characters long !']
    },
    image: {
        type: String,
        required: [true, 'Image URL is required !'],
        match: [/^(http:\/\/|https:\/\/)/, 'Invalid URL !']
    },
    recommendList: [{
        type: SchemaTypes.ObjectId,
        ref: 'User',
        default: []
    }],
    owner: {
        type: SchemaTypes.ObjectId,
        ref: 'User'
    }
});

const Recipe = model('Recipe', recipeSchema);

module.exports = {Recipe};