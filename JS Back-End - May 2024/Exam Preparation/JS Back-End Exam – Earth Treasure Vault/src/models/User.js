const {Schema, SchemaTypes, model} = require('mongoose');

const userSchema = new Schema({
    email: {
        type: String,
        required: [true, 'Email is required !'],
        min: [10, 'Email must at least 10 characters long !'],
        unique: true
    },
    password: {
        type: String,
        required: [true, 'Password is required !'],
        min: [4, 'Password must be at least 4 characters long !']
    }
});

const User = model('User', userSchema);

module.exports = {User};