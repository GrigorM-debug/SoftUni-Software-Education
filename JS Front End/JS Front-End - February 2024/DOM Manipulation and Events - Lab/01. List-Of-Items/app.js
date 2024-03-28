function addItem() {
    const parentElement = document.getElementById('items');
    const inputElement = document.getElementById('newItemText');

    const newListChildElement = document.createElement('li');
    newListChildElement.textContent = inputElement.value;

    parentElement.appendChild(newListChildElement);

    inputElement.value = '';
}