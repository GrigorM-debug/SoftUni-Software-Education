const {Schema, SchemaTypes, model} = require('mongoose');

const userSchema = new Schema({
    name: {
        type: String,
        required: [true, 'Name is required !'],
        min: [2, 'Name should be between 2 and 20 characters long !'],
        max: [20, 'Name should be between 2 and 20 characters long !']
    },
    email: {
        type: String,
        required: [true, 'Email is required !'],
        unique: true,
        min: [10, 'Email should be at least 10 characters long !']
    },
    password: {
        type: String,
        required: [true, 'Password is required !'],
        min: [4, 'Password should at least 4 chracters long !']
    }
});

const User = model('User', userSchema);

module.exports = {User};