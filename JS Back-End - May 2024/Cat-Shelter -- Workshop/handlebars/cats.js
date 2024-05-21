const url = require('url');
const fs = require('fs');
const path = require('path');
const qs = require('querystring');
const formidable = require('formidable');
const breeds = require('../data/breeds.json');
const cats = require('../data/cats.json');

module.exports = (req, res) => {
    const pathname = url.parse(req.url).pathname;

    if (pathname === '/cats/add-breed' && req.method === 'GET') {
        const filePath = path.normalize(
            path.join(__dirname, '../views/addBreed.html')
        );

        fs.readFile(filePath, (err, data) => {
            if (err) {
                console.log(err);
                res.writeHead(404, { 'Content-Type': 'text/plain' });
                res.write('404 file not found');
                res.end();
                return;
            }

            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.write(data);
            res.end();
        });
    } else if (pathname === '/cats/add-cat' && req.method === 'GET') {
        const filePath = path.normalize(
            path.join(__dirname, '../views/addCat.html')
        );

        fs.readFile(filePath, (err, data) => {
            if (err) {
                console.log(err);
                res.writeHead(404, { 'Content-Type': 'text/plain' });
                res.write('404 file not found');
                res.end();
                return;
            }

            let catBreedsPalceHolder = breeds.map((breed) => `<option value="${breed}">${breed}</option>`);
            let modifiedData = data.toString().replace('{{catBreeds}}', catBreedsPalceHolder);

            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.write(modifiedData);
            res.end();
        });
    } else if(pathname === '/cats/add-breed' && req.method === 'POST'){
        let formData = '';

        req.on('data', (data) => {
            formData += data;
        });

        req.on('end', () =>{
            let body = qs.parse(formData)
            
            fs.readFile('./data/breeds.json', (err, data) =>{
                if(err){
                    throw err;
                }

                let breeds = JSON.parse(data); //Taking the breeds as array
                breeds.push(body.breed);
                let json = JSON.stringify(breeds);

                fs.writeFile('./data/breeds.json', json, 'utf-8', () => console.log('The new breed was uploaded successfully !'));
            })

            res.writeHead(302, { 'Location': 'http://localhost:3000/' });
            res.end();
        })
    } else if(pathname === '/cats/add-cat' && req.method === 'POST'){

    } else {
        return true;
    }
};
