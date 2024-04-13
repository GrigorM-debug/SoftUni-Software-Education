function solve(input){
    const numberOfHeroes = input.shift();

    const heroes = [];

    for(let i =0; i < numberOfHeroes; i++){
        const [name, HP, bullets] = input[i].split(' ');

        const hero = {
            name,
            HP: Number(HP), 
            bullets: Number(bullets)
        }

        heroes.push(hero)
    }

    let commandLine = input.shift();

    while(commandLine !== 'Ride Off Into Sunset'){
        const [command, name, ...tokens] = commandLine.split(' - ')

        let currHero = heroes.find(hero => hero.name === name);

        switch(command){
            case 'FireShot':
                let target = tokens[0];
                let initialBullets = currHero.bullets;
                if(currHero.bullets > 0){
                    currHero.bullets--;
                    // let bulletsLEft = initialBullets
                    console.log(`${name} has successfully hit ${target} and now has ${currHero.bullets} bullets!`)
                }else{
                    console.log(`${name} doesn't have enough bullets to shoot at ${target}!`)
                }
                break;
            case 'TakeHit':
                let damage = Number(tokens[0]);
                let attacker = tokens[1];

                currHero.HP -= damage;
                if(currHero.HP > 0){
                    console.log(`${name} took a hit for ${damage} HP from ${attacker} and now has ${currHero.HP} HP!`)
                } else{
                    console.log(`${name} was gunned down by ${attacker}!`)
                    
                    const index = heroes.indexOf(currHero);

                    heroes.splice(index, 1);
                }
                break;
            case 'Reload':
                if(currHero.bullets < 6){
                    let initialBullets = currHero.bullets;

                    while(currHero.bullets < 6){
                        currHero.bullets++;
                    }
                    let bulletsReloaded = currHero.bullets - initialBullets;

                    console.log(`${name} reloaded ${bulletsReloaded} bullets!`)
                } else{
                    console.log(`${name}'s pistol is fully loaded!`)
                }
                break;
            case 'PatchUp':
                let amountHP = Number(tokens[0]);

                if(currHero.HP < 100){
                    let hpBefore = currHero.HP;
                    currHero.HP += amountHP;
                    // currHero.HP = Math.min(currHero.HP, 100); 
                    if(currHero.HP > 100){
                        currHero.HP = 100;
                    }
                    let hpRecovered = currHero.HP - hpBefore;
                    console.log(`${name} patched up and recovered ${hpRecovered} HP!`);
                } else{
                    console.log(`${name} is in full health!`)
                }
                break;
        }

        commandLine = input.shift()
    }

    for(const hero of heroes){
        console.log(`${hero.name}`);
        console.log(` HP: ${hero.HP}`)
        console.log(` Bullets: ${hero.bullets}`)
    }
}

solve(["2",
"Jesse 100 4",
"Walt 100 5",
"FireShot - Jesse - Bandit",
 "TakeHit - Walt - 30 - Bandit",
 "PatchUp - Walt - 20" ,
 "Reload - Jesse",
 "Ride Off Into Sunset"])