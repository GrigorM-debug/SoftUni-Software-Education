const baseURL = 'http://localhost:3030/jsonstore/tasks';

const loadMealsButton = document.getElementById('load-meals')
const listElement = document.getElementById('list');
const addMealButton = document.getElementById('add-meal');
const editMealButton = document.getElementById('edit-meal')
// const deleteMealButton = document.getElementById('delete-meal');

const inputFoodlElement = document.getElementById('food')
const inputTimeElement = document.getElementById('time')
const inputCaloriesElement = document.getElementById('calories')

loadMealsButton.addEventListener('click', loadMeals)

let currMealID = null;

function loadMeals(){
    clearListElement()
    fetch(baseURL)
        .then(res => res.json())
        .then(mealsData =>{
            Object.values(mealsData).forEach(meal =>{
                creatingMealsDomElements(meal)
            });
        })

        // editMealButton.disabled = false;
}

function creatingMealsDomElements(meal){
    const divElement = document.createElement('div');
    divElement.classList.add('meal');

    const foodNameh2Element = document.createElement('h2')
    foodNameh2Element.textContent = meal.food;

    const timeh2Element = document.createElement('h3')
    timeh2Element.textContent = meal.time;

    const caloriesh2Element = document.createElement('h3')
    caloriesh2Element.textContent = meal.calories;

    const buttonsDivElement = document.createElement('div');
    buttonsDivElement.classList.add('meal-buttons');

    const changeButtonElement = document.createElement('button')
    changeButtonElement.classList.add('change-meal');
    changeButtonElement.textContent = 'Change';

    const deleteButtonElement = document.createElement('button')
    deleteButtonElement.classList.add('delete-meal');
    deleteButtonElement.textContent = 'Delete';

    buttonsDivElement.appendChild(changeButtonElement);
    buttonsDivElement.appendChild(deleteButtonElement);

    divElement.appendChild(foodNameh2Element);
    divElement.appendChild(timeh2Element);
    divElement.appendChild(caloriesh2Element);
    divElement.appendChild(buttonsDivElement);

    listElement.appendChild(divElement);

    
    //Just testing I am sure for no

    changeButtonElement.addEventListener('click', () =>{
        currMealID = meal._id;

        inputFoodlElement.value = meal.food;
        inputTimeElement.value = meal.time;
        inputCaloriesElement.value = meal.calories;

        editMealButton.disabled = false;
        addMealButton.disabled = true;

        divElement.remove()
    })

    // editMealButton.addEventListener('click', editMeal(currentElementID))

    deleteButtonElement.addEventListener('click', () =>{
        fetch(`${baseURL}/${meal._id}`,{
            method: 'DELETE'
        })
        
        divElement.remove();

        loadMeals();
    });
}

editMealButton.addEventListener('click', editMeal)

function editMeal(){
    const editedMeal = {
        _id: currMealID,
        food: inputFoodlElement.value,
        time: inputTimeElement.value,
        calories: inputCaloriesElement.value
    }

    fetch(`${baseURL}/${currMealID}`,{
        method: 'PUT',
        headers:{
            'content-type': 'application/json',
        },
        body: JSON.stringify(editedMeal)
    })
    clearingInputFields();
    loadMeals();
    editMealButton.disabled = true;
    addMealButton.disabled = false;
    currMealID = null;
}

// deleteMealButton.addEventListener('click', deleteMeal)


addMealButton.addEventListener('click', addMeals);

function addMeals(){
    const mealToAdd = {
        food: inputFoodlElement.value,
        time: inputTimeElement.value,
        calories: inputCaloriesElement.value
    }
    fetch(baseURL, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify(mealToAdd)
    })

    clearingInputFields();
    loadMeals();
}

function clearListElement(){
    listElement.innerHTML = '';
}

function clearingInputFields(){
    inputFoodlElement.value = '';
    inputTimeElement.value = '';
    inputCaloriesElement.value = '';
}