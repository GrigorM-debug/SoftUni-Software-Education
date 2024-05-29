const express = require('express');
const { hbsConfig } = require('../config/hbsConfig');
const {configExpress} = require('../config/expressConfig');
const { router } = require('../config/routes');

const app = express();
const PORT = 3000;

configExpress(app);
hbsConfig(app);
app.use(router)

app.listen(PORT, () => console.log(`Server is listening on port: ${PORT}`));