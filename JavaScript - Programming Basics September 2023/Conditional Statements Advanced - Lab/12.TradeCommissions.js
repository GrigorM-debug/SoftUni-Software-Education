function tradeCommissions(input){
    let town = input[0];
    let sale = Number(input[1]);
    let commission = 0;

    switch(town){
        case "Sofia":
            if(0 <= sale && sale <= 500){
                commission = sale * 0.05;
                console.log(commission.toFixed(2));
            }
            else if(500 < sale && sale <= 1000){
                commission = sale * 0.07;
                console.log(commission.toFixed(2));
            }
            else if (1000 < sale && sale <= 10000){
                commission = sale * 0.08;
                console.log(commission.toFixed(2));
            }
            else if (sale > 10000){
                commission = sale * 0.12;
                console.log(commission.toFixed(2));
            }
            else{
                console.log("error");
            }
            break;
        case "Varna":
            if(0 <= sale && sale <= 500){
                commission = sale * 0.045;
                console.log(commission.toFixed(2));
            }
            else if(500 < sale && sale <= 1000){
                commission = sale * 0.075;
                console.log(commission.toFixed(2));
            }
            else if (1000 < sale && sale <= 10000){
                commission = sale * 0.10;
                console.log(commission.toFixed(2));
            }
            else if (sale > 10000){
                commission = sale * 0.13;
                console.log(commission.toFixed(2));
            }
            else{
                console.log("error");
            }
            break;
        case "Plovdiv":
            if(0 <= sale && sale <= 500){
                commission = sale * 0.055;
                console.log(commission.toFixed(2));
            }
            else if(500 < sale && sale <= 1000){
                commission = sale * 0.08;
                console.log(commission.toFixed(2));
            }
            else if (1000 < sale && sale <= 10000){
                commission = sale * 0.12;
                console.log(commission.toFixed(2));
            }
            else if (sale > 10000){ 
                commission = sale * 0.145;
                console.log(commission.toFixed(2));
            }
            else{
                console.log("error");
            }
            break;
        default:
            console.log("error");
            break;
    }
}

tradeCommissions(["Sofia", "1500"]);
tradeCommissions(["Plovdiv", "499.99"]);
tradeCommissions(["Varna", "3874.50"]);
tradeCommissions(["Kaspichan", "-50"]);



