function validate() {
    const inputElement = document.getElementById('email');
    const regex = /^[a-z]+\@[a-z]+\.[a-z]+/;

    inputElement.addEventListener('change', () => {
        if(!regex.test(inputElement.value)){
            inputElement.classList.add('error');
        } else {
            inputElement.classList.remove('error');
        }
    });
}