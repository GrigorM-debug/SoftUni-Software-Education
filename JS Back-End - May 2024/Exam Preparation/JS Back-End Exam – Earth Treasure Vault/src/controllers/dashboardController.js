const { getAll } = require("../services/stone")

module.exports ={
    dashboardController: async (req, res) => {
        const stones = await getAll().lean();

        res.render('dashboard', {stones});
    }
}