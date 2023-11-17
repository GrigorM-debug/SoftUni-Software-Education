function amazonPrime(input){
    let index = 0; 
    let command = input[index]; 
    let stupitNumber = 0; let smartNumber = 0;
    while( command !== "stop"){
        let num = Number(input[index]); 
        index++; 
        if (num < 0){
            console.log('Number is negative.');    
        } else if( num === 0){
            stupitNumber += num;
        } else if ( num !== 2 && num !== 3 && num !== 5 && num !== 7 && (num % 2 === 0 || num % 3 === 0 || num % 5 === 0 || num % 7 === 0
        )){
            smartNumber += num;
        } else{
            stupitNumber += num;
        }
        command = input[index];
    } 
    console.log(`Sum of all prime numbers is: ${stupitNumber}`); 
    console.log(`Sum of all non prime numbers is: ${smartNumber}`);
} 