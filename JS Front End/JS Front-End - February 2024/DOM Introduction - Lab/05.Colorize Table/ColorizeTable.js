function colorize() {
    const tableElements = document.querySelectorAll('table tr:nth-child(even)');

    for (const element of tableElements) {
        element.style.backgroundColor = 'Teal';
    }
}