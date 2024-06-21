const jwt = require('jsonwebtoken');

const secret = 'Secret';

function signToken(userData) {
    const payload = {
        _id: userData._id,
        email: userData.email
    }

    const token = jwt.sign(payload, secret, {expiresIn: '2d'})

    return token;
}

function verifyToken(token) {
    const verifiedTokenData = jwt.verify(token);

    return verifiedTokenData;
}

module.exports = {signToken, verifyToken};