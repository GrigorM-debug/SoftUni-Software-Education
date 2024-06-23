const { getLast3Added } = require("../services/recipe");

module.exports = {
    homeController: async (req, res) => {
        const last3AddedRecipes = await getLast3Added().lean();
        res.render('home', {recipes: last3AddedRecipes});
    }
};