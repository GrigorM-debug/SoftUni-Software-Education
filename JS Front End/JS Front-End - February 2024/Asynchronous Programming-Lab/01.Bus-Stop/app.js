function getInfo() {
    const inputstopIdElement = document.getElementById('stopId');
    const buttonElement = document.getElementById('submit')
    const stopNameElement = document.getElementById('stopName');
    const busesListElement = document.getElementById('buses');

    const baseURL = "http://localhost:3030/jsonstore/bus/businfo";
    const stopId = inputstopIdElement.value;

    buttonElement.addEventListener('click', () => {
        fetch(`${baseURL}/${stopId}`)
            .then(response => response.json())
            .then(stopInfo => {
                const stopName = stopInfo.name;
                stopNameElement.textContent = stopName;
                busesListElement.innerHTML = '';
                for(const bussID in stopInfo.buses){
                    const liElement = document.createElement('li');
                    liElement.textContent = `Bus ${bussID} arrives in ${stopInfo.buses[bussID]} minutes`; 
                    busesListElement.appendChild(liElement);
                }
            })
            .catch(error => {
                stopNameElement.textContent = 'Error';
                busesListElement.innerHTML = '';
            })
    })
}