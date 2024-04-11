function solve(input){
    const astronautsCount = input.shift();

    let astronauts = [];

    for(let i = 0; i < astronautsCount; i++){
        let [name, oxygen, energy] = input[i].split(' ');

        let astronaut = {
            name,
            oxygen: Number(oxygen),
            energy: Number(energy),
        }

        astronauts.push(astronaut);
    }

    let commandLine = input.shift()

    while(commandLine !== 'End'){
        const [command, name, token] = commandLine.split(' - ');

        let currentAstronaut = astronauts.find(astronaut => astronaut.name ===name)
        switch(command){
            case 'Explore':
                let energyNeeded = Number(token);
                if((currentAstronaut.energy - energyNeeded) > 0){
                    currentAstronaut.energy -= energyNeeded;
                    console.log(`${currentAstronaut.name} has successfully explored a new area and now has ${currentAstronaut.energy} energy!`)
                }else{
                    console.log(`${currentAstronaut.name} does not have enough energy to explore!`)
                }
                break;
            case 'Refuel':
                let amountEnergy = Number(token);
                let initialEnergy = currentAstronaut.energy; 
                currentAstronaut.energy += amountEnergy; 

                if (currentAstronaut.energy >= 200) { 
                    currentAstronaut.energy = 200; 
                }

                let energyRefueled = currentAstronaut.energy - initialEnergy;
                console.log(`${currentAstronaut.name} refueled their energy by ${energyRefueled}!`)
                break;
            case 'Breathe':
                let amountOxygen = Number(token);
                let initialOxygen = currentAstronaut.oxygen;
                currentAstronaut.oxygen += amountOxygen;

                if(currentAstronaut.oxygen >= 100){
                    currentAstronaut.oxygen = 100;
                }

                let oxygenRefueled = currentAstronaut.oxygen - initialOxygen;
                console.log(`${currentAstronaut.name} took a breath and recovered ${oxygenRefueled} oxygen!`)
                break;
        }

        commandLine = input.shift();
    }

    for(const astronaut of astronauts){
        console.log(`Astronaut: ${astronaut.name}, Oxygen: ${astronaut.oxygen}, Energy: ${astronaut.energy}`)
    }
}

solve(['4',
    'Alice 60 100',
    'Bob 40 80',
    'Charlie 70 150',
    'Dave 80 180',
    'Explore - Bob - 60',
    'Refuel - Alice - 30',
    'Breathe - Charlie - 50',
    'End']
)