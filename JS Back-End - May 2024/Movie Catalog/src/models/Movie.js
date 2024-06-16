const {Schema, model, SchemaTypes} = require('mongoose');

const movieSchema = new Schema({
    title:{
        type: String,
        required: true
    },
    genre: {
        type: String,
        required: true
    },
    director: {
        type: String,
        required: true
    },
    year: {
        type: Number,
        require: true,
        min: 1900,
        max: 2300
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
        max: 1000
    },
    creator: {
        type: SchemaTypes.ObjectId,
        ref: 'User'
    },
    imageURL: {
        type: String,
        require: true,
        validate: {
            validator: function(value) {
                return /^(http|https):\/\/[^ "]+$/.test(value);
            },
            message: props => `${props.value} is not a valid URL!`
        }
    },
    casts: {
        type: SchemaTypes.ObjectId,
        ref: 'Cast'
    }
});

const Movie = model('Movie', movieSchema);

module.exports = {Movie}