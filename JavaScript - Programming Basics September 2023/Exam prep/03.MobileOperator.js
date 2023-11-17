function mobileoperator(input) {
    let durationOfContract = input[0];
    let typeContract = input[1];
    let mobileNet = input[2];
    let numberMounth = Number(input[3]);
    let price = 0;
    switch (typeContract) {

        case "Small":

            if (durationOfContract === "one") {

                price = 9.98;

            } else if (durationOfContract === "two") {

                price = 8.58;

            }

            break;

        case "Middle":

            if (durationOfContract === "one") {

                price = 18.99;

            } else if (durationOfContract === "two") {

                price = 17.09;

            }

            break;

        case "Large":

            if (durationOfContract === "one") {

                price = 25.98;

            } else if (durationOfContract === "two") {

                price = 23.59;

            }

            break;

        case "ExtraLarge":

            if (durationOfContract === "one") {

                price = 35.99;

            } else if (durationOfContract === "two") {

                price = 31.79;

            }

            if (mobileNet === "yes") {

            } if (price <= 10) {

                price += 5.50;

            } else if (price <= 30) {

                price += 4.35;

            } else if (price > 30) {

                price += 3.85;

            }

            break;

        default: break;

    }
 
    if (durationOfContract === "Two") {
        price * 96.25;
    }
 
    let numberOFMountForpay = price * numberMounth
    console.log(numberOFMountForpay.toFixed(2))
}