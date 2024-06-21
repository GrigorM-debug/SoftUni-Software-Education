const handlebars = require('express-handlebars');

function hbsConfig(app){
    const hbs = handlebars.create({
        extname: '.hbs',
        helpers: {
            eq: function (a, b) {
                return a === b;
            }
        }
    });

    app.engine('.hbs', hbs.engine);
    app.set('view engine', '.hbs');
}

module.exports = {hbsConfig}