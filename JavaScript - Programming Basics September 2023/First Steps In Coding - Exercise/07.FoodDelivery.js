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
foodDelivery(["9", "2", "6"]);