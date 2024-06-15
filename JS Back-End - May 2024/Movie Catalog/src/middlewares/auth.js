const { veritifyToken } = require("../services/jwt");

module.exports = {
    auth: (req, res, next) => {
        // console.log(req.signedCookies)
        const token = req.cookies['token'];

        if(!token) {
            return next();
        }

        try {
            const decoded = veritifyToken(token);
            req.user = decoded;
            res.locals.isAuthenticated = true;
        } catch (err) {
            res.clearCookie('token');
        }
    }
}