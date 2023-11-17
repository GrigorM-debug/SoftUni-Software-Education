function bonusPoints(input){
    let nachalenBroi = Number(input[0]); 
    let bonus = 0;
    if (nachalenBroi <= 100){
        bonus = 5;
    } else if (nachalenBroi <= 1000){
        bonus = nachalenBroi*0.2;
    } else  {
        bonus = nachalenBroi*0.1; 
    } 
    if (nachalenBroi % 2 == 0){
        bonus += 1;
    } else if (nachalenBroi % 10 == 5){
        bonus += 2;
    }

    console.log(bonus); 
    console.log(nachalenBroi + bonus); 
} 