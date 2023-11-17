function godzilla(input){ // Godzilla klipa na Eminem ima pove4e gledaniq wee xdd
    let budget = Number(input[0]); 
    let countStatisti = Number(input[1]); 
    let edcenaObleklo = Number(input[2]); 
    const deckor = budget*0.1; 
    let totalPriceObleklo = countStatisti * edcenaObleklo; 
    if (countStatisti > 150){
        totalPriceObleklo *= 0.9;
    } 
    const totalMoney = deckor + totalPriceObleklo;
    if (totalMoney > budget){ 
        let moneyNeeded = totalMoney - budget;
        console.log("Not enough money!") ;
        console.log(`Wingard needs ${(moneyNeeded).toFixed(2)} leva more.`); 

    } else { 
        let moneyLeft = budget - totalMoney;
        console.log("Action!"); 
        console.log(`Wingard starts filming with ${(moneyLeft).toFixed(2)} leva left.`)
    }
} 