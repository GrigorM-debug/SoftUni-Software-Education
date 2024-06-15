const { veritifyToken } = require("../services/jwt");

function auth(){
    return (req, res, next) =>{
        const token = req.cookies['token'];

        if(!token) {
            return next();
        }

        try {
            const decoded = veritifyToken(token);
            req.user = decoded;
            res.locals.isAuthenticated = true;
            res.locals.user = decoded;

            next();
        } catch (err) {
            res.clearCookie('token');
            res.redirect('/login');
        }
    }
}

module.exports = {auth};




