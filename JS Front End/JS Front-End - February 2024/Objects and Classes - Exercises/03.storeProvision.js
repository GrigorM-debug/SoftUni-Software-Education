function solve(storeStockInput, storeDeliveryInput){
    const storeStockBook = {};

    for(let i = 0; i < storeStockInput.length; i+=2){
        const stockProductName = storeStockInput[i];
        const stockProductQuantity = storeStockInput[i+1];
        
        storeStockBook[stockProductName] = Number(stockProductQuantity);
    }

    for(let i = 0; i < storeDeliveryInput.length; i+=2){
        const deliveryProductName = storeDeliveryInput[i];
        const deliveryProductQuantity = storeDeliveryInput[i+1];

        if(Object.keys(storeStockBook).some(key => key === deliveryProductName)){
            storeStockBook[deliveryProductName] += Number(deliveryProductQuantity);
        } else{
            storeStockBook[deliveryProductName] = Number(deliveryProductQuantity);
        }
    }

    for(const key in storeStockBook){
        console.log(`${key} -> ${storeStockBook[key]}`)
    }
}

solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]       
    )