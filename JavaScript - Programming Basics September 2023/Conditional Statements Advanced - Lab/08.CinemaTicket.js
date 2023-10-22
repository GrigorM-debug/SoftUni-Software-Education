function cinemaTickets(input){
    let day = input.shift();
    let price =0;
    switch(day){
        case "Monday":
        case "Tuesday":
            price = 12;
            break;
        case "Wednesday":
        case "Thursday":
            price = 14;
            break;
        case "Friday":
            price = 12;
            break;
        case "Saturday":
        case "Sunday":
            price = 16;
            break;
    }

    console.log(price);
}

cinemaTickets(["Sunday"])