function solve(input){
    const catalogue = []

    for(const line of input){
        const [productName, productPrice] = line.split(' : ')

        const product = {
            productName: productName,
            productPrice: productPrice
        };
        catalogue.push(product);
    }

    catalogue.sort((a, b) => a.productName.localeCompare(b.productName))

    let startLetter = '';
    for(const product of catalogue){
        if(product.productName.charAt(0) === startLetter){
            console.log(`  ${product.productName}: ${product.productPrice}`)
        } else{
            startLetter = product.productName.charAt(0);
            console.log(`${startLetter}`)
            console.log(`  ${product.productName}: ${product.productPrice}`)
        }
    }
}

solve([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
    ]       
    )