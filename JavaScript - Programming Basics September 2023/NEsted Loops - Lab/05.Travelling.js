function traveler (input){
    let index = 0; 
    let command = input[index]; 
    while(command !== "End"){
        let destination = input[index]; 
        index++;
        let neededSum = Number(input[index]);  
        let money = 0 
       
        while (money < neededSum){ 
            index++;
            money += Number(input[index]);
        } 
        
        console.log(`Going to ${destination}!`); 
        index++;
        command = input[index]; 
    }
} 