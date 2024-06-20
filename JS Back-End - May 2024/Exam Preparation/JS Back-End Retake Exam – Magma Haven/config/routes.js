const {homeController, detailsController, searchController} = require('../src/controllers/homeController');
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