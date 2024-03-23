function toggle() {
    const buttonElement = document.getElementsByClassName('button')[0];
    const extraDivElement = document.getElementById('extra');

    const currentButtonTextContent = buttonElement.textContent;

    if(currentButtonTextContent === 'More'){
        extraDivElement.style.display = 'block';
        buttonElement.textContent = 'Less';
    }

    if(currentButtonTextContent === 'Less'){
        extraDivElement.style.display = 'none';
        buttonElement.textContent = 'More';
    }
}