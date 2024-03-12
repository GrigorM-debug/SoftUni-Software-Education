function solve(name, lastName, hairColor){
    const person = {
        name,
        lastName,
        hairColor
    }

    const personToString = JSON.stringify(person);

    console.log(personToString);
}

solve('George', 'Jones', 'Brown');