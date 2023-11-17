function minnum (input){
    let index = 0; 
    let element = input[index]; 
    let min = Number.MAX_SAFE_INTEGER; 
    index++; 
    while (element != "Stop"){
        let num = Number(element); 
        if (num < min ){ 
            min = num;
        } 
        element = input[index]; 
        index++;
    } 
    console.log(min); 
} // 100/100
minnum (["100",
"99",
"80",
"70",
"Stop"]);