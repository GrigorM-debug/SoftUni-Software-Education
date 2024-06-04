const express = require('express');
const { hbsConfig } = require('../config/hbsConfig');
const {configExpress} = require('../config/expressConfig');
const { router } = require('../config/routes');
const { databaseConfig } = require('../config/databaseConfig');

const app = express();
const PORT = 3000;

//Making this function because the database must start before the server.
async function start(){
    await configExpress(app);
    hbsConfig(app);
    databaseConfig();
    app.use(router)

    app.listen(PORT, () => console.log(`Server is listening on port: ${PORT}`));
}

start();