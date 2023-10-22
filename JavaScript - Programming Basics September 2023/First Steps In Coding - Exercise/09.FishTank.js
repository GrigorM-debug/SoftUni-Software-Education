<<<<<<< HEAD
function fishTank(input){
    let length = Number(input[0]);
    let width = Number(input[1]);
    let height = Number(input[2]);
    let percent = Number(input[3]);

    let volume = length * height * width;
    let volumeInLitres = volume / 1000;
    let litresNeeded = volumeInLitres * (1-(percent / 100));

    console.log(litresNeeded);
}

=======
function fishTank(input){
    let length = Number(input[0]);
    let width = Number(input[1]);
    let height = Number(input[2]);
    let percent = Number(input[3]);

    let volume = length * height * width;
    let volumeInLitres = volume / 1000;
    let litresNeeded = volumeInLitres * (1-(percent / 100));

    console.log(litresNeeded);
}

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
fishTank(["85", "75", "47", "17"]);