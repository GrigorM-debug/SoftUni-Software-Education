function solve(input){
    const heroes = [];

    for(const line of input){
        const [name, level, items] = line.split(' / ');

        const hero = {
            name,
            level: Number(level),
            items,
        };

        heroes.push(hero);
    }

    heroes.sort((a, b) => a.level - b.level);

    for(const hero of heroes){
        console.log(`Hero: ${hero.name}`)
        console.log(`level => ${hero.level}`)
        console.log(`items => ${hero.items}`)
    }
}

solve([
'Batman / 2 / Banana, Gun',
'Superman / 18 / Sword',
'Poppy / 28 / Sentinel, Antara'
]
    )