function solve() {
    const numberInputElement = document.getElementById('input');
    const selectMenuToElement = document.getElementById('selectMenuTo');    const buttonElement = document.querySelector('button');
    const resultElement = document.getElementById('result');
    
    const binaryOptionElement = selectMenuToElement.querySelector('option');
    binaryOptionElement.value = 'binary';
    binaryOptionElement.textContent = 'Binary';

    const hexadecimalOptionElement = document.createElement('option');
    hexadecimalOptionElement.value = 'hexadecimal';
    hexadecimalOptionElement.textContent = 'Hexadecimal';
    selectMenuToElement.appendChild(hexadecimalOptionElement);

    const converter= {
        binary: decimalToBinary,
        hexadecimal: decimalToHexadecimal,
    };

    buttonElement.addEventListener('click', () => {
        const numberValue = Number(numberInputElement.value);

        resultElement.value = converter[selectMenuToElement.value](numberValue);
    });

    function decimalToBinary(number){
        return number.toString(2);
    }

    function decimalToHexadecimal(number){
        return number.toString(16).toUpperCase();
    }
}