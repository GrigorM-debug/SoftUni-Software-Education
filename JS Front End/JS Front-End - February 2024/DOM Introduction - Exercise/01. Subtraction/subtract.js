function subtract() {
    const firstNumberElement = document.getElementById('firstNumber');
    const secondNumberElement = document.getElementById('secondNumber');
    const resultElement = document.getElementById('result');

    const firstNumber = Number(firstNumberElement.value);
    const secondNumber = Number(secondNumberElement.value);

    const subtraction = firstNumber - secondNumber;

    resultElement.textContent = subtraction;
}