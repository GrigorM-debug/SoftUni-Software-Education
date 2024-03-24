function solve(employees){
    // let employeesBook = {};

    // for(const employee of employees){
    //     const employeeName = employee;
    //     const employeePersonalNumber = employeeName.length;
        
    //     employeesBook[employeeName] = employeePersonalNumber;
    // }

    // for(const employeeKey in employeesBook){
    //     console.log(`Name: ${employeeKey} -- Personal Number: ${employeesBook[employeeKey]}`)
    // }
    employees.map(employeeName => {
        return {
            name: employeeName,
            personalNumber: employeeName.length
        }
    }
    ).forEach(employee => console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`));
}

solve([
    'Samuel Jackson',
    'Will Smith',
    'Bruce Willis',
    'Tom Holland'
    ]    
    )