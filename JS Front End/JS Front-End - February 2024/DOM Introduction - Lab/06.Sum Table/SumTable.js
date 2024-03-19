function sumTable() {
    const tableElements = document.querySelectorAll('table td:nth-child(even):not(#sum)');
    const sumElement = document.getElementById('sum');

    const sum = Array.from(tableElements).reduce((sum, element) => sum += Number(element.textContent), 0);

    sumElement.textContent = sum;
}