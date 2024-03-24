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

    const binaryOptionElement = document.createElement('option');
    binaryOptionElement.value = 'binary';
    binaryOptionElement.textContent = 'Binary';
    selectMenuToElement.appendChild(binaryOptionElement);

    const hexadecimalOptionElement = document.createElement('option');
    hexadecimalOptionElement.value = 'hexadecimal';
    hexadecimalOptionElement.textContent = 'Hexadecimal';
    selectMenuToElement.appendChild(hexadecimalOptionElement);

    const decimalOptionElement = document.createElement('option');
    decimalOptionElement.value = 'decimal';
    decimalOptionElement.textContent = 'Decimal';
    selectMenuToElement.appendChild(decimalOptionElement);

    buttonElement.addEventListener('click', () => {
        const conversionKeyFormat = `${selectMenuFromElement.value}-${selectMenuToElement.value}`;
        let numberValue = 0;

        if(selectMenuFromElement.value === 'hexadecimal'){
            numberValue = numberInputElement.value;
        } else{
            numberValue = Number(numberInputElement.value);
        }

        resultElement.value = converter[conversionKeyFormat](numberValue);
    });

    function decimalToBinary(number) {
        return number.toString(2);
    }

    function decimalToHexadecimal(number) {
        return number.toString(16).toUpperCase();
    }

    function binaryToDecimal(number) {
        const binary = number.toString().split('').reverse().join(''); // Reverse the binary string
        let decimal = 0;

        for (let i = 0; i < binary.length; i++) {
            decimal += Number(binary[i]) * Math.pow(2, i);
        }

        return decimal;
    }

    function binaryToHexadecimal(binaryNumber) {
        const decimal = binaryToDecimal(binaryNumber);
        return decimalToHexadecimal(decimal);
    }

    function hexadecimalToBinary(hexadecimalNumber) {
        const hexToBinDict = {
            '0': '0000', '1': '0001', '2': '0010', '3': '0011',
            '4': '0100', '5': '0101', '6': '0110', '7': '0111',
            '8': '1000', '9': '1001', 'A': '1010', 'B': '1011',
            'C': '1100', 'D': '1101', 'E': '1110', 'F': '1111'
        };

        hexadecimalNumber = hexadecimalNumber.toUpperCase();

        let binaryNumber = '';

        for(let i = 0; i < hexadecimalNumber.length; i++){
            const digit = hexadecimalNumber[i];

            binaryNumber += hexToBinDict[digit];
        }

        return binaryNumber;
    }

    function hexadecimalToDecimal(hexadecimalNumber) {
        // return parseInt(hexadecimalNumber, 16);
        // return Number('0x', hexadecimalNumber).toString();

        let len = hexadecimalNumber.length;

        let base = 1;

        let dec_val = 0;

        for (let i = len - 1; i >= 0; i--) { 
            if (hexadecimalNumber.charAt(i) >= '0' && hexadecimalNumber.charAt(i) <= '9') { 
                dec_val += (hexadecimalNumber.charAt(i).charCodeAt(0) - 48) * base; 

                base = base * 16; 
            } else if(hexadecimalNumber.charAt(i) >= 'A' && hexadecimalNumber.charAt(i) <= 'F'){
                dec_val += (hexadecimalNumber.charAt(i).charCodeAt(0) - 55) * base; 

                base = base * 16; 
            }
        }
        return dec_val;
    }

    const converter = {
        'decimal-binary': decimalToBinary,
        'decimal-hexadecimal': decimalToHexadecimal,
        'binary-decimal': binaryToDecimal,
        'binary-hexadecimal': binaryToHexadecimal,
        'hexadecimal-binary': hexadecimalToBinary,
        'hexadecimal-decimal': hexadecimalToDecimal,
    };
}
