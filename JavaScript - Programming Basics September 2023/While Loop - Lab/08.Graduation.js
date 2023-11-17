function graduated (input){
    let index = 0; 
    let name = input[0]; 
    let grades = 1; 
    let sum = 0; 
    let excluded = 0;  
    while ( grades <= 12){
        index++; 
        let grade = Number(input[index]); 
        if ( grade < 4){ 
            excluded++; 
            if( excluded > 1){ 
                console.log(`${name} has been excluded at ${grades} grade`);
                break;
            }
            continue;
        } 
        sum += grade; 
        grades++;
    } 
    if (excluded <= 1){
    let average = sum / 12; 
    console.log(`${name} graduated. Average grade: ${average.toFixed(2)}`); 
    }
} // 44/100 1st try ; 100/100 2nd - dobavih edin if
graduated (["Gosho", 
"5",
"5.5",
"6",
"5.43",
"5.5",
"6",
"5.55",
"5",
"6",
"6",
"5.43",
"5"]);