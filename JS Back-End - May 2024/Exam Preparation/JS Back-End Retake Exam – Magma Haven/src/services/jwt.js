const jwt = require('jsonwebtoken');

const secret = 'Secret';

function signToken(user) {
    const payload = {
        _id: user._id,
        email: user.email
    }

    const token = jwt.sign(payload, secret, {expiresIn: '2d'});

    return token;
}

function veritifyToken(token) {
    const verifiedToken = jwt.verify(token, secret);

    return verifiedToken;
} 

module.exports ={ signToken, veritifyToken}