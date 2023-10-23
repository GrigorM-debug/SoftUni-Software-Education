function Sequence2kPlus1(input){
    let n = Number(input[0]);
    let num = 1;

    while(num <= n){
        console.log(num);
        num = 2 * num + 1;
    }
}

Sequence2kPlus1(["17"]);