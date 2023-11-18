function safari(input) {
 
    let budget = Number(input.shift());
    let liters = Number(input.shift());
    let day = input.shift();
 
    let fuelPerLiterCost = 2.10;
    let guideCost = 100;
 
    let totalCost = (liters * fuelPerLiterCost) + guideCost;
 
    if (day === "Saturday") {
        totalCost *= 0.90;
    } else if (day === "Sunday") {
        totalCost *= 0.80;
    }
 
    let difference = Math.abs(budget - totalCost);
 
    if (budget >= totalCost) {
        console.log(`Safari time! Money left: ${difference.toFixed(2)} lv.`);
    } else if (budget < totalCost) {
        console.log(`Not enough money! Money needed: ${difference.toFixed(2)} lv.`);
    }
}