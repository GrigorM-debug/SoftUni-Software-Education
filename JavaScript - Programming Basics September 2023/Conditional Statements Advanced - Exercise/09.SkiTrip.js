function banskoBorovec (input){
    let dniPrestoi = Number(input[0]); 
    let pomeshtenie = input[1]; 
    let score = input[2]; 
    const noshtuvki = dniPrestoi - 1;
    const roomOnePerson = 18 * noshtuvki ; 
    const apartment = 25 * noshtuvki; 
    const presidentApt = 35 * noshtuvki; 
    let totalCost = 0; 

   switch(pomeshtenie){
    case "room for one person" : 
    totalCost = roomOnePerson; break; 
    case "apartment" : 
    if (dniPrestoi < 10){
        totalCost = apartment * 0.70;
    } else if(dniPrestoi >= 10 && dniPrestoi <= 15){
        totalCost = apartment * 0.65; 
    } else if(dniPrestoi > 15){
        totalCost = apartment * 0.50; 
    } 
    break; 
    case "president apartment" : 
    if (dniPrestoi < 10){
        totalCost = presidentApt * 0.90;
    } else if(dniPrestoi >= 10 && dniPrestoi <= 15){
        totalCost = presidentApt * 0.85; 
    } else if(dniPrestoi > 15){
        totalCost = presidentApt * 0.80; 
    } 
    break; 
    }  
    switch(score){
        case "positive" : 
        totalCost *= 1.25; 
        break; 
        case "negative" : 
        totalCost *= 0.90; 
    } 
    console.log(`${totalCost.toFixed(2)}`);
} 