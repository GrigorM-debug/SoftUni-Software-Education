function cookingByNumbers(input, ...commands){
    let number = Number(input);

    for(let i = 0; i<= commands.length; i++){
        if(commands[i] =='chop'){
            number /= 2;
            console.log(number);
        } else if (commands[i] == 'dice'){
            number = Math.sqrt(number);
            console.log(number);
        } else if (commands[i] == 'spice'){
            number += 1;
            console.log(number);
        } else if (commands[i] == 'bake'){
            number *= 3;
            console.log(number);
        } else if (commands[i] == 'fillet'){
            number = number - (number * 0.20);
            console.log(number);
        }
    }
}

cookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');