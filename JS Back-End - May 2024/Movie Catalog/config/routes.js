const {isAuth} = require('../src/middlewares/isAuth');
const { Router } = require('express');
const {homeController, detailsController, search} = require('../src/controllers/homeController');
const {createGet, createPost, editGet, editPost} = require('../src/controllers/movieController');
const { notFound } = require('../src/controllers/404Controller');
const {about} = require('../src/controllers/aboutController');
const {castGet, castPost} = require('../src/controllers/castController');
const {attachCastGet, attachCastPost} = require('../src/controllers/movieController');
const { registerGet, registerPost, loginGet, loginPost, logoutGet } = require('../src/controllers/userController');

const router = Router();

router.get('/', homeController);
router.get('/about', about);
router.get('/register', registerGet);
router.post('/register', registerPost);
router.get('/login', loginGet);
router.post('/login', loginPost);
router.get('/logout', logoutGet);
router.get('/create', isAuth(), createGet);
router.post('/create', isAuth(), createPost);
router.get('/edit/:_id', isAuth(), editGet);
router.post('/edit/:_id', isAuth(), editPost);
router.get('/cast-create', isAuth(), castGet);
router.post('/cast-create', isAuth(), castPost);
router.get('/cast-attach/:_id', isAuth(), attachCastGet);
router.post('/cast-attach/:_id', isAuth(), attachCastPost);
router.get('/details/:_id', detailsController);
router.get('/search', search);
router.get('*', notFound);


module.exports = {router};