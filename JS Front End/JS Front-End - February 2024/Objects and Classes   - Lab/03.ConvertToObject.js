function solve(input){
    const stringToObj = JSON.parse(input);

    for (const key in stringToObj) {
        console.log(`${key}: ${stringToObj[key]}`)
    }
}

solve('{"name": "George", "age": 40, "town": "Sofia"}');