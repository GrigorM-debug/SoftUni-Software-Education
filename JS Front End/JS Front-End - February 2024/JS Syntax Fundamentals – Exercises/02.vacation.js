function vacation(peopleCnt, group, dayOfWeek){
    let price;

   switch(group){
        case "Students":
            switch(dayOfWeek){
                case 'Friday':
                    price = peopleCnt * 8.45;
                    if(peopleCnt >= 30){
                        price = price - price * 0.15;
                    }
                    break;
                case 'Saturday':
                    price = peopleCnt * 9.80;
                    if(peopleCnt >= 30){
                        price = price - price * 0.15;
                    }
                    break;
                case 'Sunday':
                    price = peopleCnt * 10.46;
                    if(peopleCnt >= 30){
                        price = price - price * 0.15;
                    } 
                    break;
            } 
            break;
        case "Business":
            if(peopleCnt >= 100){
                peopleCnt -=10;
            }
            switch(dayOfWeek){
                case 'Friday':
                    price = peopleCnt * 10.90;
                    break;
                case 'Saturday':
                    price = peopleCnt * 15.60;
                    break;
                case 'Sunnday':
                    price = peopleCnt * 16;
                    break;
            }
            break;
        case "Regular":
            switch(dayOfWeek){
                case 'Friday':
                    price = peopleCnt * 15;
                    if(peopleCnt >= 10 && peopleCnt <= 20){
                        price = price - price * 0.05;
                    }
                    break;
                case 'Saturday':
                    price = peopleCnt * 20;
                    if(peopleCnt >= 10 && peopleCnt <= 20){
                        price = price - price * 0.05;
                    }
                    break;
                case 'Sunday':
                    price = peopleCnt * 22.50;
                    if(peopleCnt >= 10 && peopleCnt <= 20){
                        price = price - price * 0.05;
                    } 
                    break;
                // console.log(`Total price: ${price}`);
            }
            break;
   } 
   console.log(`Total price: ${price.toFixed(2)}`);
}

vacation(80, "Business", "Friday");
