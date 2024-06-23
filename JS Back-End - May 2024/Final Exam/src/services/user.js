const {User} = require('../models/User');
const bcrypt = require('bcrypt');

async function register(username, email, password) {
    const user = await User.findOne({email});

    if(user) {
        throw new Error('Email is already used !');
    }

    const userNameExist = await User.findOne({username});

    if(userNameExist) {
        throw new Error('Username already exist !');
    }

    if(!password || password === '') {
        throw new Error('Password is required !');
    }

    const hashedPassword = await bcrypt.hash(password, 10);

    const newUSer = new User({
        username,
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