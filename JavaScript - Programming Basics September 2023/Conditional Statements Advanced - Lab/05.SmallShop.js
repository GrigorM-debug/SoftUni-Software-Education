<<<<<<< HEAD
function smallShop(input){
    let product = input[0];
    let town = input[1];
    let count = Number(input[2]);
    let price = 0;

    switch(town){
        case "Sofia":
            switch(product){
                case "coffee":
                    price = count * 0.50;
                    break;
                case "water":
                    price = count * 0.80;
                    break;
                case "beer":
                    price = count * 1.20;
                    break;
                case "sweets":
                    price = count * 1.45;
                    break;
                case "peanuts":
                    price = count * 1.60;
                    break;
            }
            break;
        case "Plovdiv":
            switch(product){
                case "coffee":
                    price = count * 0.40;
                    break;
                case "water":
                    price = count * 0.70;
                    break;
                case "beer":
                    price = count * 1.15;
                    break;
                case "sweets":
                    price = count * 1.30;
                    break;
                case "peanuts":
                    price = count * 1.50;
                    break;
            }
            break;
        case "Varna":
            switch(product){
                case "coffee":
                    price = count * 0.45;
                    break;
                case "water":
                    price = count * 0.70;
                    break;
                case "beer":
                    price = count * 1.10;
                    break;
                case "sweets":
                    price = count * 1.35;
                    break;
                case "peanuts":
                    price = count * 1.55;
                    break;
            }
            break;
    }

    console.log(price);
}

=======
function smallShop(input){
    let product = input[0];
    let town = input[1];
    let count = Number(input[2]);
    let price = 0;

    switch(town){
        case "Sofia":
            switch(product){
                case "coffee":
                    price = count * 0.50;
                    break;
                case "water":
                    price = count * 0.80;
                    break;
                case "beer":
                    price = count * 1.20;
                    break;
                case "sweets":
                    price = count * 1.45;
                    break;
                case "peanuts":
                    price = count * 1.60;
                    break;
            }
            break;
        case "Plovdiv":
            switch(product){
                case "coffee":
                    price = count * 0.40;
                    break;
                case "water":
                    price = count * 0.70;
                    break;
                case "beer":
                    price = count * 1.15;
                    break;
                case "sweets":
                    price = count * 1.30;
                    break;
                case "peanuts":
                    price = count * 1.50;
                    break;
            }
            break;
        case "Varna":
            switch(product){
                case "coffee":
                    price = count * 0.45;
                    break;
                case "water":
                    price = count * 0.70;
                    break;
                case "beer":
                    price = count * 1.10;
                    break;
                case "sweets":
                    price = count * 1.35;
                    break;
                case "peanuts":
                    price = count * 1.55;
                    break;
            }
            break;
    }

    console.log(price);
}

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
smallShop(["peanuts", "Plovdiv", "1"]);