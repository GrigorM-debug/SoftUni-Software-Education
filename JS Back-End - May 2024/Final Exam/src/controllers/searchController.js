const { getAll } = require("../services/recipe");

module.exports = {
    searchController : async (req, res) => {
        const title = req.query.search;

        const recipes = await getAll().lean();

        let recipesFiltered = [];

        if(title) {
            recipesFiltered = recipes.filter(r => new RegExp(title, 'i').test(r.title));
        } else{
            recipesFiltered = recipes;
        }

        res.render('search', {recipesFiltered});
    }
}