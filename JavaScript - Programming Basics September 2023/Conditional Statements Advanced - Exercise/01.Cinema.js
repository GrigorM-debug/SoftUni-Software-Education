function kaskataKino(input){
    let tinonino = input[0]; 
    let redove = Number(input[1]); 
    let koloni = Number(input[2]); 
    const premiera = 12; 
    const normalna = 7.5; 
    const discoteka = 5; 
    let pechalba = 0;
    if(tinonino ==="Premiere"){
        pechalba = (redove*koloni*premiera).toFixed(2); 
    }else if( tinonino === "Normal"){
        pechalba = (redove*koloni*normalna).toFixed(2);
    }else if( tinonino === "Discount"){
        pechalba = (redove*koloni*discoteka).toFixed(2);
    } 
    console.log(`${pechalba} leva`);

} 