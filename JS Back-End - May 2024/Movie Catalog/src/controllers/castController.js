const { createCast } = require("../services/cast");

module.exports = {
    castGet: (req, res) => {
        res.render('cast-create');
    },
    castPost: async (req, res) => {
        const errors = {
            name: !req.body.name,
            age: !req.body.age,
            born: !req.body.born,
            nameInMovie: !req.body.nameInMovie,
            castImage: !req.body.castImage,
        };
        
        if(Object.values(errors).includes(true)){
            res.render('cast-create', {cast: req.body, errors})
            return;
        }

        await createCast(req.body)

        res.redirect('/')
        // res.redirect('/details/' + result.id);
    }
}