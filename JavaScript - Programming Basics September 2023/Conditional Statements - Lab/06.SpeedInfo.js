<<<<<<< HEAD
function speedInfo(input){
    let speed = Number(input[0]);

    if(speed <= 10){
        console.log("slow");
    }
    else if(speed > 10 && speed <= 50){
        console.log("average");
    }
    else if(speed > 50 && speed <= 150){
        console.log("fast");
    }
    else if(speed > 150 && speed <= 1000){
        console.log("ultra fast");
    }
    else{
        console.log("extremely fast");
    }
}

speedInfo(["8"]);
speedInfo(["49.5"]);
speedInfo(["126"]);
speedInfo(["160"]);
=======
function speedInfo(input){
    let speed = Number(input[0]);

    if(speed <= 10){
        console.log("slow");
    }
    else if(speed > 10 && speed <= 50){
        console.log("average");
    }
    else if(speed > 50 && speed <= 150){
        console.log("fast");
    }
    else if(speed > 150 && speed <= 1000){
        console.log("ultra fast");
    }
    else{
        console.log("extremely fast");
    }
}

speedInfo(["8"]);
speedInfo(["49.5"]);
speedInfo(["126"]);
speedInfo(["160"]);
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
speedInfo(["3500"]);