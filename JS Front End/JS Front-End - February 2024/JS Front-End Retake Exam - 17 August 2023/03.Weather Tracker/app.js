const baseURL = 'http://localhost:3030/jsonstore/tasks';

const locationInputElement = document.getElementById('location');
const temperatureInputElement = document.getElementById('temperature');
const dateInputElement = document.getElementById('date');

const addButton = document.getElementById('add-weather');
const editButton = document.getElementById('edit-weather');
const loadDataButton = document.getElementById('load-history');

const listElementToAddWeatherElemenst = document.getElementById('list');

let currElementID = null;

loadDataButton.addEventListener('click', loadData);

function createElements(weather){
    const location = weather.location;
    const temperature = weather.temperature;
    const date = weather.date;

    const divElement = document.createElement('div');
    divElement.classList.add('container');

    const locationElement = document.createElement('h2');
    locationElement.textContent = `${location}`;
    const temperatureElement = document.createElement('h3');
    temperatureElement.textContent = `${temperature}`;
    const dateElement = document.createElement('h3');
    dateElement.textContent = `${date}`;

    const buttonsDiv = document.createElement('div');
    buttonsDiv.classList.add('buttons-container')

    const changeButton = document.createElement('button');
    changeButton.classList.add('change-btn');
    changeButton.textContent = 'Change';

    const deleteButton = document.createElement('button');
    deleteButton.classList.add('delete-btn');
    deleteButton.textContent = 'Delete';

    buttonsDiv.appendChild(changeButton);
    buttonsDiv.appendChild(deleteButton);

    divElement.appendChild(locationElement);
    divElement.appendChild(temperatureElement);
    divElement.appendChild(dateElement);
    divElement.appendChild(buttonsDiv);

    listElementToAddWeatherElemenst.appendChild(divElement);

    editButton.disabled = true;

    changeButton.addEventListener('click', () =>{
        currElementID = weather._id;
        divElement.remove()

        locationInputElement.value = weather.location;
        temperatureInputElement.value = weather.temperature;
        dateInputElement.value = weather.date;

        editButton.disabled = false;
        addButton.disabled = true;
    })

    deleteButton.addEventListener('click', ()=>{
        fetch(`${baseURL}/${weather._id}`,{
            method: 'DELETE'
        })

        divElement.remove();
        loadData();
    })
}

function loadData(){
    listElementToAddWeatherElemenst.innerHTML = '';
    fetch(baseURL)
        .then(response => response.json())
        .then(weatherData =>{
            Object.values(weatherData).forEach(weather => createElements(weather))
        })
}

addButton.addEventListener('click', addWeather);

function addWeather(){
    const weatherToAdd = {
        location: locationInputElement.value,
        temperature: temperatureInputElement.value,
        date: dateInputElement.value
    }

    fetch(baseURL,{
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(weatherToAdd)
    })

    clearInputs();
    loadData();
}

editButton.addEventListener('click', editWeather);

function editWeather(){
    const weatherToEdit = {
        _id: currElementID, 
        location: locationInputElement.value,
        temperature: temperatureInputElement.value,
        date: dateInputElement.value
    }

    fetch(`${baseURL}/${currElementID}`,{
        method: 'PUT',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(weatherToEdit)

    })
    currElementID = null;
    addButton.disabled = false;
    editButton.disabled = true;
    clearInputs();
    loadData();
}

function clearInputs(){
    locationInputElement.value = "";
    temperatureInputElement.value = "";
    dateInputElement.value = "";
}