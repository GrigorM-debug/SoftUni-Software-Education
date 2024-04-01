function addItem() {
    const menuElement = document.getElementById('menu');
    const newItemTextInputElement = document.getElementById('newItemText');
    const newItemValueInputElement = document.getElementById('newItemValue');

    const newOptionElement = document.createElement('option');
    newOptionElement.textContent = newItemTextInputElement.value;
    newOptionElement.value = newItemValueInputElement.value;

    menuElement.appendChild(newOptionElement)

    newItemTextInputElement.value = '';
    newItemValueInputElement.value = '';
}