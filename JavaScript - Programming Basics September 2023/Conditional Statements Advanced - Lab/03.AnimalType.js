<<<<<<< HEAD
function animalType(input){
    let animal = input.shift();

    switch(animal){
        case "dog":
            console.log("mammal");
            break;
        case "crocodile":
        case "tortoise":
        case "snake":
            console.log("reptile");
            break;
        default:
            console.log("unknown");
            break;
    }
}


animalType(["dog"]);
=======
function animalType(input){
    let animal = input.shift();

    switch(animal){
        case "dog":
            console.log("mammal");
            break;
        case "crocodile":
        case "tortoise":
        case "snake":
            console.log("reptile");
            break;
        default:
            console.log("unknown");
            break;
    }
}


animalType(["dog"]);
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
