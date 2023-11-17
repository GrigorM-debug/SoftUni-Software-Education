function marketForFruits([arg1, arg2, arg3, arg4, arg5]) {
    let strawberriesPrice = Number(arg1);
    let bananasCountKg = Number(arg2);
    let orangesCountKg = Number(arg3);
    let raspberriesCountKg = Number(arg4);
    let strawberriesCountKg = Number(arg5);

    let raspberriesPriceKg = raspberriesCountKg * 24;
    let orangesPriceKg = orangesCountKg - (0.4 * raspberriesCountKg);
    let bananasPriceKg = raspberriesCountKg - (0.8 * raspberriesCountKg);
    let strawberriesPriceKg = raspberriesPrice * 2;
    let raspberriesSum = raspberriesPriceKg * raspberriesCountKg;
    let orangesSum = orangesPriceKg * orangesCountKg;
    let bananasSum = bananasPriceKg * bananasCountKg;
    let strawberriesSum = strawberriesPriceKg * strawberriesCountKg;
    let money = raspberriesSum + orangesSum + bananasSum + strawberriesSum;

    console.log(money);
}