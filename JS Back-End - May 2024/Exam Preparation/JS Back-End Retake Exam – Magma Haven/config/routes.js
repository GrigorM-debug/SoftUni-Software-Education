const {homeController} = require('../src/controllers/homeController');
const {detailsController} = require('../src/controllers/detailsController');
const {searchController} = require('../src/controllers/searchController');
const {catalogController} = require('../src/controllers/catalogController');
const { notFound } = require('../src/controllers/404Controller');
const { userRouter } = require('../src/controllers/userController');
const { volcanoRouter } = require('../src/controllers/volcanoController');

function routerConfig(app) {
    app.get('/', homeController);
    app.get('/catalog', catalogController);
    app.get('/details/:_id', detailsController);
    app.get('/search', searchController);

    app.use(userRouter);
    app.use(volcanoRouter);
    app.get('*', notFound);
}

module.exports = {routerConfig};