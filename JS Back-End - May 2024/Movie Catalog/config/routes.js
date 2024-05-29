const { Router } = require('express');
const {homeController, detailsController, search} = require('../src/controllers/homeController');
const {createGet, createPost} = require('../src/controllers/movieController');
const { notFound } = require('../src/controllers/404Controller');
const {about} = require('../src/controllers/aboutController')

const router = Router();

router.get('/', homeController);
router.get('/about', about);
router.get('/create', createGet);
router.post('/create', createPost);
router.get('/details/:id', detailsController);
router.get('/search', search)
router.get('*', notFound)


module.exports = {router}