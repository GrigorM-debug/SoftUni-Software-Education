function solve(input){
    const carParkingLot = {};

    for(const row of input){
        const [command, carNumber] = row.split(', ');

        if(command === 'IN'){
            carParkingLot[carNumber] = true;
        } else if(command === 'OUT'){
            delete carParkingLot[carNumber];
        }
    }

    if(Object.keys(carParkingLot).length === 0){
        console.log('Parking Lot is Empty')
    }

    const sortedCarParkingLot = Object.keys(carParkingLot).sort((a, b) => a.localeCompare(b));

    for (const car of sortedCarParkingLot) {
        console.log(car)
    }e
}

solve(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'OUT, CA1234TA']
)