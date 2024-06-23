const { getById } = require("../services/recipe");

module.exports = {
    detailsController: async (req, res) => {
        const recipe = await getById(req.params._id).lean();

        const isCreator = req.user && req.user._id == recipe.owner;
        const isRecommended = req.user && recipe.recommendList.some(u => u._id == req.user._id);

        res.render('details', {recipe, isCreator, isRecommended});
    }
};