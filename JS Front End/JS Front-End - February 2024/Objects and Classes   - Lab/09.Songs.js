function solve(input){
    class Song{
        constructor(type, name, time){
            this.type = type;
            this.name = name;
            this.time = time;
        }
    }

    let songs = [];

    const numberOfSongs = input.shift();
    const requiredType = input.pop();

    for(let i = 0; i < numberOfSongs; i++){
        const [type, name, time] = input[i].split('_');

        let song = new Song(type, name, time);

        songs.push(song);
    }

    if(requiredType === 'all'){
        songs.forEach(song => console.log(song.name));
    } else {
        let songsByType = songs.filter(song => song.type == requiredType);
        songsByType.forEach(song => console.log(song.name));
    }
}

solve([3,
    'favourite_DownTown_3:14',
    'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01',
    'favourite']
    );