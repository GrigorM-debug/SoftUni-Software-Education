function toyStore(input){
    let cenaEkskurziq = Number(input[0]); 
    let broiPuzeli = Number(input[1]) // * 2.6; 
    let broiKukli = Number(input[2])  // * 3; 
    let broiMechki = Number(input[3]) // * 4.10; 
    let broiMinioni = Number(input[4]) // * 8.20; 
    let broiKamioncheta = Number(input[5]) // * 2; 
    const poruchaniIgrachki = broiPuzeli + broiKukli + broiMechki + broiMinioni + broiKamioncheta; 
    const totalPrice = broiPuzeli*2.6 + broiKukli*3 + broiMechki*4.1 + broiMinioni*8.2 + broiKamioncheta*2;
    let naem = 0;
    let otstupka = 0; 
    // let pechalba = 0;
   
    if ( poruchaniIgrachki >= 50 ){
         otstupka = totalPrice*0.75; 
         naem = otstupka*0.9; 
        // pechalba = otstupka - naem; 
    }else if(poruchaniIgrachki < 50){
         naem = totalPrice*0.9 
        // pechalba = totalPrice - naem;
    } 
    if (naem >= cenaEkskurziq){ 
        console.log(`Yes! ${(naem - cenaEkskurziq).toFixed(2)} lv left.`); 

    } else if (naem < cenaEkskurziq){
        console.log(`Not enough money! ${(cenaEkskurziq - naem).toFixed(2)} lv needed.`);
    }

} 