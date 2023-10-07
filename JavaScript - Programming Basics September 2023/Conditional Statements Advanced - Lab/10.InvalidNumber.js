function invalidNumber(input){
    let number = Number(input[0]);

    let inRange = (number >= 100 && number <= 200 || number == 0);
    if (!inRange)
    {
        console.log("invalid");
    }
}

invalidNumber(["0"])