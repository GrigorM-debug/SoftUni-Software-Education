const {Router} = require('express');
const {isUser } = require('../middleweres/guards');
const { create, getVolcanoById, updateVolcano, deleteVolcano } = require('../services/volcano');
const {parseError} = require('../../utils/errorParser');
const { volcanoValidations } = require('../../validations/volcanoValidation');
const { validationResult } = require('express-validator');

const volcanoRouter = Router();

volcanoRouter.get('/create-volcano', isUser(), (req, res) => {
    res.render('create');
})

volcanoRouter.post('/create-volcano', 
    isUser(),
    volcanoValidations, 
    async (req, res) => {
    
    const creatorId = req.user._id;

    const newVolcano = {
        name: req.body.name,
        location: req.body.location,
        elevation: req.body.elevation,
        lastEruption: req.body.lastEruption,
        image: req.body.image,
        typeVolcano: req.body.type,
        description: req.body.description,
        owner: creatorId
    }

    try{
        const validation = validationResult(req);

        if(!validation.isEmpty()) {
            throw validation.errors;
        }

        const volcano = await create(newVolcano);
    
        res.redirect('/details/' + volcano._id);
        // res.redirect('/')
    } catch(err) {
        res.render('create', {errors: parseError(err).errors, volcano: newVolcano})
    }
});

volcanoRouter.get('/edit/:_id', isUser(), async (req, res) => {
    
    try{
        const volcano = await getVolcanoById(req.params._id).lean();

        if(volcano.owner != req.user._id) {
             res.status(403).send('Acces denied!');
        }

        res.render('edit', {volcano})

    } catch(err) {
        res.redirect('/404');
    }
});

volcanoRouter.post('/edit/:_id', isUser(), volcanoValidations, async (req, res) => {
    try {
        const validation = validationResult(req);

        if(!validation.isEmpty()) {
            throw validation.errors;
        }

        await updateVolcano(req.params._id, req.body);
        res.redirect('/details/' + req.params._id);
    } catch(err) {
        res.render('edit', {volcano: req.body, errors: parseError(err).errors})
    }
});

volcanoRouter.get('/delete/:_id', isUser(), async (req, res) => {

    try {
        const volcano = await getVolcanoById(req.params._id).lean();

        if(volcano.owner != req.user._id) {
            res.status(403).send('Acces denied!');
        }

        res.render('delete', {volcano});
    } catch(err) {
        res.redirect('/404')
    }
})

volcanoRouter.post('/delete/:_id', isUser(), async (req, res) =>{
    try{
        await deleteVolcano(req.params._id);

        res.redirect('/catalog');
    } catch(err) {
        res.redirect('/404');
    }
});

module.exports = {volcanoRouter};