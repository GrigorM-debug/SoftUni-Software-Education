function solve(input){
    let meetings = {};

    for (const line of input) {
        const [day, name] = line.split(' ');

        if(meetings[day]){
            console.log(`Conflict on ${day}!`);
        } else{
            meetings[day] = name;
            console.log(`Scheduled for ${day}`);
        }
    }

    // Object.entries(meetings).forEach(([day, name]) => console.log(`${day} -> ${name}`));

    for(const key in meetings){
        console.log(`${key} -> ${meetings[key]}`);
    }
}

solve(['Friday Bob',
'Saturday Ted',
'Monday Bill',
'Monday John',
'Wednesday George']
);