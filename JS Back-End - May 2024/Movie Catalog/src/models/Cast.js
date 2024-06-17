const {Schema, model, SchemaTypes} = require('mongoose');

const castSchema = new Schema({
    name: {
        type: String,
        require: true,
        min: [5, 'Cast name must be at least 5 characters long.'],
        match: [/^[a-zA-Z0-9\s]+$/, 'Please enter a valid name!']
    },
    age: {
        type: Number,
        require: true,
        min: 1,
        max: 120
    },
    born: {
        type: String,
        require: true,
        min: 10,
        match: [/^[a-zA-Z0-9\s]+$/, 'Please enter a valid date!']
    },
    nameInMovie: {
        type: String,
        require: true
    }, 
    castImage: {
        type: String,
        require: true,
        match: [/^(http|https):\/\/[^ "]+$/, 'Please enter a valid URL!']
    },
    movies: [{
        type: SchemaTypes.ObjectId, 
        ref: 'Movie'
    }]
});

const Cast = model('Cast', castSchema);

module.exports = {Cast};