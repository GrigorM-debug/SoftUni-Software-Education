function focused() {
    const inputElements = document.querySelectorAll('input[type=text]')

    for (const inputElement of inputElements) {
        const inputElementParrent = inputElement.parentElement;

        inputElement.addEventListener('focus', () =>{
            inputElementParrent.classList.add('focused');
        });

        inputElement.addEventListener('blur', () =>{
            inputElementParrent.classList.remove('focused')
        });
    }
}