function repainting(input){
    let nylonCnt = Number(input[0]);
    let paintLitres = Number(input[1]);
    let thinnerLitres = Number(input[2]);
    let hoursForWork = Number(input[3]);

    let nylonPrice = (nylonCnt + 2) * 1.50;
    let paintPrice = (paintLitres + (paintLitres * 0.10)) * 14.50;
    let thinnerPrice = thinnerLitres * 5.00;

    let totalPrice = nylonPrice + paintPrice + thinnerPrice + 0.40;
    let priceForWorkman = (totalPrice * 0.30) * hoursForWork;

    let finalPrice = totalPrice + priceForWorkman;

    console.log(finalPrice);
}

repainting(["10", "11", "4", "8"]);
repainting(["5", "10", "10", "1"]);