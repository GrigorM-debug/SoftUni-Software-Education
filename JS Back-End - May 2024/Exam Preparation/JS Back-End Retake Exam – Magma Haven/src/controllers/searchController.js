const { getAllVolcanos } = require("../services/volcano");

module.exports = {
    searchController: async (req, res) => {
        const volcanos = await getAllVolcanos().lean();
        let volcanosFiltered = [];
        const volcanoName = req.query.name;
        const volcanoType = req.query.type;

        //Partial search thanks to ChatGpt
        if (volcanoName && !volcanoType) {
            volcanosFiltered = volcanos.filter(v => new RegExp(volcanoName, 'i').test(v.name));
        } else if (!volcanoName && volcanoType) {
            volcanosFiltered = volcanos.filter(v => new RegExp(volcanoType, 'i').test(v.volcanoType));
        } else {
            volcanosFiltered = volcanos.filter(v => new RegExp(volcanoName, 'i').test(v.name) && new RegExp(volcanoType, 'i').test(v.type));
        }

        res.render('search', {volcanos: volcanosFiltered});
    }
}