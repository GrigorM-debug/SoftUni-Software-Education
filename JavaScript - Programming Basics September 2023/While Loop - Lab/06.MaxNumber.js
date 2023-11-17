function maxnum (input){
    let index = 0; 
    let element = input[index]; 
    index++; 
    let max = Number.MIN_SAFE_INTEGER; 
    while(element !== "Stop"){
        let num = Number(element); 
        if (num > max){
            max = num;
        } 
        element = input[index]; 
        index++;
    } 
    console.log(max);
} 
maxnum(["100", "99","80","70","Stop"]); //100/100
maxnum(["-10","20","-30","Stop"]); // намира най-голямото число от масив от числа