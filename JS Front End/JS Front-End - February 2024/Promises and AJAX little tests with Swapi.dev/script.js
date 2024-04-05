function solve() {
    const baseURL = "https://swapi.dev/api/people";
    const data = {
        "name": "Leia Organa",
        "height": "150",
        "mass": "49",
        "hair_color": "brown",
        "skin_color": "light",
        "eye_color": "brown",
        "birth_year": "19BBY",
        "gender": "female",
        "homeworld": "https://swapi.dev/api/planets/2/",
        "films": [
          "https://swapi.dev/api/films/1/",
          "https://swapi.dev/api/films/2/",
          "https://swapi.dev/api/films/3/",
          "https://swapi.dev/api/films/6/"
        ],
        "species": [],
        "vehicles": [
          "https://swapi.dev/api/vehicles/30/"
        ],
        "starships": [
          "https://swapi.dev/api/starships/28/",
          "https://swapi.dev/api/starships/59/"
        ],
        "created": "2014-12-09T13:50:51.644000Z",
        "edited": "2014-12-20T21:17:56.891000Z",
        "url": "https://swapi.dev/api/people/5/"
      }

    // fetch(baseURL)
    //     .then(response => response.json())
    //     .then(data => console.log(data))
    //     .catch(errorMessage => console.log(errorMessage))
    
    fetch(baseURL)
      .then(response => response.json())
      .then(datas => {
            //Printing the names of all the peoples
            console.log(datas.results)
            for(const resultObj of Array.from(datas.results)){
                console.log(resultObj.name)
            }
      })
      .catch(error => console.log(error))

    //It works, but in Swapi.dev you can do only GET methods. I try to add new person. 
    // fetch(baseURL, {
    //     method: "POST",
    //     headers: {
    //         "Content-Type": "splication/json",
    //     },
    //     body: JSON.stringify(data)
    // })
    // .then(response => response.json(data))
    // .then(data => {
    //     console.log('Succesfully added !')
    //     console.log(data)
    // })
    // .catch(error => console.log(error))
}

solve()