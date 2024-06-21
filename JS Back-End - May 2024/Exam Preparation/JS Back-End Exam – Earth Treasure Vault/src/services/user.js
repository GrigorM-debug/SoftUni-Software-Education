const {User} = require('../models/User')
const bcrypt = require('bcrypt');

async function register(email, password) {
    const existingUser = await User.findOne({email});

    if(existingUser) {
        throw new Error('Email is already used !');
    }

    if(!password || password === '') {
        throw new Error('Password is required !');
    }

    const user = new User({
        email,
        password: await bcrypt.hash(password, 10)
    })

    await user.save();

    return user;
}

async function login(email, password){
    const existingUser = await User.findOne({email});

    if(!existingUser) {
        throw new Error('Incorrect email or password');
    }

    if(!password || password === '') {
        throw new Error('Password is required !');
    }

    const passwordMatch = await bcrypt.compare(password, existingUser.password);

    if(!passwordMatch) {
        throw new Error('Incorrect email or password');
    }

    return existingUser;
}

module.exports = {register, login}