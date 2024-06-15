const { veritifyToken } = require("../services/jwt");

module.exports = {
    auth: (req, res, next) => {
        const token = req.cookies['token'];

        if(!token) {
            return next();
        }

        try {
            const decoded = veritifyToken(token);
            req.user = decoded;
            res.locals.isAuthenticated = true;
            res.locals.user = decoded;  // You can also pass user info if needed
        } catch (err) {
            res.clearCookie('token');
            res.redirect('/login');
        }
    },
    isAuth: (req, res, next) => {
        if(!req.user) {
            return res.redirect('/login');
        }

        next();
    }
}