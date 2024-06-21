function isAuth() {
    return (req, res, next) => {
        if(!req.user) {
            return res.redirect('/login');
        }

        next();
    }
}

function isGuest() {
    return (req, res, next) => {
        if(req.user) {
            return res.redirect('/');
        }

        next();
    }
}

module.exports = {isAuth, isGuest};