<<<<<<< HEAD
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

=======
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

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
cinemaTickets(["Sunday"])