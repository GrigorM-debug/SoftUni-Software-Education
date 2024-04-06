function solve(){
    const baseURL = "https://swapi.dev/api/planets";

    fetch(baseURL)
        .then(response => response.json())
        .then(data => {
            const results = data.results;

            for(const result of results){
                console.log(result);
            }
        })
        .catch(errorMessage => console.log(errorMessage))
}

solve()