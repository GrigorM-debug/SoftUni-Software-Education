function operations(input){
    let numberOne = Number(input[0]); 
    let numberTwo = Number(input[1]); 
    let symbol = input[2]; 
    let result = 0; 
    let even = "even"; 
    let odd = "odd" ; 
    let meow = ""
    
     switch (symbol){
            case "+" : 
            result = numberOne + numberTwo; 
            if(result % 2 === 0){  
                meow = even;
            console.log(`${numberOne} ${symbol} ${numberTwo} = ${result} - ${meow}`);  
            } else { 
                meow = odd;
                console.log(`${numberOne} ${symbol} ${numberTwo} = ${result} - ${meow}`);
            } 
            break;  
            
            case "-" : 
            result = numberOne - numberTwo; 
            if(result % 2 === 0){  
                meow = even;
            console.log(`${numberOne} ${symbol} ${numberTwo} = ${result} - ${meow}`);  
            } else { 
                meow = odd;
                console.log(`${numberOne} ${symbol} ${numberTwo} = ${result} - ${meow}`);
            } 
            break; 
            
            case "*" : 
            result = numberOne * numberTwo; 
            if(result % 2 === 0){  
                meow = even;
            console.log(`${numberOne} ${symbol} ${numberTwo} = ${result} - ${meow}`);  
            } else { 
                meow = odd;
                console.log(`${numberOne} ${symbol} ${numberTwo} = ${result} - ${meow}`);
            } 
            break;

        } 
     switch (symbol){
        case "/" : 
        if(numberTwo == 0){
            console.log(`Cannot divide ${numberOne} by zero`); 
        } else{
        result = numberOne / numberTwo;
        console.log(`${numberOne} / ${numberTwo} = ${result.toFixed(2)}`); 
        }
        break; 
        case "%" : 
        if(numberTwo == 0){
            console.log(`Cannot divide ${numberOne} by zero`); 
        } else{
        result = numberOne % numberTwo;
        console.log(`${numberOne} % ${numberTwo} = ${result}`); 
        }
        break;
    }
}