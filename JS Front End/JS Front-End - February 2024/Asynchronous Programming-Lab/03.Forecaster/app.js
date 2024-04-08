function attachEvents() {
    const locationInputElement = document.getElementById('location');
    const getWeatherButtonElement = document.getElementById('submit');
    const forecastElement = document.getElementById('forecast');
    const currentElement = document.getElementById('current');
    const upcomingElement = document.getElementById('upcoming');

    const baseURL = 'http://localhost:3030/jsonstore/forecaster/locations';

    getWeatherButtonElement.addEventListener('click', ()=> {
        fetch(`${baseURL}/${locationInputElement.value}`)
            .then(response => response.json())
            .then(locationData => {
                const { code } = locationData.find(location => location.name === locationInputElement.value)
                // const code = foundLocation.code;
                console.log(code)

                return Promise.all([
                    fetch(`${baseURL}/today/${code}`),
                    fetch(`${baseURL}/upcoming/${code}`)
                ])
            })
            .then(responses => Promise.all(responses.map(res => res.json())))
            .then(([today, upcoming]) => {
                console.log(today)
                console.log(upcoming)

                forecastElement.style.display = 'block';
                const forecastELEMENT = document.createElement('div');
                forecastELEMENT.classList.add('forecasts');
                
                forecastELEMENT.innerHTML = `
                    <span class='conditional symbol'>${weatherSymbols[today.forecast.condition]}</span>
                    <span class='condition'>
                        <span class='forecast-data'>${today.name}</span>
                        <span class='forecast-data'>${today.forecast.low}/${today.forecast.high}</span>
                        <span class='forecast-data'>${today.forecast.condition}</span>
                    </span>
                `;
                currentElement.appendChild(forecastELEMENT);

                const forecastInfoElement = document.createElement('div');
                forecastInfoElement.classList.add('forecast-info');

                forecastInfoElement.innerHTML = `
                    <span class='upcoming'>
                        <span class='symbol'>${weatherSymbols[upcoming.forecast.condition]}</span>
                        <span class='condition'>
                            <span class='forecast-data'>${upcoming.forecast.low}/${upcoming.forecast.high}</span>
                            <span class='forecast-data'>${upcoming.forecast.condition}</span>
                        </span>
                    </span>
                `;
            
                upcomingElement.appendChild(forecastInfoElement)
            })
            .catch(error => {
                forecastElement.textContent = 'Error';
            })
    })


    const weatherSymbols = {
        'Sunny': '☀',
        'Partly Sunny': '⛅',
        'Overcast': '☁',
        'Rain': '☂',
        'Degrees':	'°',
    }
}

attachEvents(); 