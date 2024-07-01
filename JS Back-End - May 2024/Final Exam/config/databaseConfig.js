const mongoose = require('mongoose');

//Add-Database Name
const connectionString = 'mongodb://localhost:27017/home-cooking-recipes';

async function databaseConfig(){
    await mongoose.connect(connectionString);
    console.log('Database connected !');
}

module.exports = {databaseConfig};