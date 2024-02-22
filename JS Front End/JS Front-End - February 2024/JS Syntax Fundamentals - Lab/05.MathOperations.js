function solve(numOne, numTwo, operation){
    switch(operation){
        case '+':
            console.log(numOne + numTwo);
            break;
        case '-':
            console.log(numOne - numTwo);
            break;
        case '*':
            console.log(numOne * numTwo);
            break;
        case '/':
            console.log(numOne / numTwo);
            break;
        case '%':
            console.log(numOne % numTwo);
            break;
        case '**':
            console.log(numOne ** numTwo)
            break;
    }
}

solve(5, 6, '+');