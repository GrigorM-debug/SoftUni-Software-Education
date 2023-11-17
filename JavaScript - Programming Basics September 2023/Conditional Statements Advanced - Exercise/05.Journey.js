function journey(input){
    let budget = Number(input[0]); 
    let season = input[1]; 
    let moneySpent = 0; 
    if (budget <= 100){
        console.log('Somewhere in Bulgaria'); 
        switch (season){
            case "summer" : 
            moneySpent = budget * 0.30; 
            console.log(`Camp - ${moneySpent.toFixed(2)}`); break;
            case "winter" : 
            moneySpent = budget * 0.70;  
            console.log(`Hotel - ${moneySpent.toFixed(2)}`); break;
        }
    } else if (budget <= 1000){
        console.log('Somewhere in Balkans'); 
        switch (season){
            case "summer" : 
            moneySpent = budget * 0.40;  
            console.log(`Camp - ${moneySpent.toFixed(2)}`); break;
            case "winter" : 
            moneySpent = budget * 0.80;  
            console.log(`Hotel - ${moneySpent.toFixed(2)}`); break;
        }
    } else if (budget > 1000){
        console.log('Somewhere in Europe'); 
        moneySpent = budget * 0.90; 
        switch (season){
            case "summer" : 
            moneySpent = budget * 0.90;  
            console.log(`Hotel - ${moneySpent.toFixed(2)}`); break;
            case "winter" : 
            moneySpent = budget * 0.90;  
            console.log(`Hotel - ${moneySpent.toFixed(2)}`); break;
        }
    }
} 