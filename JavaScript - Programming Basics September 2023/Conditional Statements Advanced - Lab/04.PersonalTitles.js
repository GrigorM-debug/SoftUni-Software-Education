<<<<<<< HEAD
function personalTitles(input){
    let age = Number(input[0]);
    let gender = input[1];

    if(gender == 'f'){
        if(age >= 16){
            console.log("Ms.")
        }
        else {
            console.log("Miss");
        }
    }
    else if (gender == 'm'){
        if(age >= 16){
            console.log("Mr.");
        }
        else {
            console.log("Master");
        }
    }
}

=======
function personalTitles(input){
    let age = Number(input[0]);
    let gender = input[1];

    if(gender == 'f'){
        if(age >= 16){
            console.log("Ms.")
        }
        else {
            console.log("Miss");
        }
    }
    else if (gender == 'm'){
        if(age >= 16){
            console.log("Mr.");
        }
        else {
            console.log("Master");
        }
    }
}

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
personalTitles(["13.5", "m"]);