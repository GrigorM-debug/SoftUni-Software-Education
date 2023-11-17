function wrswmrc(input){
    let recordS = Number(input[0]); 
    let daljinaM = Number(input[1]); 
    let vremezaMetur = Number(input[2]); 
    let timeNeeded = vremezaMetur * daljinaM; 
    let zabavqne = Math.floor((daljinaM / 15))*12.5; 
    const totalTime = timeNeeded + zabavqne;
    
    if (totalTime < recordS){
        console.log(`Yes, he succeeded! The new world record is ${totalTime.toFixed(2)} seconds.`);
    } else{ 
        let razlika = totalTime - recordS
        console.log(`No, he failed! He was ${razlika.toFixed(2)} seconds slower.`)
    }
} 