function equalSumsEvenOddPosition (input){
    let startNumber = Number(input[0]); 
    let endNumber = Number(input[1]);  
    let printer = '';
    for( let x = startNumber; x <= endNumber; x++){
        let currentNumber ='' + x; 
        let oddSum = 0; 
        let evenSumm = 0;  
        for(let y = 0; y < currentNumber.length; y++){ 
            let currentSymbol = Number(currentNumber.charAt(y)); 
            if ( y % 2 === 0){
                evenSumm += currentSymbol;
            } else{
                oddSum += currentSymbol;
            }
        } 
        if ( oddSum === evenSumm){
            printer += `${x} `;
        }
    }  
    console.log(printer);
} 