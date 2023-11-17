function sumSeconds(input){
    let sekundiA = Number(input[0]);
    let sekundiB = Number(input[1]); 
    let secundiC = Number(input[2]); 
    const sumarno = sekundiA + sekundiB + secundiC; 
    const minuti = sumarno / 60; 
    const seconds = sumarno % 60; 
    if (seconds >= 10){ 
        console.log(`${Math.floor(minuti)}:${seconds}`);

    }else{
        console.log(`${Math.floor(minuti)}:0${seconds}`);
    }
    // console.log(`${Math.floor(minuti)}:0${seconds}`); 

}