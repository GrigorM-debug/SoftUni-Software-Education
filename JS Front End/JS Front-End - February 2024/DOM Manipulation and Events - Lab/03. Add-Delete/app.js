function addItem() {
    const listElement = document.getElementById('items');
    const inputElement = document.getElementById('newItemText');

    const newListChildElement = document.createElement('li');
    newListChildElement.textContent = inputElement.value;

    const createAnchorElement = document.createElement('a');
    createAnchorElement.textContent = '[Delete]';
    createAnchorElement.href = '#';

    newListChildElement.appendChild(createAnchorElement);

    listElement.appendChild(newListChildElement);

    createAnchorElement.addEventListener('click', () => {
        newListChildElement.remove();
    });

    inputElement.value = '';
}