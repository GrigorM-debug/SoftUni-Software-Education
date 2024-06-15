const {User} = require('../models/User');
const bcrypt = require('bcrypt');


async function register(email, password){
    const existingUser = await User.findOne({email});

    if(existingUser){
        throw new Error("Email is already used !");
        return;
    }

    const passwordHashed = await bcrypt.hash(password, 10);

    const user = new User({
        email,
        password: passwordHashed
    });

    await user.save();

    return user;
}

function login(){

}

function logout(){

}

module.exports = {register, login, logout};