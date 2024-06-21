const {Schema, SchemaTypes, model} = require('mongoose');

const userSchema = new Schema({
    email: {
        type: String,
        required: [true, 'Email is required !']
    },
    password: {
        type: String,
        required: [true, 'Password is required !']
    }
});

const User = model('User', userSchema);

module.exports = {User};