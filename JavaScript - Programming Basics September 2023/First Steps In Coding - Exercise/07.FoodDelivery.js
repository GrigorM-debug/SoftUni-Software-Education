<<<<<<< HEAD
function foodDelivery(input){
    let chickenMenuCnt = Number(input[0]);
    let fishMenuCnt = Number(input[1]);
    let vegetarianMenuCnt = Number(input[2]);

    let chickenMenuPrice = chickenMenuCnt * 10.35;
    let fishMenuPrice = fishMenuCnt * 12.40;
    let vegetarianMenuPrice = vegetarianMenuCnt * 8.15;

    let totalPrice = chickenMenuPrice + fishMenuPrice + vegetarianMenuPrice;
    let dessertPrice = totalPrice * 0.20;

    let finalPrice = totalPrice + dessertPrice + 2.50;

    console.log(finalPrice);
}

foodDelivery(["2", "4", "3"]);
=======
function foodDelivery(input){
    let chickenMenuCnt = Number(input[0]);
    let fishMenuCnt = Number(input[1]);
    let vegetarianMenuCnt = Number(input[2]);

    let chickenMenuPrice = chickenMenuCnt * 10.35;
    let fishMenuPrice = fishMenuCnt * 12.40;
    let vegetarianMenuPrice = vegetarianMenuCnt * 8.15;

    let totalPrice = chickenMenuPrice + fishMenuPrice + vegetarianMenuPrice;
    let dessertPrice = totalPrice * 0.20;

    let finalPrice = totalPrice + dessertPrice + 2.50;

    console.log(finalPrice);
}

foodDelivery(["2", "4", "3"]);
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
foodDelivery(["9", "2", "6"]);