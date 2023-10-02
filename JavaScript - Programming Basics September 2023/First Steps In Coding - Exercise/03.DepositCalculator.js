function depositCalculator(input){
    let depositSum = Number(input[0]);
    let termOfDeposit = Number(input[1]);
    let yearInterestRate = Number(input[2]);

    let finalSum = depositSum + termOfDeposit * ((depositSum * yearInterestRate / 100) / 12);

    console.log(finalSum);
}

depositCalculator(["200 ", "3", "5.7 "]);
depositCalculator(["2350", "6", "7"]);