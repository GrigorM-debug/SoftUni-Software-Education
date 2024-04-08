// function getInfo() {
//     const inputstopIdElement = document.getElementById('stopId');
//     const buttonElement = document.getElementById('submit')
//     const stopNameElement = document.getElementById('stopName');
//     const busesListElement = document.getElementById('buses');

//     const baseURL = "http://localhost:3030/jsonstore/bus/businfo";
//     const stopId = inputstopIdElement.value;

//     busesListElement.innerHTML = '';
//     buttonElement.addEventListener('click', () => {
//         fetch(`${baseURL}/${stopId}`)
//             .then(response => response.json())
//             .then(stopInfo => {
//                 stopNameElement.value = stopInfo.name
//                 // stopNameElement.textContent = stopName;
//                 // for(const bussID in stopInfo.buses){
//                 //     const liElement = document.createElement('li');
//                 //     liElement.textContent = `Bus ${bussID} arrives in ${stopInfo.buses[bussID]} minutes`; 
//                 //     busesListElement.appendChild(liElement);
//                 // }
//                 Object.entries(stopInfo.buses).forEach(([busId, time]) => {
//                     const li = document.createElement('li');
//                     li.textContent = `Bus ${busId} arrives in ${time} minutes`;
//                     busesListElement.appendChild(li);
//             })
//             .catch(error => {
//                 stopNameElement.textContent = 'Error';
//                 busesListElement.innerHTML = '';
//             })
//     })
// }

function getInfo(){
    const baseUrl = 'http://localhost:3030/jsonstore/bus/businfo/';

    const ulBusses = document.getElementById('buses');
    const stopId = document.getElementById('stopId');
    const stopName = document.getElementById('stopName');

    ulBusses.innerText = '';
    fetch(baseUrl + stopId.value)
        .then(response => response.json())
        .then(data => {
            stopName.textContent = data.name;
            Object.entries(data.buses).forEach(([busId, time]) => {
                const li = document.createElement('li');
                li.textContent = `Bus ${busId} arrives in ${time} minutes`;
                ulBusses.appendChild(li);
            })
        })
        .catch(error => {
            console.error(error);
            stopName.textContent = 'Error';
            ulBusses.innerText = '';
        })
}