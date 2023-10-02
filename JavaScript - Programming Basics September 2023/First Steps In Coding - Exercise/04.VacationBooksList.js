function vacationBookList(input){
    let pages = Number(input[0]);
    let pagesForOneHour = Number(input[1]);
    let days = Number(input[2]);

    let numberOfHours = (pages / pagesForOneHour) / days;

    console.log(numberOfHours);
}

vacationBookList(["212", "20", "2"]);
vacationBookList(["432", "15", "4"]);