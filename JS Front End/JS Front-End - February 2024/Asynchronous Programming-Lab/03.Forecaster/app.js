function attachEvents() {
    const locationInputElement = document.querySelector('#location');
    const getWeatherButtonElement = document.getElementById('submit');
    const forecastElement = document.getElementById('forecast');
    const currentElement = document.getElementById('current');
    const upcomingElement = document.getElementById('upcoming');

    const weatherSymbols = {
        'Sunny': '☀',
        'Partly Sunny': '⛅',
        'Overcast': '☁',
        'Rain': '☂',
        'Degrees': '°',
    };

    const baseURL = 'http://localhost:3030/jsonstore/forecaster/locations';

    getWeatherButtonElement.addEventListener('click', () => {
        forecastElement.style.display = 'block';
        fetch(`${baseURL}/${locationInputElement.value}`)
            .then(response => response.json())
            .then(locationData => {
                const { code } = locationData.find(location => location.name === locationInputElement.value);
                console.log(code);

                return Promise.all([
                    fetch(`${baseURL}/today/${code}`),
                    fetch(`${baseURL}/upcoming/${code}`)
                ]);
            })
            .then(responses => Promise.all(responses.map(res => res.json())))
            .then(([today, upcoming]) => {
                console.log(today)
                console.log(upcoming)
                // forecastElement.style.display = 'block';
                //Current forecast element
                // Creating current forecast element
                const currentForecastElement = document.createElement('div');
                currentForecastElement.classList.add('forecast');

                const currentSymbolSpan = document.createElement('span');
                currentSymbolSpan.classList.add('conditional', 'symbol');
                currentSymbolSpan.textContent = weatherSymbols[today.forecast.condition];
                currentForecastElement.appendChild(currentSymbolSpan);

                const currentConditionSpan = document.createElement('span');
                currentConditionSpan.classList.add('condition');

                const currentNameSpan = document.createElement('span');
                currentNameSpan.classList.add('forecast-data');
                currentNameSpan.textContent = today.name;
                currentConditionSpan.appendChild(currentNameSpan);

                const currentTemperatureSpan = document.createElement('span');
                currentTemperatureSpan.classList.add('forecast-data');
                currentTemperatureSpan.textContent = `${today.forecast.low}/${today.forecast.high}`;
                currentConditionSpan.appendChild(currentTemperatureSpan);

                const ConditionSpan = document.createElement('span');
                ConditionSpan.classList.add('forecast-data');
                ConditionSpan.textContent = today.forecast.condition;
                ConditionSpan.appendChild(ConditionSpan);

                currentForecastElement.appendChild(currentConditionSpan);

                currentElement.appendChild(currentForecastElement);


                const forecastInfoElement = document.createElement('div');
                forecastInfoElement.classList.add('forecast-info');

                for (const upcomingForecastObj of upcoming.forecast) {
                    const upcomingSpan = document.createElement('span');
                    upcomingSpan.classList.add('upcoming');
                    upcomingSpan.innerHTML = `
                        <span class='symbol'>${weatherSymbols[upcomingForecastObj.condition]}</span>
                        <span class='condition'>
                            <span class='forecast-data'>${upcomingForecastObj.low}/${upcomingForecastObj.high}</span>
                            <span class='forecast-data'>${upcomingForecastObj.condition}</span>
                        </span>
                    `;
                    forecastInfoElement.appendChild(upcomingSpan);
                }

                upcomingElement.appendChild(forecastInfoElement);
            })
            .catch(error => {
                forecastElement.textContent = 'Error';
            });
    });
}

attachEvents();
