const { signToken } = require("../services/jwt");
const { register, login } = require("../services/user");

module.exports = {
    registerGet: (req, res) => {
        res.render('register');
    },
    registerPost: async (req, res) => {
        const {email, password, repassword} = req.body;

        try{  
            if(!email || !password || !repassword) {
                throw new Error('All fields are required !');
            }

            if(password != repassword) {
                throw new Error("Passwords doesn't match !");
            }

            const user = await register(email, password);

            res.redirect('/login');
        } catch(err){
            res.render('register', { error: err, userEmail: email});
            return;
        }
    }, 
    loginGet: (req, res) => { 
        res.render('login');
    },
    loginPost: async (req, res) => {
        const {email, password} = req.body;

        try{
            if(!email || !password) {
                throw new Error('All fields are required !');
            }

            const user = await login(email, password);

            const token = signToken(user);

            res.cookie('token', token);
            res.redirect('/');
        } catch(err) {
            res.render('login', { userEmail: email, error: err.message});
            return;
        }
    },
    logoutGet : (req, res) => {
        
    },
    logoutPost: (req, res) => {

    }
}