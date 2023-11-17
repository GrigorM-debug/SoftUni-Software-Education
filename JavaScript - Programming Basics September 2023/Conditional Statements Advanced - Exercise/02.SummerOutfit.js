function summeroutfit(input){
    let gradusi = Number(input[0]); 
    let vreme = input[1]; 
    if (gradusi >= 10 && gradusi <= 18){ 
        switch(vreme){
            case 'Morning' : 
            console.log(`It's ${gradusi} degrees, get your Sweatshirt and Sneakers.`); break;
            case 'Afternoon' : 
            console.log(`It's ${gradusi} degrees, get your Shirt and Moccasins.`); break;
            case 'Evening' : 
            console.log(`It's ${gradusi} degrees, get your Shirt and Moccasins.`); break;
        } 
    } else if (gradusi > 18 && gradusi <= 24){
        switch(vreme){
            case 'Morning' : 
            console.log(`It's ${gradusi} degrees, get your Shirt and Moccasins.`); break;
            case 'Afternoon' : 
            console.log(`It's ${gradusi} degrees, get your T-Shirt and Sandals.`); break;
            case 'Evening' : 
            console.log(`It's ${gradusi} degrees, get your Shirt and Moccasins.`); break;
        } 
    } else if (gradusi >= 25){
        switch(vreme){
            case 'Morning' : 
            console.log(`It's ${gradusi} degrees, get your T-Shirt and Sandals.`); break;
            case 'Afternoon' : 
            console.log(`It's ${gradusi} degrees, get your Swim Suit and Barefoot.`); break;
            case 'Evening' : 
            console.log(`It's ${gradusi} degrees, get your Shirt and Moccasins.`); break;
        }
    }
} 