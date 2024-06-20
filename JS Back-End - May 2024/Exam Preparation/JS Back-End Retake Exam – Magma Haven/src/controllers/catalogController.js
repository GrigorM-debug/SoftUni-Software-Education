const { getAllVolcanos } = require("../services/volcano");

module.exports = {
    catalogController: async (req, res) => {
        const volcanos = await getAllVolcanos().lean();
        res.render('catalog', {volcanos});
    }
}