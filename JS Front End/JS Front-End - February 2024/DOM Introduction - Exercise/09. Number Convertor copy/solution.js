function solve() {
    const numberInputElement = document.getElementById('input');
    const selectMenuToElement = document.getElementById('selectMenuTo');
    const selectMenuFromElement = document.getElementById('selectMenuFrom');
    const buttonElement = document.querySelector('button');
    const resultElement = document.getElementById('result');
    
    const binaryOptionFromElement = document.createElement('option');
    binaryOptionFromElement.value = 'binary';
    binaryOptionFromElement.textContent = 'Binary';
    selectMenuFromElement.appendChild(binaryOptionFromElement);

    const hexadecimalOptionFromElement = document.createElement('option');
    hexadecimalOptionFromElement.value = 'hexadecimal';
    hexadecimalOptionFromElement.textContent = 'Hexadecimal';
    selectMenuFromElement.appendChild(hexadecimalOptionFromElement);
    
    const binaryOptionElement = selectMenuToElement.querySelector('option');
    binaryOptionElement.value = 'binary';
    binaryOptionElement.textContent = 'Binary';

    const hexadecimalOptionElement = document.createElement('option');
    hexadecimalOptionElement.value = 'hexadecimal';
    hexadecimalOptionElement.textContent = 'Hexadecimal';
    selectMenuToElement.appendChild(hexadecimalOptionElement);

    const decimalOptionElement = document.createElement('option');
    decimalOptionElement.value = 'decimal';
    decimalOptionElement.textContent = 'Decimal';
    selectMenuToElement.appendChild(decimalOptionElement);


    const conversionKeyFormat = `${selectMenuFromElement.value}-${selectMenuToElement.value}`;

    const converter = {
         'decimal-binary': decimalToBinary,
        'decimal-hexadecimal': decimalToHexadecimal,
        'binary-decimal': binaryToDecimal,
        'binary-hexadecimal': binaryToHexadecimal,
        // 'hexadecimal-binary': hexadecimalToBinary,
        // 'hexadecimal-decimal': hexadecimalToDecimal,
    };

    buttonElement.addEventListener('click', () => {
        const numberValue = Number(numberInputElement.value);

        resultElement.value = converter[conversionKeyFormat](numberValue);
    });

    function decimalToBinary(number){
        return number.toString(2);
    }

    function decimalToHexadecimal(number){
        return number.toString(16).toUpperCase();
    }

    function binaryToDecimal(number){
        const binary = number.toString().split('');
        let decimal = 0;

        for(let i = 0; i < binary.length; i++){
            decimal = (decimal * 2) + Number(binary[i]);
        }

        return decimal;
    }

    function binaryToHexadecimal(binaryNumber) {
        const decimal = parseInt(binaryNumber, 2);
        const hex = decimalToHexadecimal(decimal);
        return hex;
    }
}