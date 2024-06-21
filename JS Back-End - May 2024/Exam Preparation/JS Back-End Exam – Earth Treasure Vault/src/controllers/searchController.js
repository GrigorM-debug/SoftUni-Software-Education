const { getAll } = require("../services/stone");

module.exports = {
    searchController: async (req, res) => {
        const stones = await getAll().lean();
        let stonesFiltered = [];
        const stoneName = req.query.name;
        
        console.log(stoneName)

        //Partial search thanks to ChatGpt
        if (stoneName) {
            stonesFiltered = stones.filter(s => new RegExp(stoneName, 'i').test(s.name));
        } else {
            stonesFiltered = stones; // No filters applied, return empty array
        }

        res.render('search', { stones: stonesFiltered});
    }
}