const jwt = require('jsonwebtoken');

const SECRET = 'I dont know';

function signToken(user){
    const payload = {
        _id: user._id,
        email: user.email
    };

    const token = jwt.sign(payload, SECRET);

    return token;
}

function veritifyToken(token){
    const verifiedToken = jwt.verify(token, SECRET);

    return verifiedToken;
}

module.exports = {
    signToken, veritifyToken
}