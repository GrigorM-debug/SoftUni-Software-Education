const { getAll, getLast3Added } = require("../services/stone")

module.exports = {
    homeController: async (req, res) => {
        const stones = await getLast3Added().lean();
        res.render('home', {stones})
    }
}

