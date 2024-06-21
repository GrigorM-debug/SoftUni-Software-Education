const { getAll } = require("../services/stone")

module.exports = {
    homeController: async (req, res) => {
        const stones = await getAll().lean();
        res.render('home', {stones})
    }
}

