function trumpHotel(input){
    let month = input[0];
    let noshtuvki = Number(input[1]); 
    let stdCost = 0;  
    let aptCost = 0; 
    let finalSumA = 0 /*студио*/; let finalSumB = 0/*апартамент*/; 
    switch(month){
        case "May" : 
        case "October" :
            stdCost = 50; 
            aptCost = 65; 
            finalSumA = stdCost * noshtuvki; 
            finalSumB = aptCost * noshtuvki;  
            if (noshtuvki > 7 && noshtuvki <= 14){
                finalSumA = stdCost * noshtuvki * 0.95; 
                
            } else if(noshtuvki > 14){
                finalSumB = aptCost * noshtuvki * 0.90; 
                finalSumA = stdCost * noshtuvki * 0.70;
            } 
        break; 
        case "June" : 
        case "September" : 
        stdCost = 75.20; 
        aptCost = 68.70; 
            finalSumA = stdCost * noshtuvki; 
            finalSumB = aptCost * noshtuvki; 
        if(noshtuvki > 14){
            finalSumB = aptCost * noshtuvki * 0.90; 
            finalSumA = stdCost * noshtuvki * 0.80; 
        } 
        break; 
        case "July" : 
        case "August" : 
        stdCost = 76; 
        aptCost = 77;  
        finalSumA = stdCost * noshtuvki; 
            finalSumB = aptCost * noshtuvki;
        if(noshtuvki > 14){
            finalSumB = aptCost * noshtuvki * 0.90; 
            finalSumA = stdCost * noshtuvki ;
        } 
        break; 
    }  
    
    console.log(`Apartment: ${finalSumB.toFixed(2)} lv.`); 
    console.log(`Studio: ${finalSumA.toFixed(2)} lv.`);

} 