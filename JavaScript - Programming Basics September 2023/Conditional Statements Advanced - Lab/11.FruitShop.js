<<<<<<< HEAD
function fruitShop(input){
    let fruit = input[0];
    let day = input[1];
    let count = input[2];
    let price = 0;

    switch(day){
        case "Monday":
        case "Tuesday":
        case "Wednesday":
        case "Thursday":
        case "Friday":
            switch (fruit){
                case "banana":
                    price = count * 2.50;
                    break;
                case "apple":
                    price = count * 1.20;
                    break;
                case "orange":
                    price = count * 0.85;
                    break;
                case "grapefruit":
                    price = count * 1.45;
                    break;
                case "kiwi":
                    price = count * 2.70;
                    break;
                case "pineapple":
                    price = count * 5.50;
                    break;
                case "grapes":
                    price = count * 3.85;
                    break;

                default:
                    console.log("error");
                    break;
            }
            console.log(price.toFixed(2));
            break;
        case "Saturday":
        case "Sunday":
            switch(fruit){
                case "banana":
                    price = count * 2.70;
                    break;
                case "apple":
                    price = count * 1.25;
                    break;
                case "orange":
                    price = count * 0.90;
                    break;
                case "grapefruit":
                    price = count * 1.60;
                    break;
                case "kiwi":
                    price = count * 3.00;
                    break;
                case "pineapple":
                    price = count * 5.60;
                    break;
                case "grapes":
                    price = count * 4.20;
                    break;
                default:
                    console.log("error");
                    break;
            }
            console.log(price.toFixed(2));
            break;
        default:
            console.log("error");
            break;
    }

}

=======
function fruitShop(input){
    let fruit = input[0];
    let day = input[1];
    let count = input[2];
    let price = 0;

    switch(day){
        case "Monday":
        case "Tuesday":
        case "Wednesday":
        case "Thursday":
        case "Friday":
            switch (fruit){
                case "banana":
                    price = count * 2.50;
                    break;
                case "apple":
                    price = count * 1.20;
                    break;
                case "orange":
                    price = count * 0.85;
                    break;
                case "grapefruit":
                    price = count * 1.45;
                    break;
                case "kiwi":
                    price = count * 2.70;
                    break;
                case "pineapple":
                    price = count * 5.50;
                    break;
                case "grapes":
                    price = count * 3.85;
                    break;

                default:
                    console.log("error");
                    break;
            }
            console.log(price.toFixed(2));
            break;
        case "Saturday":
        case "Sunday":
            switch(fruit){
                case "banana":
                    price = count * 2.70;
                    break;
                case "apple":
                    price = count * 1.25;
                    break;
                case "orange":
                    price = count * 0.90;
                    break;
                case "grapefruit":
                    price = count * 1.60;
                    break;
                case "kiwi":
                    price = count * 3.00;
                    break;
                case "pineapple":
                    price = count * 5.60;
                    break;
                case "grapes":
                    price = count * 4.20;
                    break;
                default:
                    console.log("error");
                    break;
            }
            console.log(price.toFixed(2));
            break;
        default:
            console.log("error");
            break;
    }

}

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
fruitShop(["tomato", "Monday", "2.5"])