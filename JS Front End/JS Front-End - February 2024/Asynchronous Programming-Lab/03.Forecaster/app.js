function attachEvents() {
    const locationInputElement = document.querySelector('#location');
    const getWeatherButtonElement = document.getElementById('submit');
    const forecastElement = document.getElementById('forecast');
    const currentElement = document.getElementById('current');
    const upcomingElement = document.getElementById('upcoming');

    const weatherSymbols = {
        'Sunny': '&#x2600',
        'Partly sunny': '&#x26C5',
        'Overcast': '&#x2601',
        'Rain': '&#x2614',
        'Degrees': '&#176'
    };

    const baseURL = 'http://localhost:3030/jsonstore/forecaster/locations';

    getWeatherButtonElement.addEventListener('click', () => {
        forecastElement.style.display = 'block';
        const locationValue = locationInputElement.value;

        fetch(`${baseURL}`)
            .then(response => response.json())
            .then(locationData => {
                const code = locationData.filter(location => location.name === locationValue)[0].code;

                console.log(code)
                return Promise.all([
                    fetch(`http://localhost:3030/jsonstore/forecaster/today/${code}`),
                    fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${code}`)
                ]);
            })
            .then(responses => Promise.all(responses.map(res => res.json())))
            .then(([today, upcoming]) => {
                const currentForecastElement = document.createElement('div');
                currentForecastElement.classList.add('forecast');

                currentForecastElement.innerHTML = `
                    <span class='symbol'>${weatherSymbols[today.forecast.condition]}</span>
                    <span class='condition'>
                        <span class='forecast-data'>${today.name}</span>
                        <span class='forecast-data'>${today.forecast.low}${weatherSymbols['Degrees']}/${today.forecast.high}${weatherSymbols['Degrees']}</span>
                        <span class='forecast-data'>${today.forecast.condition}</span>
                    </span>
                `;

                currentElement.appendChild(currentForecastElement);

                const forecastInfoElement = document.createElement('div');
                forecastInfoElement.classList.add('forecast-info');

                for (const upcomingForecastObj of upcoming.forecast) {
                    const upcomingSpan = document.createElement('span');
                    upcomingSpan.classList.add('upcoming');
                    upcomingSpan.innerHTML = `
                        <span class='symbol'>${weatherSymbols[upcomingForecastObj.condition]}</span>
                        <span class='condition'>
                            <span class='forecast-data'>${upcomingForecastObj.low}${weatherSymbols['Degrees']}/${upcomingForecastObj.high}${weatherSymbols['Degrees']}</span>
                            <span class='forecast-data'>${upcomingForecastObj.condition}</span>
                        </span>
                    `;
                    forecastInfoElement.appendChild(upcomingSpan);
                }

                upcomingElement.appendChild(forecastInfoElement);
            })
            // .catch(error => {
            //     forecastElement.textContent = 'Error';
            // });
    });
}

attachEvents();