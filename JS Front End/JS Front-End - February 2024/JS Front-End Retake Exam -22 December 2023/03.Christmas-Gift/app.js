const baseURL = 'http://localhost:3030/jsonstore/gifts';

const inputGifElement = document.getElementById('gift');
const inputForElement = document.getElementById('for');
const inputPriceElement = document.getElementById('price');

const addButton = document.getElementById('add-present');
const editButton = document.getElementById('edit-present');

const giftListElement = document.getElementById('gift-list');

const loadGiftsButton = document.getElementById('load-presents');

loadGiftsButton.addEventListener('click', loadGifts);

let currentGiftId = null;

function loadGifts(){
    clearingListElement();
    fetch(`${baseURL}`)
        .then(res => res.json())
        .then(giftsInfo =>{
            Object.values(giftsInfo).forEach(gift => {
                createGiftsElements(gift);
            })
        })
                
}

function createGiftsElements(gift){

    // const giftName = gift.gift;
    // const forPerson = gift.for;
    // const price = gift.price;

    const divGiftElement = document.createElement('div');
    divGiftElement.classList.add('gift-sock');

    const divContentElement = document.createElement('div');
    divContentElement.classList.add('content');

    const giftNameParagraph = document.createElement('p');
    giftNameParagraph.textContent = gift.gift;

    const forPersonParagraph = document.createElement('p');
    forPersonParagraph.textContent = gift.for;

    const priceParagraph = document.createElement('p');
    priceParagraph.textContent = gift.price;

    divContentElement.appendChild(giftNameParagraph);
    divContentElement.appendChild(forPersonParagraph);
    divContentElement.appendChild(priceParagraph)

    divGiftElement.appendChild(divContentElement);

    const buttonsDiv = document.createElement('div');
    buttonsDiv.classList.add('buttons-container');

    const changeButton = document.createElement('button');
    changeButton.classList.add('change-btn');
    changeButton.textContent = 'Change';

    const deleteButton = document.createElement('button');
    deleteButton.classList.add('delete-btn');
    deleteButton.textContent = 'Delete';

    buttonsDiv.appendChild(changeButton);
    buttonsDiv.appendChild(deleteButton);

    divGiftElement.appendChild(buttonsDiv);

    giftListElement.appendChild(divGiftElement)

    editButton.disabled = true;
    // addButton.disabled = false;

    changeButton.addEventListener('click', () =>{
        currentGiftId = gift._id;

        inputGifElement.value = gift.gift;
        inputForElement.value = gift.for;
        inputPriceElement.value = gift.price;

        editButton.disabled = false;
        addButton.disabled = true;

        divGiftElement.remove();
    })

    deleteButton.addEventListener('click', () =>{
        fetch(`${baseURL}/${gift._id}`, {
            method: 'DELETE'
        })

        divGiftElement.remove();
        loadGifts();
    })
}

addButton.addEventListener('click', addGift);

function addGift(){
    if(inputForElement !== "" && inputGifElement !== "" && inputPriceElement !== ""){
        const giftToAdd = {
            gift: inputGifElement.value,
            for: inputForElement.value,
            price: inputPriceElement.value
        }
        // event.preventDefault();
        fetch(`${baseURL}`, {
            method: 'POST',
            headers:{
                'content-type': 'application/json',
            },
            body: JSON.stringify(giftToAdd)
        })
        // clearInputs();
        loadGifts();
        clearInputs();
    }
    // loadGifts();
    // clearInputs();
}

editButton.addEventListener('click', editGift);

function editGift(){
    const editedGift = {
        _id: currentGiftId,
        gift: inputGifElement.value,
        for: inputForElement.value,
        price: inputPriceElement.value
    }

    fetch(`${baseURL}/${currentGiftId}`, {
        method: 'PUT',
        headers:{
            'content-type': 'application/json',
        },
        body: JSON.stringify(editedGift)
    })
    clearInputs();
    loadGifts();
    // loadGifts();
    // clearInputs();
    // editButton.disabled = false;
    // addButton.disabled = true;
    editButton.disabled = true;
    addButton.disabled = false;
    currentGiftId = null;
}

function clearInputs(){
    inputGifElement.value = '';
    inputForElement.value = '';
    inputPriceElement.value = '';
}

function clearingListElement(){
    giftListElement.innerHTML = '';
}