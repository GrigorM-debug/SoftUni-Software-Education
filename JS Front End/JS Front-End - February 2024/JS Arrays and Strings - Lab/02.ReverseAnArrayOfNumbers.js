function solve(num, numbers){
    let newArray = [];

    for(let i = 0; i < num; i++){
        newArray.push(numbers[i]);
    }

    let output = '';

    for(let i = newArray.length - 1; i >= 0; i--){
        output += ` ${newArray[i]}`;
    }

    console.log(output);
}

solve(2, [66, 43, 75, 89, 47]);