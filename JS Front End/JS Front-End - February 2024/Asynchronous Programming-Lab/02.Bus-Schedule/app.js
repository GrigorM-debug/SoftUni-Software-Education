function solve() {
    const infoBoxElement = document.querySelector('.info');
    const departButton = document.getElementById('depart');
    const arriveButton = document.getElementById('arrive');

    let stopId = 'depot';
    let nextStopName = '';

    const baseURL = 'http://localhost:3030/jsonstore/bus/schedule'
    function depart() {
        fetch(`${baseURL}/${stopId}`)
            .then(response => response.json())
            .then(data => {
                infoBoxElement.textContent = `Next stop ${data.name}`
                nextStopName = data.name;
                stopId = data.next;
                departButton.disabled = true;
                arriveButton.disabled = false;
            })
            .catch(errror => {
                infoBoxElement.textContent = 'Error';
                departButton.disabled = true;
                arriveButton.disabled = true;
            })
    }

    async function arrive() {
        infoBoxElement.textContent = `Arriving at ${nextStopName}`;
        arriveButton.disabled = true;
        departButton.disabled = false;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();