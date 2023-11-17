function piramida (input){
    let num = Number(input[0]);  
    let currentNumber = 1; let isBigger = false; 
    let printCurrentLine = '';
    for(let x = 1; x <= num; x++){
        for(let y = 1; y <= x; y++){
            if(currentNumber > num){
                isBigger = true; 
                break;
            } 
            printCurrentLine += currentNumber + ' '; 
            currentNumber++;
        } 
        console.log(printCurrentLine); 
        printCurrentLine = '';
        if(isBigger){
            break;
        }
    } 
} // 100 / 100;