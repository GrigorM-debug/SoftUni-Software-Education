function concatenateData(input){
    let name = input[0];
    let fname = input[1];
    let age = Number(input[2]);
    let city = input[3];

    console.log(`You are ${name} ${fname}, a ${age}-years old person from ${city}.`);
}

concatenateData(['Maria', 'Ivanova', 20, 'Sofia']);