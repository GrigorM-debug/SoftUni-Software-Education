const { register } = require("../services/user");

module.exports = {
    registerGet: (req, res) => {
        res.redirect('/login');
    },
    registerPost: async (req, res) => {
        const {email, password, repassword} = req.body;

        if(!email || !password) {
            throw new Error('All fields are require');
        }

        if(password != repassword) {
            throw new Error("Passwords doesn't match");
        }

        try{
            const user = await register(email, password);

            //Create token

            res.redirect('/')
        } catch(err){
            console.log(err);
            res.render('/register', {data: email});
            return;
        }
    }, 
    loginGet: (req, res) => { 

    },
    loginPost: (req, res) => {

    }
}