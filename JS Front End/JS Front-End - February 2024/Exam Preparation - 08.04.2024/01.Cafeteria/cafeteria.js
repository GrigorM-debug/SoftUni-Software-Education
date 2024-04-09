function solve(input){
    const baristaCount = Number(input.shift());

    const cafeteria = [];
    // console.log(input)
    for(let i = 0; i < baristaCount; i++){
        const [baristaName, shift, drinks] = input[i].split(' ');

        const barista = {
            baristaName,
            shift,
            drinks: drinks.split(',')
        }

        cafeteria.push(barista)
    }
    
    let commandLine = input.shift();

    while(commandLine != 'Closed'){
        const [command, name, firstArg, secondArg] = commandLine.split(' / ');

        // console.log(arguments[0])
        let shift, coffeType;
        const currBarista = cafeteria.find(barista => barista.baristaName === name);
        switch(command){
            case 'Prepare':
                shift = firstArg;
                coffeType = secondArg;

                if(currBarista.shift === shift && currBarista.drinks.includes(coffeType)){
                    console.log(`${name} has prepared a ${coffeType} for you!`);
                } else{
                    console.log(`${name} is not available to prepare a ${coffeType}.`);
                }
                // console.log(currBarista)
                break;
            case 'Change Shift':
                shift = firstArg;
                currBarista.shift = shift;
                console.log(`${name} has updated his shift to: ${shift}`);
                break;
            case 'Learn':
                coffeType = firstArg
                if(currBarista.drinks.includes(coffeType)){
                    console.log(`${name} knows how to make ${coffeType}.`);
                } else{
                    currBarista.drinks.push(coffeType)
                    console.log(`${name} has learned a new coffee type: ${coffeType}.`)
                }
                break;
        }
        commandLine = input.shift();
    }

    for(const barista of cafeteria){
        console.log(`Barista: ${barista.baristaName}, Shift: ${barista.shift}, Drinks: ${barista.drinks.join(', ')}`)
    }
}

solve([
    '3',
      'Alice day Espresso,Cappuccino',
      'Bob night Latte,Mocha',
      'Carol day Americano,Mocha',
      'Prepare / Alice / night / Espresso',
      'Change Shift / Bob / day',
      'Learn / Carol / Latte',
      'Learn / Bob / Latte',
      'Prepare / Bob / night / Latte',
      'Closed']
    )