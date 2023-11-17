function sumOfNumbers (input){
    let numA = Number(input[0]); 
    let numB = Number(input[1]); 
    let magicalNumber = Number(input[2]);
    let counter = 0; let breakerA = 0; let breakerB = 0;
    for(let x = numA; x <= numB; x++){    
        for(let y = numA; y <= numB; y++){
            let result = x + y; 
            counter++; 
            if( result === magicalNumber){
             breakerA++; 
             console.log(`Combination N:${counter} (${x} + ${y} = ${magicalNumber})`); 
             break;  
            } else{               
                breakerB++;   
            }
        } 
        if ( breakerA > 0){          
            break;
        } 
    } 
    if (breakerB > 0 && breakerA === 0){
        console.log(`${counter} combinations - neither equals ${magicalNumber}`);
    }
}