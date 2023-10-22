function projectCreation(input){
    let architectName = input[0];
    let numberOfProjects = Number(input[1]);

    let hoursNeededToFinishTheProjects = numberOfProjects * 3;

    console.log(`The architect ${architectName} will need ${hoursNeededToFinishTheProjects} hours to complete ${numberOfProjects} project/s.`);
}

projectCreation(["George ",

"4 "]);