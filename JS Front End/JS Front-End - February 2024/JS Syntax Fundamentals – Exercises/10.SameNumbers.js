function sameNumbers(number){
    let sumOfDigits = 0;

    let digits = String(number);
    
    let firstDigit = digits[0];

    let sameDigits = true;

    for(let i =0; i < digits.length; i++){
        sumOfDigits += Number(digits[i]);

        if(firstDigit !== digits[i]){
            sameDigits = false;
        }
    }
    console.log(sameDigits);
    console.log(sumOfDigits);
}

sameNumbers(2222222);
sameNumbers(1234);