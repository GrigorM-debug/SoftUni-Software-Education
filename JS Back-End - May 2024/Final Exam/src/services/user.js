const {User} = require('../models/User');
const bcrypt = require('bcrypt');

async function register(name, email, password) {
    const user = await User.findOne({email});

    if(user) {
        throw new Error('Email is already used !');
    }

    if(!password || password === '') {
        throw new Error('Password is required !');
    }

    const hashedPassword = await bcrypt.hash(password, 10);

    const newUSer = new User({
        name,
        email,
        password: hashedPassword
    });

    await newUSer.save();
}

async function login(email, password) {
    const user = await User.findOne({email});

    if(!user) {
        throw new Error('Incorrect email or password');
    }

    if(!password || password === '') {
        throw new Error('Password is required !');
    }

    const passwordMatch = await bcrypt.compare(password, user.password);

    if(!passwordMatch) {
        throw new Error('Incorrect email or password');
    }

    return user;
}

module.exports = {
    register,
    login
}