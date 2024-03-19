function calc() {
    const num1Element = document.getElementById('num1');
    const num2Element = document.getElementById('num2');

    const sumElement = document.getElementById('sum');

    const num1ToNumber = Number(num1Element.value);
    const num2ToNumber = Number(num2Element.value);

    const sum = num1ToNumber + num2ToNumber;

    sumElement.value = sum;
}
