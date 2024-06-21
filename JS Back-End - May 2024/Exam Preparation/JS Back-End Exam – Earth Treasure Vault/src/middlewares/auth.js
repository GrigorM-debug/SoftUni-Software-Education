const { verifyToken } = require("../services/jwt");

function auth(){
    return (req, res, next) => {
        const token = req.cookies['token'];
        
        if(!token) {
            return next();
        }

        try{
            const decodedTokenData = verifyToken(token);

            req.user = decodedTokenData;
            res.locals.isAuthenticated = true;
            next();
        } catch(err) {
            res.clearCookie('token');
            res.redirect('/login');
        }
    }
}

module.exports = {auth};