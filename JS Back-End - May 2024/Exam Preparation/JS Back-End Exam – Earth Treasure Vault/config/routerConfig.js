const { notFound } = require("../src/controllers/404controller");
const {dashboardController} = require("../src/controllers/dashboardController");
const {detailsController} = require("../src/controllers/detailsController");
const {homeController} = require('../src/controllers/homeController');
const {searchController} = require("../src/controllers/searchController");
const { stoneRouter } = require("../src/controllers/stoneController");
const { userRouter} = require("../src/controllers/userController")

function routerConfig(app) {
    app.get('/', homeController);
    app.get('/details/:_id', detailsController);
    app.get('/search', searchController);
    app.get('/dashboard', dashboardController);

    app.use(userRouter);
    app.use(stoneRouter);

    app.get('*', notFound);
}


module.exports = {routerConfig}