function moonTrip(input) {
    let speed = Number(input[0]);
    let fuelConsumption = Number(input[1]);

    // Разстояние до Луната (отиване и връщане)
    let totalDistance = 384400 * 2;

    // Време за отиване и връщане в часове (закръглено към горе)
    let totalHours = Math.ceil(totalDistance / speed);

    // Общо време, включително прекараното време на Луната
    let totalTime = totalHours + 3;

    // Количеството гориво, необходимо за пътуването
    let fuelNeeded = (fuelConsumption * totalDistance) / 100;

    console.log(totalTime);
    console.log(fuelNeeded);
}
