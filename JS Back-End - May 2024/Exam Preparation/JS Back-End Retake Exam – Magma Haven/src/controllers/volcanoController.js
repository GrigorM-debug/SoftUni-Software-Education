const {Router} = require('express');
const { isAuth } = require('../middleweres/isAuth');
const { create } = require('../services/volcano');

const volcanoRouter = Router();

volcanoRouter.get('/create-volcano', isAuth(), (req, res) => {
    res.render('create');
})

volcanoRouter.post('/create-volcano', isAuth(), async (req, res) => {

    const newVolcano = {
        name: req.body.name,
        location: req.body.location,
        elevation: Number(req.body.elevation),
        lastEruption: Number(req.body.lastEruption),
        image: req.body.image,
        typeVolcano: req.body.type,
        description: req.body.description,
    }

    const volcano = await create(newVolcano);

    // res.redirect('/details' + volcano._id);
    res.redirect('/')
});

module.exports = {volcanoRouter};