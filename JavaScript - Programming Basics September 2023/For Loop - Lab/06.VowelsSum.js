function vowelsSum([input]){
    let sum = 0;

    for(let i = 0; i < input.length; i++){
        if(input[i] == 'a'){
            sum += 1;
        }
        else if(input[i] == 'e'){
            sum += 2;
        }
        else if(input[i] == 'i'){
            sum += 3;
        }
        else if (input[i] == 'o'){
            sum += 4;
        }
        else if(input[i] == 'u'){
            sum += 5;
        }
    }

    console.log(sum);
}

vowelsSum(["hello"]);