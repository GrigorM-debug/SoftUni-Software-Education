function izpitTime (input){
    let chasIzpita = Number(input[0]); 
    let minutaIzpita = Number(input[1]); 
    let arrivalHour = Number(input[2]); 
    let arrivalMin = Number(input[3]); 
    const allMinutesStart = chasIzpita*60 + minutaIzpita; // входните данни за старт на изпита превърнати само в минути
    const allMunitesArive = arrivalHour*60 + arrivalMin; // входни данни за пристигане в минути 
    if ( allMinutesStart < allMunitesArive){ 
        console.log("Late");
        let zakusnenie = allMunitesArive - allMinutesStart;  
        if(zakusnenie < 60){
            console.log(`${zakusnenie} minutes after the start`) 
        }else if (zakusnenie == 60){
                let pechatH = zakusnenie / 60; 
                console.log(`${pechatH}:00 hours after the start`)
              
        }else if(zakusnenie > 60){
        let pechatH = Math.floor(zakusnenie / 60); 
        let pechatM = (zakusnenie % 60); 
          if (pechatM < 10){
            console.log(`${pechatH}:0${pechatM} hours after the start`)   
          } else{
            console.log(`${pechatH}:${pechatM} hours after the start`); 
        }  
    }
    
    
     }else if ( allMinutesStart > allMunitesArive){ 
        
        let podranqvane = allMinutesStart - allMunitesArive; 
          if(podranqvane <= 30){
            console.log("On time"); 
          } else{
            console.log("Early");
          } 
          if(podranqvane < 60){
            console.log(`${podranqvane} minutes before the start`)  
          }else if (podranqvane == 60){
            let pechatH = podranqvane / 60; 
            console.log(`${pechatH}:00 hours before the start`)
          }
          else{
        let pechatH = Math.floor(podranqvane / 60); 
        let pechatM = (podranqvane % 60); 
             if (pechatM < 10){
            console.log(`${pechatH}:0${pechatM} hours before the start`); 
             }else{
                console.log(`${pechatH}:${pechatM} hours before the start`);
            }
        }  
    } else if ( allMinutesStart == allMunitesArive){ 
        console.log("On time"); 
    }
       
} 