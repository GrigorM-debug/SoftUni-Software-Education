function solve(input){
    let movies = [];

    for(const commandMovie of input){
        const splitMovieCommand = commandMovie.split(' ');

        if(commandMovie.includes('addMovie')){
            const movieName = splitMovieCommand.slice(1).join(' ');
            const movie ={
                'name': movieName
            }
            movies.push(movie)
        } else if(commandMovie.includes('directedBy')){
            const [movieName, director] = commandMovie.split(' directedBy ');

            // const movie ={
            //     'name': movieName
            // }
            // movies.push(movie)

            for(const movie of movies){
                if(movie['name'] === movieName){
                    movie['director'] = director;
                }
            }
        } else if (commandMovie.includes('onDate')){
            const [movieName, date] = commandMovie.split(' onDate ');

            for(const movie of movies){
                if(movie['name'] === movieName){
                    movie['date'] = date;
                }
            }
        }
    }

    for(const movie of movies){
        if(movie['name'] && movie['director'] && movie['date']){
            const movieToJSON = JSON.stringify(movie);
            console.log(movieToJSON);
        }
    } 
}

solve([
    'addMovie The Avengers',
    'addMovie Superman',
    'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
    ]            
    )