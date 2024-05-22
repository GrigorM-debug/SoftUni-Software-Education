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

        fs.readFile('../views/addCat.html', (err, data) => {
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
                let json = JSON.stringify(breeds, null, 2);

                fs.writeFile('./data/breeds.json', json, 'utf-8', () => console.log('The new breed was uploaded successfully !'));
            })

            res.writeHead(302, { 'Location': 'http://localhost:3000/' });
            res.end();
        })
    } else if(pathname === '/cats/add-cat' && req.method === 'POST'){
        let form = new formidable.IncomingForm();           // form is used for processing various form data 
        form.parse(req, (err, fields, files) => {           // fields - passing info from form fields, files - from preset formidable
            if (err) throw err;

            // move of the uploaded file (in this case - picture)
            let oldPath = files.upload[0].filepath;                         // taking them from the default formidable folder
            let newPath = path.normalize(path.join(__dirname, "../content/images/" + files.upload[0].originalFilename));
            
            console.log(oldPath);
            console.log(newPath)
            
            fs.rename(oldPath, newPath, (err) => {                   // transfer     
                if (err) throw err;
                console.log("Files was uploaded sccessfully!");
            });

            // Add new object to cats.json
            fs.readFile("./data/cats.json", "utf-8", (err, data) => {
                if (err) throw err;
                let allCats = JSON.parse(data);     
                
                console.log(fields)
                let newCat = { 
                    id: cats.length + 1, 
                    name: fields.name[0],
                    description: fields.description[0],
                    breed: fields.breed[0],
                    image: files.upload[0].originalFilename
                }
                
                allCats.push(newCat)  
                let json = JSON.stringify(allCats, null, 2);                     // set back to JSON
                fs.writeFile("./data/cats.json", json, "utf-8", () => {          // rewrite the original file with the new cat info
                    res.writeHead(302, { 'Location': 'http://localhost:3000/' });
                    res.end();
                })
            })
        })
    } else if (pathname.includes('/cats-edit') && req.method === 'GET'){
        let filePath = path.normalize(path.join(__dirname, "../views/editCat.html"));
        const currentCat = cats[Number(pathname.match(/\d+$/g)) - 1];

        fs.readFile("../views/editCat.html", "utf-8", (err, data) =>{
            if (err) console.log(err)

            let modifiedData = data.toString().replace('{{id}}', currentCat.id);
            modifiedData = modifiedData.replace('{{name}}', currentCat.name);
            modifiedData = modifiedData.replace('{{description}}', currentCat.description);

            let breedsAsOptions = breeds.map((b) => `<option value="${b}">${b}</option>`);
            modifiedData = modifiedData.replace('{{catBreeds}}', breedsAsOptions.join('/'));

            modifiedData = modifiedData.replace('{{breed}}', currentCat.breed);
            res.write(modifiedData);
        })
        res.end()
    } else if (pathname.includes('/cats-find-new-home') && req.method === 'GET'){
        let filePath = path.normalize(path.join(__dirname, "../views/catShelter.html"));
        const currentCat = cats[Number(pathname.match(/\d+$/g)) - 1];

        fs.readFile("../views/catShelter.html", "utf-8", (err, data) =>{
            if (err) console.log(err)

            let modifiedData = data.toString().replace('{{id}}', currentCat.id);
            modifiedData = modifiedData.replace('{{name}}', currentCat.name);
            modifiedData = modifiedData.replace('{{description}}', currentCat.description);

            let breedsAsOptions = breeds.map((b) => `<option value="${b}">${b}</option>`);
            modifiedData = modifiedData.replace('{{catBreeds}}', breedsAsOptions.join('/'));

            modifiedData = modifiedData.replace('{{breed}}', currentCat.breed);
            res.write(modifiedData);
        })
        res.end()
    } else if(pathname.includes('/cats-edit') && req.method === 'POST'){
        let form = new formidable.IncomingForm();           
        form.parse(req, (err, fields, files) => {           
            if (err) throw err;

            // move of the uploaded file (in this case - picture)
            let oldPath = files.upload[0].filepath;                         // taking them from the default formidable folder
            let newPath = path.normalize(path.join(__dirname, "../content/images/" + files.upload[0].originalFilename));
            
            console.log(oldPath);
            console.log(newPath)
            
            fs.rename(oldPath, newPath, (err) => {                   // transfer     
                if (err) throw err;
                console.log("Files was uploaded sccessfully!");
            });

            // Add new object to cats.json
            fs.readFile("./data/cats.json", "utf-8", (err, data) => {
                if (err) throw err;
                let allCats = JSON.parse(data);     
                
                console.log(fields)
                let newCat = { 
                    id: cats.length + 1, 
                    name: fields.name[0],
                    description: fields.description[0],
                    breed: fields.breed[0],
                    image: files.upload[0].originalFilename
                }
                
                allCats.push(newCat)  
                let json = JSON.stringify(allCats, null, 2);                     // set back to JSON
                fs.writeFile("./data/cats.json",json, "utf-8", () => {          // rewrite the original file with the new cat info
                    res.writeHead(302, { 'Location': 'http://localhost:3000/' });
                    res.end();
                })
            })
        })
    } else if (pathname.includes('/cats-find-new-home') && req.method === 'POST'){
        const catId = Number(pathname.match(/\d+$/g)) - 1;

        fs.readFile('./data/cats.json', 'utf-8', (err, data) =>{
            if(err) throw err;

            let cats = JSON.parse(data);
            const catIndex = cats.findIndex(cat => cat.id === catId);
            cats.splice(catIndex, 1);

            let json = JSON.stringify(cats);

            fs.writeFile("./data/cats.json", json, () => {
                res.writeHead(302, { 'Location': 'http://localhost:3000/' });
                res.end();
            })
        })
    } else {
        return true;
    }
};
