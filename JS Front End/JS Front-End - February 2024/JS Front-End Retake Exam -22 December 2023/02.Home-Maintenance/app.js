window.addEventListener("load", solve);

function solve(){
    const addButtonElement = document.getElementById('add-btn');
    const placeInputElement = document.getElementById('place');
    const actionInputElement = document.getElementById('action');
    const personInputElement = document.getElementById('person');

    const currentTasksListElement = document.getElementById('task-list');
    const doneTasksListElement = document.getElementById('done-list');

    addButtonElement.addEventListener('click', add)

    function add(){
        if(placeInputElement.value == "" || actionInputElement.value == "" || personInputElement.value == ""){
            return;
        }

        const place = placeInputElement.value;
        const action = actionInputElement.value;
        const person = personInputElement.value;

        const currTaskLiElement = document.createElement('li');
        currTaskLiElement.classList.add('clean-task');

        const articleElement = document.createElement('article');

        const placeParagraphElement = document.createElement('p');
        placeParagraphElement.textContent = `Place:${place}`;

        const actionParagraphElement = document.createElement('p');
        actionParagraphElement.textContent = `Action:${action}`;

        const personParagraphElement = document.createElement('p');
        personParagraphElement.textContent = `Person:${person}`

        articleElement.appendChild(placeParagraphElement);
        articleElement.appendChild(actionParagraphElement);
        addButtonElement.appendChild(personParagraphElement);

        currTaskLiElement.appendChild(articleElement);

        const buttonsDivElement = document.createElement('div');
        buttonsDivElement.classList.add('buttons');

        const editButton = document.createElement('button');
        editButton.classList.add('edit');
        editButton.textContent = 'Edit';

        const doneButton = document.createElement('button');
        doneButton.classList.add('done');
        doneButton.textContent = 'Done';

        buttonsDivElement.appendChild(editButton);
        buttonsDivElement.appendChild(doneButton);

        currTaskLiElement.appendChild(buttonsDivElement);

        currentTasksListElement.appendChild(currTaskLiElement);

        placeInputElement.value = '';
        actionInputElement.value = '';
        personInputElement.value = '';

        editButton.addEventListener('click', () => {
            placeInputElement.value = place;
            actionInputElement.value = action;
            personInputElement.value = person;

            currTaskLiElement.innerHTML = ''
        })

        const deleteButton = document.createElement('button');
        deleteButton.classList.add('delete');
        deleteButton.textContent = 'Delete';

        doneButton.addEventListener('click', () => {
            currTaskLiElement.removeChild(buttonsDivElement);
            currentTasksListElement.removeChild(currTaskLiElement);

            // const deleteButton = document.createElement('button');
            // deleteButton.classList.add('delete');
            // deleteButton.textContent = 'Delete';

            currTaskLiElement.appendChild(deleteButton);

            doneTasksListElement.appendChild(currTaskLiElement);
        })

        deleteButton.addEventListener('click', () =>{
            doneTasksListElement.removeChild(currTaskLiElement);
        })
    }
}