const {Schema, model, SchemaTypes} = require('mongoose');

const castSchema = new Schema({
    name: {
        type: String,
        require: true
    },
    age: {
        type: Number,
        require: true,
        min: 14,
        max: 120
    },
    born: {
        type: String,
        require: true
    },
    nameInMovie: {
        type: String,
        require: true
    }, 
    castImageL: {
        type: String,
        require: true,
        validate: {
            validator: function(value) {
                return /^(http|https):\/\/[^ "]+$/.test(value);
            },
            message: props => `${props.value} is not a valid URL!`
        }
    },
    movies: [{
        type: SchemaTypes.ObjectId, 
        ref: 'Movie'
    }]
});

const Cast = model('Cast', castSchema);

module.exports = {Cast};