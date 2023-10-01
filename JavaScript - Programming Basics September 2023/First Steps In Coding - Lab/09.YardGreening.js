function yardGreening(input){
    let squereMetersToLandScape = Number(input[0]);

    let finaslPrice = squereMetersToLandScape * 7.61;

    let finalPriceWithDiscount = finaslPrice * 0.18;

    console.log(`The final price is: ${finaslPrice - finalPriceWithDiscount} lv.`);
    console.log(`The discount is: ${finalPriceWithDiscount} lv.`);
}

yardGreening(["550"]);
yardGreening(["150"]);