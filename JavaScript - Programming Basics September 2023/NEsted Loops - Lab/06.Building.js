function building (input){
    let floors = Number(input[0]); 
    let rooms = Number(input[1]); 
    for(let x = floors; x > 0 ; x --){ 
        let print = '';
        for (let y = 0; y < rooms; y++){ 
            if( x === floors){
                print += `L${x}${y} `; 
                
            } else if (x % 2 === 0){
                print += `O${x}${y} `; 
                
            } else{
                print += `A${x}${y} `; 
                
            }
        } 
        console.log(print); // moje da se dobavi i .trim -> 4isti nenujnite intervali osobeno krainite
    }
}