const { User } = require("../models/User");
const bcrypt = require('bcrypt');

async function register(username, email, password){
    const userWithEmailExist = await User.findOne({email});

    if(userWithEmailExist) {
        throw new Error('Email is already used!');
    }

    const userWithUsername = await User.findOne({username});

    if(userWithUsername){
        throw new Error('Username is already used!');
    }

    const user = new User({
        username,
        email,
        password: await bcrypt.hash(password,10)
    })

    await user.save();
}

async function login(email, password) {
    const user = await User.findOne({email});

    if(!user){
        throw new Error('Incorrect email or password');
    }

    const passwordMatch = await bcrypt.compare(password, user.password);
    
    if(!passwordMatch) {
        throw new Error('Incorrect email or password');
    }

    return user;
}

module.exports = {register, login};