const { notFound } = require("../src/controllers/404Controller");
const {detailsController} = require("../src/controllers/detailsController");
const {homeController} = require("../src/controllers/homeController");
const { userRouter } = require("../src/controllers/userController")

function routerConfig(app) {
    //To-Do Config the routes
    app.get('/', homeController);
    //Check if the page is called Details or something else
    app.get('/details/:_id', detailsController)

    app.use(userRouter);



    app.get('*', notFound);
}


module.exports = {routerConfig}