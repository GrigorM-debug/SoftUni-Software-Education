const { getVolcanoById } = require("../services/volcano");

module.exports = {
    detailsController: async (req, res) => {
        try{
            const volcano = await getVolcanoById(req.params._id).lean();

            const isCreator = req.user && req.user._id == volcano.owner;

            res.render('details', {volcano, isCreator});
        } catch(err) {
            res.render('404');
        }
    }
}