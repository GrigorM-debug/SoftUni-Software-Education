
function ribnaFiesta(input){
    let budget = Number(input[0]); 
    let season = input[1]; 
    let fishermanCount = Number(input[2]); 
    const shipPriceSpring = 3000; 
    const shipPriceSummer = 4200; 
    const shipPriceWinter = 2600; 
    let finalPrice = 0;
    switch (season){
        case "Spring" : 
        finalPrice = shipPriceSpring; break; 
        case "Summer" : 
        finalPrice = shipPriceSummer; break; 
        case "Autumn" : 
        finalPrice = shipPriceSummer; break; 
        case "Winter" : 
        finalPrice = shipPriceWinter; break; 
    } 
    if (fishermanCount <= 6 ){
        finalPrice *= 0.9; 
    } else if (fishermanCount > 7 && fishermanCount <= 11){
        finalPrice *= 0.85; 
    } else if (fishermanCount >11){
        finalPrice *= 0.75;
    } 
    if (fishermanCount % 2 === 0 && season != "Autumn"){
        finalPrice *= 0.95;
    } 
    if (finalPrice <= budget){
        let resto = (budget - finalPrice).toFixed(2); 
        console.log(`Yes! You have ${resto} leva left.`);
    } else if ( finalPrice > budget){
        let nedostig = (finalPrice - budget).toFixed(2); 
        console.log(`Not enough money! You need ${nedostig} leva.`);
    } 

        
    
}  