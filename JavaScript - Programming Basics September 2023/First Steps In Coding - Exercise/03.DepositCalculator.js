<<<<<<< HEAD
function depositCalculator(input){
    let depositSum = Number(input[0]);
    let termOfDeposit = Number(input[1]);
    let yearInterestRate = Number(input[2]);

    let finalSum = depositSum + termOfDeposit * ((depositSum * yearInterestRate / 100) / 12);

    console.log(finalSum);
}

depositCalculator(["200 ", "3", "5.7 "]);
=======
function depositCalculator(input){
    let depositSum = Number(input[0]);
    let termOfDeposit = Number(input[1]);
    let yearInterestRate = Number(input[2]);

    let finalSum = depositSum + termOfDeposit * ((depositSum * yearInterestRate / 100) / 12);

    console.log(finalSum);
}

depositCalculator(["200 ", "3", "5.7 "]);
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
depositCalculator(["2350", "6", "7"]);