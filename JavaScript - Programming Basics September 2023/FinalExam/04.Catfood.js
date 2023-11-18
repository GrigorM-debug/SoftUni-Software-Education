function catFood(input) {
    let catsCount = Number(input[0]);
    let smallCatsCount = 0;
    let mediumCatsCount = 0;
    let largeCatsCount = 0;
    let totalPrice = 0;

    for (let i = 1; i <= catsCount; i++) {
        let foodGrams = Number(input[i]);

        if (foodGrams >= 100 && foodGrams < 200) {
            smallCatsCount++;
        } else if (foodGrams >= 200 && foodGrams < 300) {
            mediumCatsCount++;
        } else if (foodGrams >= 300 && foodGrams <= 400) {
            largeCatsCount++;
        }

        totalPrice += (foodGrams / 1000) * 12.45;
    }

    console.log(`Group 1: ${smallCatsCount} cats.`);
    console.log(`Group 2: ${mediumCatsCount} cats.`);
    console.log(`Group 3: ${largeCatsCount} cats.`);
    console.log(`Price for food per day: ${totalPrice.toFixed(2)} lv.`);
}

// Example usage:
//catFood(["6", "102", "236", "123", "399", "342", "222"]);
catFood(["10", "256", "348", "198", "322", "186", "294", "321", "100", "200", "300"]);
catFood(["7", "100", "200", "342", "300", "234", "123", "212"]);
