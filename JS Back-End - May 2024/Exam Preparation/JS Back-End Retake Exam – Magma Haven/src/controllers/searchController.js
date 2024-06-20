const { getAllVolcanos } = require("../services/volcano");

module.exports = {
    searchController: async (req, res) => {
        const volcanosSearch = await getAllVolcanos().lean();
        let volcanosFiltered = [];
        const volcanoName = req.query.name;
        const volcanoType = req.query.type;

        //Partial search thanks to ChatGpt
        if (volcanoName && !volcanoType) {
            volcanosFiltered = volcanosSearch.filter(v => new RegExp(volcanoName, 'i').test(v.name));
        } else if (!volcanoName && volcanoType) {
            volcanosFiltered = volcanosSearch.filter(v => new RegExp(volcanoType, 'i').test(v.typeVolcano));
        } else if (volcanoName && volcanoType) {
            volcanosFiltered = volcanosSearch.filter(v => 
                new RegExp(volcanoName, 'i').test(v.name) && 
                new RegExp(volcanoType, 'i').test(v.typeVolcano)
            );
        } else {
            volcanosFiltered = []; // No filters applied, return empty array
        }

        res.render('search', {volcanos: volcanosFiltered});
    }
}