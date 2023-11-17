function tennisRanklist(input) {
    let numberOfTournaments = Number(input[0]);
    let startingPoints = Number(input[1]);
    let totalPoints = startingPoints;
    let numWins = 0;
    
    for (let i = 0; i < numberOfTournaments; i++) {
      let stage = input[i+2];
      
      if (stage === 'W') {
        totalPoints += 2000;
        numWins++;
      } else if (stage === 'F') {
        totalPoints += 1200;
      } else if (stage === 'SF') {
        totalPoints += 720;
      }
    }
    
    let averagePoints = Math.floor((totalPoints - startingPoints) / numberOfTournaments);
    let percentageWins = ((numWins / numberOfTournaments) * 100).toFixed(2);
    
    console.log(`Final points: ${totalPoints}`);
    console.log(`Average points: ${averagePoints}`);
    console.log(`${percentageWins}%`);
  }
  
  tennisRanklist(["7", "1200", "SF", "F", "W", "F", "W", "SF", "W"]);