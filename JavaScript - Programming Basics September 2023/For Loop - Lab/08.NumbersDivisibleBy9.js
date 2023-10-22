<<<<<<< HEAD
function sumofNumbersDivisibleBy9(input){
    let start = Number(input[0]);
    let end = Number(input[1]);

    let sum = 0;

    for(let j = start; j <= end; j++){
        if(j % 9 == 0){
            sum += j;
        }
    }

    console.log(`The sum: ${sum}`)

    for(let i = start; i <= end; i++){
        if(i % 9 == 0){
            console.log(i);
        }
    }
}

=======
function sumofNumbersDivisibleBy9(input){
    let start = Number(input[0]);
    let end = Number(input[1]);

    let sum = 0;

    for(let j = start; j <= end; j++){
        if(j % 9 == 0){
            sum += j;
        }
    }

    console.log(`The sum: ${sum}`)

    for(let i = start; i <= end; i++){
        if(i % 9 == 0){
            console.log(i);
        }
    }
}

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
sumofNumbersDivisibleBy9(["100", "200"])