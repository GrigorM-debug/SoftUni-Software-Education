const {isAuth} = require('../src/middlewares/isAuth');
const {homeController, detailsController, search} = require('../src/controllers/homeController');
const {movieRouter} = require('../src/controllers/movieController');
const { notFound } = require('../src/controllers/404Controller');
const {about} = require('../src/controllers/aboutController');
const {castRouter} = require('../src/controllers/castController');
const { userRouter } = require('../src/controllers/userController');

function routerConfig(app) {
    app.get('/', homeController);
    app.get('/about', about);

    
    app.get('/details/:_id', detailsController);
    app.get('/search', search);
    
    app.use(userRouter);

    app.use(movieRouter);

    app.use(castRouter);

    app.get('*', notFound);
}

module.exports = {routerConfig};