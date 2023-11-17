function linusTech(input){
    let budget = Number(input[0]); 
    let gpuCount = Number(input[1]); 
    let cpuCount = Number(input[2]); 
    let ramCount = Number(input[3]); 
    const gpuPrice = 250; 
    const totalGpuPrice = gpuPrice * gpuCount; 
    let cpuPrice = totalGpuPrice*0.35; 
    let ramPrice = totalGpuPrice*0.1; 
    const totalRamPrice = ramCount * ramPrice; 
    const totalCpuPrice = cpuCount * cpuPrice; 
    let totalCost = totalGpuPrice + totalRamPrice + totalCpuPrice; 
    
    
    if (gpuCount > cpuCount){
        totalCost *= 0.85;
    }  
    const difference = Math.abs(totalCost - budget).toFixed(2);
    if (totalCost <= budget){ 
        
        console.log(`You have ${difference} leva left!`); 

    } else if (totalCost > budget){
         
        console.log(`Not enough money! You need ${difference} leva more!`);
    }

    
} 