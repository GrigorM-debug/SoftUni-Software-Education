const { notFound } = require("../src/controllers/404Controller");
const {detailsController} = require("../src/controllers/detailsController");
const {homeController} = require("../src/controllers/homeController");
const {recipeCatalogController} = require("../src/controllers/recipeCatalogController");
const { recipeRouter } = require("../src/controllers/recipeController");
const {searchController} = require("../src/controllers/searchController");
const { userRouter } = require("../src/controllers/userController")

function routerConfig(app) {
    //To-Do Config the routes
    app.get('/', homeController);
    app.get('/catalog', recipeCatalogController);
    app.get('/details/:_id', detailsController)
    app.get('/search', searchController);
    app.use(userRouter);
    app.use(recipeRouter);



    app.get('*', notFound);
}


module.exports = {routerConfig}