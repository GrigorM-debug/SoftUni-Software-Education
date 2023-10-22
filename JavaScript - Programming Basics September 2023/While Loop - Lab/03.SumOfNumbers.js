function sumOfNumbers(input){
    let number = Number(input[0]);
    let index = 1;
    let sum = 0;

    while (sum != number){
        sum += Number(input[index]);
        index++;
        if(sum == number){
            break;
        }
    }

    console.log(sum);
}

sumOfNumbers((["20",
"1",
"2",
"3",
"4",
"5",
"6"])
)