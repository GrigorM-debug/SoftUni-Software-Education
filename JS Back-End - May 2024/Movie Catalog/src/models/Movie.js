class Movie{
    id;
    title;
    genre;
    director;
    year;
    imageURL;
    rating;
    description;

    // Method to set the values
    setDetails(moviData) {
        this.id = moviData.id;
        this.title = moviData.title;
        this.genre = moviData.genre;
        this.director = moviData.director;
        this.year = moviData.year;
        this.imageURL = moviData.imageURL;
        this.rating = moviData.rating;
        this.description = moviData.description;
    }
}

module.exports = {Movie}