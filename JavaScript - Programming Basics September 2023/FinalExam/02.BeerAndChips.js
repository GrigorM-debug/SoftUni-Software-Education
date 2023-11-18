function beerAndChips(input) {
    let fanName = input[0];
    let budget = Number(input[1]);
    let beerCount = Number(input[2]);
    let chipsCount = Number(input[3]);

    // Цена на една бира
    let beerPrice = 1.20;

    // Обща цена на бирите
    let totalBeerCost = beerCount * beerPrice;

    // Цена на един пакет чипс (45% от общата цена на бирите)
    let chipsPrice = 0.45 * totalBeerCost;

    // Обща цена на чипса (закръглена нагоре)
    let totalChipsCost = Math.ceil(chipsCount * chipsPrice);

    // Обща сума
    let totalCost = totalBeerCost + totalChipsCost;

    // Проверка дали бюджетът е достатъчен
    if (budget >= totalCost) {
        let remainingMoney = (budget - totalCost).toFixed(2);
        console.log(`${fanName} bought a snack and has ${remainingMoney} leva left.`);
    } else {
        let neededMoney = (totalCost - budget).toFixed(2);
        console.log(`${fanName} needs ${neededMoney} more leva!`);
    }
}

// Примери за извикване на функцията с входни данни
beerAndChips(["George", "10", "2", "3"]);
beerAndChips(["Valentin", "5", "2", "4"]);
