function puppyFood(input) {
    let foodQuantityKg = Number(input[0]);
    let totalFoodGrams = 0;

    for (let i = 1; i < input.length; i++) {
        if (input[i] === "Adopted") {
            break;
        }

        let foodGrams = Number(input[i]);
        totalFoodGrams += foodGrams;
    }

    let leftovers = Math.abs(foodQuantityKg * 1000 - totalFoodGrams);

    if (totalFoodGrams <= foodQuantityKg * 1000) {
        console.log(`Food is enough! Leftovers: ${leftovers} grams.`);
    } else {
        console.log(`Food is not enough. You need ${leftovers} grams more.`);
    }
}

// Примери за извикване на функцията с входни данни
puppyFood(["4", "130", "345", "400", "180", "230", "120", "Adopted"]);
puppyFood(["3", "1000", "1000", "1000", "Adopted"]);
puppyFood(["2", "999", "456", "999", "999", "123", "456", "Adopted"]);
