function extractText() {
    const listElements = document.getElementById('items');
    const textAreaElement = document.getElementById('result');

    const textToAdd = Array.from(listElements.children).reduce((text, element) => text += element.textContent + "\n", '');

    textAreaElement.value = textToAdd;
}