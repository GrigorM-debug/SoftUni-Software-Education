function solve(input) {

    let days = Number(input[0]);
    
    let hours = Number(input[1]);
    
    let totalCharge = 0;
    
     
    
    for (i = 1; i <= days; i++) {
    
    let hourCharge = 0;
    
    let dayCharge = 0
    
     
    
    for (j = 1; j <= hours; j++) {
    
    if (i % 2 == 0 && j % 2 != 0) {
    
    hourCharge = 2.50;
    
    } else if (i % 2 != 0 && j % 2 == 0) {
    
    hourCharge = 1.25;
    
    } else {
    
    hourCharge = 1;
    
    }
    
    totalCharge += hourCharge;
    
    dayCharge += hourCharge;
    
    }
    
    console.log(`Day: ${i} - ${dayCharge.toFixed(2)} leva`)
    
    }
    
    console.log(`Total: ${totalCharge.toFixed(2)} leva`);
    
    }