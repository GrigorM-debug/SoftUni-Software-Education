const { register } = require("../services/user");

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
    loginPost: (req, res) => {

    }
}