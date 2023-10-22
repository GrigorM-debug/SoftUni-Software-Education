<<<<<<< HEAD
function BasketballEquipment(input){
    let yearPayment = Number(input[0]);

    let shoesPrice = yearPayment - (yearPayment * 0.40);  
    let clothesPrice = shoesPrice - (shoesPrice * 0.20);
    let ballPrice = clothesPrice * 1/4;
    let accessoriesPrice = ballPrice * 1/5;

    let finalSum = yearPayment + shoesPrice + clothesPrice + ballPrice + accessoriesPrice;
    console.log(finalSum);
}

BasketballEquipment(["365"]);
=======
function BasketballEquipment(input){
    let yearPayment = Number(input[0]);

    let shoesPrice = yearPayment - (yearPayment * 0.40);  
    let clothesPrice = shoesPrice - (shoesPrice * 0.20);
    let ballPrice = clothesPrice * 1/4;
    let accessoriesPrice = ballPrice * 1/5;

    let finalSum = yearPayment + shoesPrice + clothesPrice + ballPrice + accessoriesPrice;
    console.log(finalSum);
}

BasketballEquipment(["365"]);
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
BasketballEquipment(["550"])