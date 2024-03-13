function solve(input){
    const addressBook = {};

    for(const line of input){
        const [name, address] = line.split(':');

       addressBook[name] = address;
    }

    // Object.entries(addressBook)
    //     .sort((a, b) => a[0].localeCompare(b[0]))
    //     .forEach(([name, address]) => console.log(`${name} -> ${address}`));

    const entries = Object.entries(addressBook)
                    .sort((a, b) => a[0].localeCompare(b[0]));

    for (const entry of entries) {
        const [key, value] = entry;

        console.log(`${key} -> ${value}`);
    }
}

solve(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
);