const baseURL = 'http://localhost:3030/jsonstore/games';

const gameNameInputElement =document.getElementById('g-name');
const typeInputElement = document.getElementById('type');
const maxPlayersInputElement = document.getElementById('players');

const addButton = document.getElementById('add-game');
const editButton = document.getElementById('edit-game');
const loadGamesButton = document.getElementById('load-games');

const gameListElement = document.getElementById('games-list');

let currGameID = null;

loadGamesButton.addEventListener('click', loadGames);

function createElements(game){
    const fragment = document.createDocumentFragment();
    const divElement = document.createElement('div');
    divElement.classList.add('board-game');

    const contentDivElement = document.createElement('div');
    contentDivElement.classList.add('content')

    const nameP = document.createElement('li');
    nameP.textContent = `${game.name}`

    const typeP = document.createElement('li');
    typeP.textContent = `${game.type}`

    const playersP = document.createElement('li');
    playersP.textContent = `${game.players}`;

    const paragraphFragment = document.createDocumentFragment();

    paragraphFragment.appendChild(nameP);
    paragraphFragment.appendChild(typeP);
    paragraphFragment.appendChild(playersP);

    contentDivElement.appendChild(paragraphFragment)

    const buttonsDiv = document.createElement('div');
    buttonsDiv.classList.add('buttons-container');

    const changeButton = document.createElement('button');
    changeButton.classList.add('change-btn')
    changeButton.textContent = 'Change';

    const deleteButton = document.createElement('button');
    deleteButton.classList.add('delete-btn')
    deleteButton.textContent = 'Delete';

    const buttonsFragment = document.createDocumentFragment();

    buttonsFragment.appendChild(changeButton);
    buttonsFragment.appendChild(deleteButton)

    buttonsDiv.appendChild(buttonsFragment);

    const contentAndButtonsFragment = document.createDocumentFragment();

    contentAndButtonsFragment.appendChild(contentDivElement);
    contentAndButtonsFragment.appendChild(buttonsDiv);

    divElement.appendChild(contentAndButtonsFragment);

    fragment.appendChild(divElement)

    gameListElement.appendChild(fragment);

    changeButton.addEventListener('click', () =>{
        currGameID = game._id;
        gameNameInputElement.value = game.name;
        typeInputElement.value = game.type;
        maxPlayersInputElement.value = game.players;

        addButton.disabled = true;
        editButton.disabled = false;
        divElement.remove();
    });

    deleteButton.addEventListener('click', () => {
        fetch(`${baseURL}/${game._id}`, {
            method: 'DELETE'
        })
    
        divElement.remove()
        loadGames();
    });
}

function loadGames(){
    gameListElement.innerHTML = '';
    fetch(baseURL)
    .then(res => res.json())
    .then(gameData =>
        Object.values(gameData).forEach(game => createElements(game)));
}

addButton.addEventListener('click', addGames);

function addGames(){
    const gameToAdd = {
        name: gameNameInputElement.value,
        type: typeInputElement.value,
        players: maxPlayersInputElement.value
    }

    fetch(baseURL, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(gameToAdd)
    })

    // clearInputs();
    // loadGames();

    loadGames();
    clearInputs();
}

editButton.addEventListener('click', editGame);

function editGame(){
    const gameToEdit = {
        _id: currGameID,
        name: gameNameInputElement.value,
        type: typeInputElement.value,
        players: maxPlayersInputElement.value
    }

    fetch(`${baseURL}/${currGameID}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json'
        }, 
        body: JSON.stringify(gameToEdit)
    })

    editButton.disabled = true;
    addButton.disabled = false;
    currGameID = null;
    clearInputs();
    loadGames();
}

function clearInputs(){
    gameNameInputElement.value = '';
    typeInputElement.value = '';
    maxPlayersInputElement.value = '';
}