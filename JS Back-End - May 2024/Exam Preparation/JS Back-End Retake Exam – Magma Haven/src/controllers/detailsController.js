const { getVolcanoById } = require("../services/volcano");

module.exports = {
    detailsController: async (req, res) => {
        try{
            const volcano = await getVolcanoById(req.params._id).lean();

            const isCreator = req.user && req.user._id == volcano.owner;
            // const isVoted = req.user && volcano.voteList.includes(req.user._id.toString());
            const isVoted = req.user && volcano.voteList.some(vote => vote._id.toString() === req.user._id.toString());

            console.log(req.user._id)
            res.render('details', {volcano, isCreator, isVoted});
        } catch(err) {
            res.render('404');
        }
    }
}