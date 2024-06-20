const {Schema, model, SchemaTypes} = require('mongoose');

const userSchema = new Schema(
    {
        username: {
            type: String,
            required: [true, 'Username is required !'],
            min: [2, 'Username must at least 2 characters long !']
        },
        email: {
            type: String,
            required: [true, 'Email is required !'],
            unique: true,
            min: [10, 'Email must be at least 10 characters long !']
        },
        password: {
            type: String,
            required: [true, 'Password is required !'],
            min: [4, 'Password must be at least 4 characters long !']
        }
    },
    {
        collation:{
            locale: 'en',
            strength: 2
        }
    }
);

const User = model('User', userSchema);

module.exports = {User};