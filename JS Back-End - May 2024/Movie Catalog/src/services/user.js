const {User} = require('../models/User');
const bcrypt = require('bcrypt');


async function register(email, password){
    const existingUser = await User.findOne({email});

    if(existingUser){
        throw new Error("Email is already used !");
    }

    // const passwordHashed = await bcrypt.hash(password, 10);

    const user = new User({
        email,
        password: await bcrypt.hash(password, 10)
    });


    await user.save();

    return user;
}

async function login(email, password){
    const user = await User.findOne({email});

    if(!user){
        throw new Error("Incorrect email or password");
    }

    const passwordMatch = await bcrypt.compare(password, user.password);

    if(!passwordMatch){
        throw new Error("Incorrect email or password");
    }

    return user
}

function logout(){
    res.clearCookie('token');
    res.redirect('/');
}

module.exports = {register, login, logout};