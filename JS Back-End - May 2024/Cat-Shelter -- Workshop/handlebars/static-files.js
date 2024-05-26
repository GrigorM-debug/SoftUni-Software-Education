const url = require('url');
const fs = require('fs');
const path = require('path');

module.exports = (req, res) => {
    const pathname = url.parse(req.url).pathname;

    if (pathname.startsWith('/content') && req.method === 'GET') {
        const filePath = path.normalize(
            path.join(__dirname, `..${pathname}`)
        );

        fs.readFile(filePath, (err, data) => {
            if (err) {
                console.log(err);
                res.writeHead(404, { 'Content-Type': 'text/plain' });
                res.write('404 file not found');
                res.end();
                return;
            }

            res.writeHead(200, { 'Content-Type': getContentType(pathname) });
            res.write(data);
            res.end();
        });

        return true; 
    } else if(pathname.endsWith('png') || pathname.endsWith('jpg') || pathname.endsWith('jpeg') || pathname.endsWith('ico') && req.method === 'GET'){

        fs.readFile(`./${pathname}`, (err, data) => {
            if (err) {
                console.log(err);
                res.writeHead(404, { 'Content-Type': 'text/plain' });
                res.write('404 file not found');
                res.end();
                return;
            }

            res.writeHead(200, { 'Content-Type': getContentType(pathname) });
            res.write(data);                
            res.end();
        });
        return true;
    }

    return false; 
};

function getContentType(url) {
    if (url.endsWith('.css')) {
        return 'text/css';
    } else if (url.endsWith('js')) {
        return 'application/javascript';
    } else if (url.endsWith('.html')) {
        return 'text/html';
    } else if (url.endsWith('jpg') || url.endsWith('jpeg')) {
        return 'image/jpeg';
    } else if (url.endsWith('png')) {
        return 'image/png';
    } else if(url.endsWith('ico')) {
        return 'image/x-icon';
    } else {
        return 'application/octet-stream'; // Default content type for unknown file types
    }
}
