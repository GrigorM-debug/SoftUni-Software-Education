function fruits(fruit, weight, money){
    let weightToKg = weight / 1000;
    let price = money * weightToKg;

    console.log(`I need $${price.toFixed(2)} to buy ${weightToKg.toFixed(2)} kilograms ${fruit}.`);
}

fruits('apple', 1563, 2.35);