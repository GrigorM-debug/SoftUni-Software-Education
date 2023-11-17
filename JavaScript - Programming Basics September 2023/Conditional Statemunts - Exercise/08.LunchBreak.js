function obqd(input){
    let serialName = input[0]; 
    let vremeEpizod = Number(input[1]); 
    let vremeZaPochivka = Number(input[2]); 
    const vremeZaObqd = (vremeZaPochivka*1)/8; 
    const vremeZaOtdih =(vremeZaPochivka*1)/4; 
    const timeLeft =Math.abs(vremeZaPochivka - (vremeZaObqd + vremeZaOtdih)); 
    if (timeLeft >= vremeEpizod){ 
        let nqkvovremetam = Math.abs(timeLeft - vremeEpizod);
        console.log(`You have enough time to watch ${serialName} and left with ${Math.ceil(nqkvovremetam)} minutes free time.`); 
    } else if(timeLeft < vremeEpizod){ 
        let drugovreme =Math.abs(vremeEpizod - timeLeft); 
        console.log(`You don't have enough time to watch ${serialName}, you need ${Math.ceil(drugovreme)} more minutes.`);
    }

} 