function solve(numbers){
    let oddSum =0;
    let evenSum = 0;

    for(let i = 0; i < numbers.length; i++){
        if(numbers[i] % 2 == 0){
            evenSum += numbers[i];
        } else{
            oddSum += numbers[i];
        }
    }

    console.log(evenSum - oddSum);
}

solve([3,5,7,9]);