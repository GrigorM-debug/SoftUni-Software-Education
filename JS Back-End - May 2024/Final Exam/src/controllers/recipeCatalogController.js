const { getAll } = require("../services/recipe")

module.exports = {
    recipeCatalogController: async (req, res) => {
       const recipes = await getAll().lean();
       
        res.render('catalog', {recipes});
    }
}