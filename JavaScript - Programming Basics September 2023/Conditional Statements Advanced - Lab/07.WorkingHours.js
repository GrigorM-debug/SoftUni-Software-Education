<<<<<<< HEAD
function workingHours(input){
    let hour = Number(input[0]);
    let day = input[1];

    switch(day){
        case "Monday":
        case "Tuesday":
        case "Wednesday":
        case "Thursday":
        case "Friday":
        case "Saturday":
            if(hour >= 10 && hour <= 18){
                console.log("open");
            }
            else {
                console.log("closed");
            }
            break;
        case "Sunday":
            console.log("closed");
            break;
    }
}

=======
function workingHours(input){
    let hour = Number(input[0]);
    let day = input[1];

    switch(day){
        case "Monday":
        case "Tuesday":
        case "Wednesday":
        case "Thursday":
        case "Friday":
        case "Saturday":
            if(hour >= 10 && hour <= 18){
                console.log("open");
            }
            else {
                console.log("closed");
            }
            break;
        case "Sunday":
            console.log("closed");
            break;
    }
}

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
workingHours(["11", "Sunday"]);