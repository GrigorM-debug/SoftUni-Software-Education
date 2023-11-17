function multiplicationTable(input){
    let y = Number(input[0]);

    for (let x = 1; x <= 10; x++){

        let product = x * y;

        console.log(`${x} * ${y} = ${product}`);
    }
}
multiplicationTable(["5"])