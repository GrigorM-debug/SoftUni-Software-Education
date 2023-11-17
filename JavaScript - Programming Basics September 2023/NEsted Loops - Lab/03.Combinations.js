function combinationOfNumbers (input){
    let number = Number(input[0]); 
    let counter = 0; 
    for (let x = 0; x <= number; x++){
        for(let y = 0; y <= number; y++){
            for(let z = 0; z <= number; z++){
                let result = x + y + z; 
                if(result === number){
                    counter++;
                }
            }
        }
    } 
    console.log(counter);
} 