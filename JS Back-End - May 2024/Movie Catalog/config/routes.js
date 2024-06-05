const { Router } = require('express');
const {homeController, detailsController, search} = require('../src/controllers/homeController');
const {createGet, createPost} = require('../src/controllers/movieController');
const { notFound } = require('../src/controllers/404Controller');
const {about} = require('../src/controllers/aboutController')
const {castGet, castPost} = require('../src/controllers/castController')
const {attachCastGet, attachCastPost} = require('../src/controllers/movieController')

const router = Router();

router.get('/', homeController);
router.get('/about', about);
router.get('/create', createGet);
router.post('/create', createPost);
router.get('/cast-create', castGet);
router.post('/cast-create', castPost);
router.get('/cast-attach/:_id', attachCastGet);
router.post('/cast-attach/:_id', attachCastPost);
router.get('/details/:_id', detailsController);
router.get('/search', search);
router.get('*', notFound);


module.exports = {router}