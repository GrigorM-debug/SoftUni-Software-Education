function solve(towns){
    // towns
    // .map(row => row.split('|'))
    // .map(([townName, townLatitude, townLongitude])  => {
    //     return{
    //         town: townName.trim(),
    //         latitude: Number(townLatitude).toFixed(2),
    //         longitude: Number(townLongitude).toFixed(2)
    //     }
    // }
    // ).forEach(town => console.log(town))

    let townsArray = [];

    for(const row of towns){
        const [townName, townLatitude, townLongitude] = row.split(' | ');

        const townsBook = {
            town: townName.trim(), 
            latitude: Number(townLatitude).toFixed(2),
            longitude: Number(townLongitude).toFixed(2),
        };
        
        townsArray.push(townsBook);
    }

    townsArray.forEach(town => console.log(town))
}

solve(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
)