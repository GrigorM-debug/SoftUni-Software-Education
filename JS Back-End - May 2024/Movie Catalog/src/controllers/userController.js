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

            //Create token

            res.redirect('/')
        } catch(err){
            res.render('register', { error: err, userEmail: email});
            return;
        }
    }, 
    loginGet: (req, res) => { 

    },
    loginPost: (req, res) => {

    }
}