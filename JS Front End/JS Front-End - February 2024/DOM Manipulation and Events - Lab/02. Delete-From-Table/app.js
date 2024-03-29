function deleteByEmail() {
    const emailInputElement = document.querySelector('input');
    const trElements = document.querySelectorAll('table tbody tr');
    const resultElement = document.getElementById('result');

    const resultTrElements = Array.from(trElements)
    .find(tr => tr.children[1].textContent.includes(emailInputElement.value));

    if(resultTrElements){
        resultTrElements.remove();
        resultElement.textContent = 'Deleted.'
    } else{
        resultElement.textContent = 'Not found.'
    }

    emailInputElement.value = '';
}