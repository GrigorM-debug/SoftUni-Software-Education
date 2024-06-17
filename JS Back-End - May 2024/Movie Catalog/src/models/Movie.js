const {Schema, model, SchemaTypes} = require('mongoose');

const movieSchema = new Schema({
    title:{
        type: String,
        required: true,
        min: [5, 'Movie title must be at least 5 characters long.'],
        match: [/^[a-zA-Z0-9\s]+$/, 'Please enter a valid title!']
    },
    genre: {
        type: String,
        required: true,
        min: [5, 'Movie genre must be at least 5 characters long.'],
        match: [/^[a-zA-Z0-9\s]+$/, 'Please enter a valid genre!']
    },
    director: {
        type: String,
        required: true,
        min: [5, 'Movie director must be at least 5 characters long.'],
        match: [/^[a-zA-Z0-9\s]+$/, 'Please enter a valid director!']
    },
    year: {
        type: Number,
        require: true,
        min: 1900,
        max: 2024 
    },
    rating: {
        type: Number,
        require: true,
        min: 1,
        max: 5
    },
    description: {
        type: String,
        require: true,
        min: 20,
        match: [/^[a-zA-Z0-9\s]+$/, 'Please enter a valid description!']
    },
    creator: {
        type: SchemaTypes.ObjectId,
        ref: 'User'
    },
    imageURL: {
        type: String,
        require: true,
        match: [/^(http|https):\/\/[^ "]+$/, 'Please enter a valid URL!']
    },
    casts: {
        type: SchemaTypes.ObjectId,
        ref: 'Cast'
    }
});

const Movie = model('Movie', movieSchema);

module.exports = {Movie}