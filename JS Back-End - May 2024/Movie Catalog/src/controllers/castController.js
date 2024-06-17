const { createCast } = require("../services/cast");
const {Router} = require('express');
const {isAuth} = require("../middlewares/isAuth");

const castRouter = Router();

castRouter.get('/create', isAuth(), (req, res) =>{
    res.render('cast-create');
});

castRouter.post('/create', isAuth(), async (req, res) =>{
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
});


module.exports = {
    castRouter
}