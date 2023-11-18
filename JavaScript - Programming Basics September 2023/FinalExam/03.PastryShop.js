function pastryShop(input) {
    let sweetType = input[0];
    let quantity = Number(input[1]);
    let day = Number(input[2]);

    let pricePerUnit = 0;

    switch (sweetType) {
        case "Cake":
            if (day <= 15) {
                pricePerUnit = 24;
            } else {
                pricePerUnit = 28.70;
            }
            break;
        case "Souffle":
            if (day <= 15) {
                pricePerUnit = 6.66;
            } else {
                pricePerUnit = 9.80;
            }
            break;
        case "Baklava":
            if (day <= 15) {
                pricePerUnit = 12.60;
            } else {
                pricePerUnit = 16.98;
            }
            break;
    }

    let totalPrice = pricePerUnit * quantity;

    if (day <= 22) {
        if (totalPrice >= 100 && totalPrice <= 200) {
            totalPrice *= 0.85; // 15% отстъпка
        } else if (totalPrice > 200) {
            totalPrice *= 0.75; // 25% отстъпка
        }
    }

    if (day <= 15) {
        totalPrice *= 0.9; // 10% отстъпка
    }

    console.log(totalPrice.toFixed(2));
}

// Примери за извикване на функцията с входни данни
pastryShop(["Cake", "10", "15"]);
pastryShop(["Souffle", "20", "24"]);
pastryShop(["Baklava", "50", "1"]);
pastryShop(["Cake", "5", "12"]);