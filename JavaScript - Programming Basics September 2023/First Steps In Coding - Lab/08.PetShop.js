function petShop(input){
    let numberOfPacketsForDogs = Number(input[0]);
    let numberOfPacketsForCats = Number(input[1]);

    let finalSum = (numberOfPacketsForDogs * 2.50) + (numberOfPacketsForCats * 4);

    console.log(finalSum + " lv.");
}

petShop(["5", "4"]);
petShop(["13", "9"]);