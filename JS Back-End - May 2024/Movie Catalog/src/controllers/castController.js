const { createCast } = require("../services/cast");
const {Router} = require('express');
const {isAuth} = require("../middlewares/isAuth");
const {parseError} = require("../../utils/errorParser");
const {castValidation} = require("../../validations/castValidations");
const { validationResult } = require("express-validator");
const castRouter = Router();

castRouter.get('/cast-create', isAuth(), (req, res) =>{
    res.render('cast-create');
});

castRouter.post('/cast-create', 
    isAuth(), 
    castValidation,
    async (req, res) =>{
        
    const newCast = {
        name: req.body.name,
        age: req.body.age,
        born: req.body.born,
        nameInMovie: req.body.nameInMovie,
        castImage: req.body.castImage
    };
    try {
        const validations = validationResult(req);

        if(!validations.isEmpty()){
            throw validations.errors;
        }

       const result = await createCast(newCast)

        res.redirect('/')
    } catch(err){
        res.render('cast-create', {cast: newCast, errors: parseError(err).errors});
    }
});


module.exports = {
    castRouter
}