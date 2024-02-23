function sumDigits(number){
    let sumOfDigits = 0;

    let digits = String(number);
    
    for(let i =0; i < digits.length; i++){
        sumOfDigits += Number(digits[i]);
    }

    console.log(sumOfDigits);
}

sumDigits(245678);