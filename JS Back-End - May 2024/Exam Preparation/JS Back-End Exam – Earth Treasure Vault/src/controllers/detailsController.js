const { getById } = require("../services/stone");

module.exports = {
    detailsController: async(req, res) => {

        try {
            const stone = await getById(req.params._id).lean();

            const isCreator = req.user && stone.owner == req.user._id;

            const isLiked = req.user && stone.likedList.some(l => l._id == req.user._id);

            //Todo isLike
            res.render('details', {stone, isCreator, isLiked})
        } catch(err){
            res.redirect('/404');
        }
    }
}