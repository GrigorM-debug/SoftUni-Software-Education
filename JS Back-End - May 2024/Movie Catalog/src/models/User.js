const {Schema, model} = require('mongoose');

const userSchema = new Schema(
    {
        email: {
            type: String,
            required: true,
            unique: true,
            match: [/^[a-zA-Z0-9]+@[a-zA-Z]+\.[a-zA-Z]+$/, 'Please enter a valid username!'],
            min: [10, 'Username must be at least 10 characters long.'],
        },
        password: {
            type: String,
            required: true,
            match: [/^[a-zA-Z0-9]+$/, 'Please enter a valid password!'],
            min: [6, 'Password must be at least 6 characters long.'],
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