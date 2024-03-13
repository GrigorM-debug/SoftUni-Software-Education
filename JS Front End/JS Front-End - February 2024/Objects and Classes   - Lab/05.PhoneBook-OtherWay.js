function solve(input){
    const phoneBook = {};

    input.forEach(line => {
        const [key, value] = line.split(' ');

        phoneBook[key] = value;
    });

    Object.entries(phoneBook)
            .forEach(([name, address]) => console.log(`${name} -> ${address}`));
}

solve(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']
);