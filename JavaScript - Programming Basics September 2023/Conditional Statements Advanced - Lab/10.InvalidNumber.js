<<<<<<< HEAD
function invalidNumber(input){
    let number = Number(input[0]);

    let inRange = (number >= 100 && number <= 200 || number == 0);
    if (!inRange)
    {
        console.log("invalid");
    }
}

=======
function invalidNumber(input){
    let number = Number(input[0]);

    let inRange = (number >= 100 && number <= 200 || number == 0);
    if (!inRange)
    {
        console.log("invalid");
    }
}

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
invalidNumber(["0"])