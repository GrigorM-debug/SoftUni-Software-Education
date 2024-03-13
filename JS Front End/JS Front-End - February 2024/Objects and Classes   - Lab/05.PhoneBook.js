function solve(input){
    const phoneBook = {};

    for (const line of input) {
        const [key, value] = line.split(' ');
    
        phoneBook[key] = value;
    }

    for (const key in phoneBook) {
        console.log(`${key} -> ${phoneBook[key]}`)
    }
}

solve(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']
);